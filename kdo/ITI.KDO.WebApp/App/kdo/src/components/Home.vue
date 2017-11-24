<template>
  <div id="fond" style="margin-top:-24px;">
 
    <b-navbar toggleable="md" type="dark" variant="dark" >

    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

    <b-collapse is-nav id="nav_collapse">

    <div class="container-fluid">
          <!-- Brand and toggle get grouped for better mobile display -->
      <div class="navbar-header">

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">

          <b-navbar-brand href="/Home">
            <img src="../img/logoKdo.png" style="width:50px"></img>
          </b-navbar-brand>

          <b-navbar-nav v-if="!auth.isConnected">
            <b-nav-item-dropdown left>
              <!-- Using button-content slot -->
              <template slot="button-content">
                Sign In
              </template>
              <b-dropdown-item @click="login('Google')" class="btn btn-lg btn-block btn-primary">Se connecter via Google</b-dropdown-item>
              <b-dropdown-item @click="login('Facebook')" class="btn btn-lg btn-block btn-primary">Se connecter via Facebook</b-dropdown-item>
              <b-dropdown-item @click="login('Base')" class="btn btn-lg btn-block btn-primary">Se connecter via KDO</b-dropdown-item>
            </b-nav-item-dropdown>

            <b-nav-item href="#" @click="register()">Sign Up</b-nav-item>
          </b-navbar-nav>

          <b-navbar-nav v-if="auth.isConnected">

            <b-nav-item v-if="$route.path != '/userProfile/edit'" v-b-toggle.collapse1 href="#">Profil</b-nav-item>

            <b-nav-item href="#"@click="logout()">Logout</b-nav-item>
          </b-navbar-nav>

        </b-navbar-nav>

      </div>
    </div>

    <div class="progress" v-show="isLoading">
      <div class="progress-bar progress-bar-striped active" role="progressbar" style="width: 100%"></div>
    </div>

    </b-collapse>
    </b-navbar>
  
    <router-view class="child"></router-view>
  
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import $ from 'jquery'
import UserApiService from "../services/AuthService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";
//import Vue from 'vue';
//import Vuex from 'vuex';

export default {
  data() {
    return {
      userEmail: null
    };
  },

  mounted() {
    AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
  },

  beforeDestroy() {
    AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
  },

  computed: {
    ...mapGetters(["isLoading"]),
    auth: () => AuthService
  },

  methods: {
    login(provider) {
      AuthService.login(provider);
    },

    register() {
      AuthService.register();
    },

    logout(){
      this.$router.replace('/logout');
    },

    onAuthenticated() {
      this.$router.replace("/");
    }
  }
};
</script>

<style lang="less" scoped>


.progress {
  margin: 0px;
  padding: 0px;
  height: 0px;
}

p {
    line-height:0;
}

a.router-link-active {
  font-weight: bold;
}

</style>

<style lang="less">
  @import "../styles/global.less";
</style>