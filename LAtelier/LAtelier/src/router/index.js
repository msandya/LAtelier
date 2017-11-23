import Vue from 'vue'
import Router from 'vue-router'
import Classement from '@/components/Classement'
import Accueil from '@/components/Accueil'
import IncrementButton from '@/components/IncrementButton'
import CounterDisplay from '@/components/CounterDisplay'
import Vote from '@/components/Vote'
import $ from 'jquery'
import 'babel-polyfill'
import Vuex from 'vuex';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
        {
      path: '/',
      name: 'Accueil',
      component: Accueil
    },
    {
      path: '/classement',
      name: 'Classement',
      component: Classement
    },
    {
      path: '/vote',
      name: 'Vote',
      component: Vote
    },
    {
      path: '/incrementButton',
      name: 'IncrementButton',
      component: IncrementButton
    },
    {
      path: '/counterDisplay',
      name: 'CounterDisplay',
      component: CounterDisplay
    }
  ]
})
