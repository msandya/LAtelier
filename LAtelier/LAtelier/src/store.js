import Vuex from 'vuex'
import Vue from 'vue'
import { mapGetters, mapActions } from 'vuex'


Vue.use(Vuex)

var store = new Vuex.Store({
  state: {
    counter: 0
  },
  mutations: {
    INCREMENT (state) {
      state.counter ++
    }
  },
    strict: true // Vuex's patent pending anti-intern device

})
export default store
