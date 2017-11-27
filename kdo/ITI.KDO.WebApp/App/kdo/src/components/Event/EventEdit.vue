<template>
    <div class="container">    
      <div class="page-header">
            <h1 v-if="mode == 'create'">Create a event</h1>
            <h1 v-else>Edit your event</h1>
        </div>

        <form @submit="onSubmit($event)">
            <div class="alert alert-danger" v-if="errors.length > 0">
                <b>Les champs suivants semblent invalides : </b>

                <ul>
                    <li v-for="e of errors">{{e}}</li>
                </ul>
            </div>

            <div class="form-group">
                <label class="required">Event Name:</label>
                <input type="text" v-model="item.eventName" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Description</label>
                <textarea type="text" v-model="item.description" class="form-control" required></textarea>
            </div>

            <!--div class="form-group">
                <label>Participants</label>
                <b-dropdown right text="Menu">
                    <tr v-for="i of eventList">
                        <b-dropdown-item>Item 1</b-dropdown-item>
                    </tr>
                </b-dropdown>
                <input type="text" v-model="item.friendsId" class="form-control">
            </div>

            <div class="form-group">
                <label class="required">Date</label>
                <input type="text" v-model="item.date" class="form-control" required>
            </div!-->

            <div class="form-group row">
            <label for="example-datetime-local-input" class="required">Date and time</label>
            <div class="col-10">
                <input class="form-control" type="datetime-local" v-model="item.date" value="2011-08-19T13:45:00" id="example-datetime-local-input" required>
            </div>
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>
    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import EventApiService from '../../services/EventApiService';
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
                    this.item = await this.executeAsyncRequest(() => EventApiService.getEventAsync(this.id));
                }
                catch(error) {
                    // So if an exception occurred, we redirect the user to the students list.
                    this.$router.replace('/events');
                }
            }
    },

    methods: {
      ...mapActions(['executeAsyncRequest']),

      async onSubmit(e){
        e.preventDefault();

        var errors = [];

        if(!this.item.eventName) errors.push("Event Name");
        //if(!this.item.participants) errors.push("Participants");
        if(!this.item.date) errors.push("Date");
        //if(!this.item.friendsId) errors.push("friends Id");

        this.errors = errors;

        if(errors.length == 0) {
          try {
              if(this.mode == 'create') {
                  this.item.userId = this.user.userId;
                  await this.executeAsyncRequest(() => EventtApiService.createEventAsync(this.item));
              }
              else {
                  await this.executeAsyncRequest(() => EventApiService.updateEventAsync(this.item)); 
              }

              this.$router.replace('/events');
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