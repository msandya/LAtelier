<!--**********VUE**************-->
<!--The view, which is just a declarative mapping of the state;-->
<template>
  <div>
  <h1>This is app.</h1>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import UserApiService from "../services/AuthService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";

export default {
  //*********STATE*********
  //The state, which is the source of truth that drives our app;
  data() {
    return {
      userEmail: null
    };
  },

  ///******ACTION********
  //The actions, which are the possible ways the state could change in reaction to user inputs from the view.
  methods:{

  },

  
  computed: {
    ...mapGetters(["isLoading"]),
    auth: () => AuthService
  }
};
</script>

<style lang="less" scoped>
.progress {
  margin: 0px;
  padding: 0px;
  height: 5px;
}

a.router-link-active {
  font-weight: bold;
}
</style>

<style lang="less">
@import "../styles/global.less";
</style>