<template>
  <div>
    <h1>You're connected.</h1>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import UserApiService from "../services/AuthService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";

export default {
  data() {
    return {
      userEmail: null
    };
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