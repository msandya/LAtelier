<template>
    <div class="container">
      <div class="page-header">
            <h1>Events</h1>
      </div>

      <div class="panel panel-default">
            <div class="panel-body text-right">
                <router-link class="btn btn-primary" :to="`events/create`"><i class="glyphicon glyphicon-plus"></i>Add an event</router-link>
            </div>
      </div>

      <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Event Name</th>
                    <th>Description</th>
                    <th>Date</th>
                    <th>User Id</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="eventList.length == 0">
                    <td colspan="7" class="text-center">Event</td>
                </tr>

                <tr v-for="i of eventList">
                    <td>{{ i.eventId }}</td>
                    <td>{{ i.eventName }}</td>
                    <td>{{ i.description}}</td>
                    <td>{{ i.date }}</td>
                    <td>{{ i.userId }}</td>
                    <td>
                        <button @click="deleteEvent(i.eventId)"  class="btn btn-primary">Remove</button>
                        <router-link :to="`events/edit/${i.eventId}`">Edit event</router-link>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import AuthService from "../../services/AuthService";
    import EventApiService from '../../services/EventApiService';
    import UserApiService from '../../services/UserApiService';

  export default {
    data() {
        return {
            user: {},
            eventList: []
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
            this.eventList = await EventApiService.getEventListAsync(this.user.userId);
      },

      async deleteEvent(eventId) {
          try {
              await EventApiService.deleteEventAsync(eventId);
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