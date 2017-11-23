import 'babel-polyfill';

import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue';
import $ from 'jquery';
import Vuex from 'vuex';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import store from './vuex/store';
import VueRouter from 'vue-router';

import App from './components/App.vue';
import Acc from './components/Acc.vue';
import Home from './components/Home.vue';
import Login from './components/Login.vue';
import Logout from './components/Logout.vue';


import UserProfile from './components/user/UserProfile.vue';
import UserProfileEdit from './components/user/UserProfileEdit.vue';

import PresentList from './components/present/PresentList.vue';
import PresentEdit from './components/present/PresentEdit.vue';

import AppDefault from './components/AppDefault.vue';

//import Register from './components/Register.vue';

//import User from './components/User/User.vue';
//import UserModificationMP from './components/User/UserEditPassword.vue';
//import QuiSommesNous from './components/QuiSommesNous.vue';

//import Simi from './components/Simulateur.vue';

import AuthService from './services/AuthService';


Vue.use(VueRouter);
Vue.use(BootstrapVue);

/**
 * Filter for routes requiring an authenticated user
 * @param {*} to 
 * @param {*} from 
 * @param {*} next 
 */
function requireAuth(to, from, next) {
    console.log(AuthService.isConnected);
    if (!AuthService.isConnected) {
        next({
            path: '/appDefault',
            query: { redirect: to.fullPath }
        });
        return;
    }

    var requiredProviders = to.meta.requiredProviders;

    if (requiredProviders && !AuthService.isBoundToProvider(requiredProviders)) {
        next(false);
    }

    next();
}

/**
 * Declaration of the different routes of our application, and the corresponding components
 */
const router = new VueRouter({
    mode: 'history',
    base: '/Home',
    routes: [
        { path: '/login', component: Login },
        { path: '/logout', component: Logout, beforeEnter: requireAuth },
        { path: '/acc', component: Acc, beforeEnter: requireAuth },

        { path: '/userProfile', component: UserProfile, beforeEnter: requireAuth },
        { path: '/userProfile/edit', component: UserProfileEdit, beforeEnter: requireAuth },

        { path: '/appDefault', component: AppDefault },

        { path: '/presents', component: PresentList, beforeEnter: requireAuth },
        { path: '/presents/:mode([create|edit]+)/:id?', component: PresentEdit, beforeEnter: requireAuth },

        { path: '', component: App, beforeEnter: requireAuth },
    ]
})

/**
 * Configuration of the authentication service
 */

// Allowed urls to access the application (if your website is http://mywebsite.com, you have to add it)
AuthService.allowedOrigins = ['http://localhost:54822', /* 'http://mywebsite.com' */ ];

// Server-side endpoint to logout
AuthService.logoutEndpoint = '/Account/LogOff';

// Allowed providers to log in our application, and the corresponding server-side endpoints
AuthService.loginEndpoint = '/Account/Login';

// Allowed providers to sign up our application, and the corresponding server-side endpoints
AuthService.registerEndpoint = '/Account/Register';

//Registered the project into the bdd
AuthService.registerProjectEndpoint = '/Project/Register';


AuthService.modifyPasswordEndpoint = '/Account/ModifyPassword';


AuthService.providers = {
    'Base': {
        endpoint: '/Account/Login'
    },
    'Google': {
        endpoint: '/Account/ExternalLogin?provider=Google'
    },
    'Facebook': {
        endpoint: '/Account/ExternalLogin?provider=Facebook'
    },
};
AuthService.appRedirect = () => router.replace('/app');


// Creation of the root Vue of the application
new Vue({
    el: '#app',
    router,
    store,
    render: h => h(Home)
});