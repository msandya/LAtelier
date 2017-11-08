<template>
  <div id="fond">
    <nav class="navbar navbar-inverse">
      <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#iti-navbar-collapse" aria-expanded="false">
            <span class="icon-bar"></span>
          </button>
          <router-link class="navbar-brand" to="/acc">
            <img src="../img/logoKdo.png" style="width:50px"></img>
          </router-link>
            <ul class="nav navbar-nav navbar-right" v-if="!auth.isConnected">
            <a href="#" @click="login()">Sign In</a>
            <a href="#" @click="register()">Sign Up</a>
         </ul>
          </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="iti-navbar-collapse" v-if="auth.isConnected">

          <ul class="nav navbar-nav navbar-right">
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">{{ auth.email }}
                <span class="caret"></span>
              </a>
            <ul class="dropdown-menu" role="menu">
            <li><a href="users/information">Profil</a></li>
            <li><a href="#" @click="modifyPassword()">Modify Password</a></li>
            <li><a href="#" @click="logout()">Se déconnecter</a></li>
            
          </ul>
            </li>
          </ul>
          <ul class="dropdown-menu">
            <li>
              <router-link :to="`users/information`">Profil</router-link>
            </li>
          </ul>
        </div>
        

        <!-- /.navbar-collapse -->
      </div>
      <!-- /.container-fluid -->
  
      <div class="progress" v-show="isLoading">
        <div class="progress-bar progress-bar-striped active" role="progressbar" style="width: 100%"></div>
      </div>
    </nav>
  
    <div class="container">
      <router-view class="child"></router-view>
    </div>
  
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

  computed: {
    ...mapGetters(["isLoading"]),
    auth: () => AuthService
  },

  methods: {
    login() {
      this.$router.replace('/login');
    },

    register() {
      AuthService.register();
    },

    modifyPassword(){
      AuthService.modifyPassword();
    },

    logout(){
      this.$router.replace('/logout');
    }
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