<template>
    <div>
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
                </tr>
            </thead>

            <tbody>
                <tr v-if="presentList.length == 0">
                    <td colspan="6" class="text-center">We-want-a-present!!!</td>
                </tr>

                <tr v-for="i of presentList">
                    <td>{{ i.presentId }}</td>
                    <td>{{ i.presentName }}</td>
                    <td>{{ i.price }}</td>
                    <td>{{ i.linkPresent }}</td>
                    <td>{{ i.categoryPresentId }}</td>
                    <td>{{ i.userId }}</td>
                </tr>
            </tbody>
        </table>

    </div>
</template>

<script>
  import { mapActions } from 'vuex'
  import PresentApiService from '../../services/PresentApiService';

  export default {
    data() {
      return {
        presentList: []
      };
    },

    async mounted() {
      await this.refreshList();
    },

    methods: {
      ...mapActions(['executeAsyncRequestOrDefault', 'executeAsyncRequest']),

      async refreshList() {
          this.presentList = await PresentApiService.getPresentListAsync() || [];
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
  iframe {
    width: 100%;
    height: 600px;
  }
</style>