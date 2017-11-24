<template>
    <div class="container">
      <div class="page-header">
            <h1>Presents List</h1>
      </div>

      <div class="panel panel-default">
            <div class="panel-body text-right">
                <router-link class="btn btn-primary" :to="`presents/create`"><i class="glyphicon glyphicon-plus"></i>Add a present</router-link>
            </div>
      </div>

      <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Present Name</th>
                    <th>Price</th>
                    <th>Link Present</th>
                    <th>Category Present</th>
                    <th>User Id</th>
                    <th>Options</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="presentList.length == 0">
                    <td colspan="7" class="text-center">We-want-a-present!!!</td>
                </tr>

                <tr v-for="i of presentList">
                    <td>{{ i.presentId }}</td>
                    <td>{{ i.presentName }}</td>
                    <td>{{ i.price }}</td>
                    <td>{{ i.linkPresent }}</td>
                    <td>{{ i.categoryPresentId }}</td>
                    <td>{{ i.userId }}</td>
                    <td>
                        <button @click="deletePresent(i.presentId)"  class="btn btn-primary">Remove</button>
                        <router-link :to="`presents/edit/${i.presentId}`">Edit Present</router-link>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import AuthService from "../../services/AuthService";
    import PresentApiService from '../../services/PresentApiService';
    import UserApiService from '../../services/UserApiService';

  export default {
    data() {
        return {
            user: {},
            presentList: []
        };
    },

    async mounted() {
        var userEmail = AuthService.emailUser();
        this.user = await UserApiService.getUserAsync(userEmail);

        await this.refreshList();
    },

    methods: {
      ...mapActions(['executeAsyncRequestOrDefault', 'executeAsyncRequest']),

      async refreshList() {
            this.presentList = await PresentApiService.getPresentListAsync(this.user.userId);
      },

      async deletePresent(presentId) {
          try {
              await PresentApiService.deletePresentAsync(presentId);
              await this.refreshList();
          }
          catch(error) {

          }
      }
  }
  };
</script>

<style lang="less">

</style>