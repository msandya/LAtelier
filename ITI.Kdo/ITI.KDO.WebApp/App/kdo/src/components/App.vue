<template>
<div id="app">
    <h1>Welcome to KDO!!!</h1>
</div>
</template>

<script>
import AuthService from "../services/AuthService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";

export default {
  computed: {
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