<template>
    <div class="container">    
      <div class="page-header">
            <h1 v-if="mode == 'create'">Create a present</h1>
            <h1 v-else>Edit your present</h1>
        </div>

        <form @submit="onSubmit($event)">
            <div class="alert alert-danger" v-if="errors.length > 0">
                <b>Les champs suivants semblent invalides : </b>

                <ul>
                    <li v-for="e of errors">{{e}}</li>
                </ul>
            </div>

            <div class="form-group">
                <label class="required">Present Name:</label>
                <input type="text" v-model="item.presentName" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Price</label>
                <input type="text" v-model="item.price" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Link Present</label>
                <input type="text" v-model="item.linkPresent" class="form-control" required>
            </div>

            <div class="form-group">
                <label>CategoryPresentId</label>
                <b-dropdown right text="Menu">
                    <tr v-for="i of presentList">
                        <b-dropdown-item>Item 1</b-dropdown-item>
                    </tr>
                </b-dropdown>
                <input type="text" v-model="item.categoryPresentId" class="form-control">
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>
    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import PresentApiService from '../../services/PresentApiService';
    import UserApiService from "../../services/UserApiService";
    import AuthService from "../../services/AuthService";

  export default {
    data() {
      return {
        user:{},
        item:{},
        mode: null,
        id: null,
        errors: []
      };
    },

    async mounted() {
        var userEmail = AuthService.emailUser();
        this.user = await UserApiService.getUserAsync(userEmail);
        this.mode = this.$route.params.mode;
        this.id = this.$route.params.id;
        
        if(this.mode == 'edit'){
                try {
                    // Here, we use "executeAsyncRequest" action. When an exception is thrown, it is not catched: you have to catch it.
                    // It is useful when we have to know if an error occurred, in order to adapt the user experience.
                    this.item = await this.executeAsyncRequest(() => PresentApiService.getPresentAsync(this.id));
                }
                catch(error) {
                    // So if an exception occurred, we redirect the user to the students list.
                    this.$router.replace('/presents');
                }
            }
    },

    methods: {
      ...mapActions(['executeAsyncRequest']),

      async onSubmit(e){
        e.preventDefault();

        var errors = [];

        if(!this.item.presentName) errors.push("Present Name");
        if(!this.item.price) errors.push("Price");
        if(!this.item.linkPresent) errors.push("Link Present");
        if(!this.item.categoryPresentId) errors.push("Category Present Id");

        this.errors = errors;

        if(errors.length == 0) {
          try {
              if(this.mode == 'create') {
                  this.item.userId = this.user.userId;
                  await this.executeAsyncRequest(() => PresentApiService.createPresentAsync(this.item));
              }
              else {
                  await this.executeAsyncRequest(() => PresentApiService.updatePresentAsync(this.item)); 
              }

              this.$router.replace('/presents');
          }
          catch(error) {
              // Custom error management here.
              // In our application, errors throwed when executing a request are managed globally via the "executeAsyncRequest" action: errors are added to the 'app.errors' state.
              // A custom component should react to this state when a new error is added, and make an action, like showing an alert message, or something else.
              // By the way, you can handle errors manually for each component if you need it...
          }
      }
      }
    }
  };
</script>

<style lang="less">

</style>