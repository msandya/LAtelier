<template>
  <div class="hello">
    <h1>Vote for the cutest cat</h1>

<button type="button" href="vote" class="btn btn-primary">Vote</button>
<button type="button" @click="prep()" class="btn btn-primary">Load</button>
<button type="button" @click="fonction()" class="btn btn-primary">Check</button>

  <button @click.prevent="activate()">+1</button>


  </div>
</template>

<script>
import imagesCats from './data.json'
import { mapGetters, mapActions } from 'vuex'
import $ from 'jquery'
import ApiHelper from './ApiHelper'
import store from '../store'


export default {
  name: 'Accueil',
  data () {
    return {
      msg: 'Welcome CatMash App',
      images: imagesCats.images,
      datas: []
    }
  },
  computed:{
    
    
  },
  methods:{
     activate () {
      store.commit('INCREMENT')
      console.log('boutton increment');
    },
    GetTheRandom(){
      return Math.floor((Math.random() * this.datas.length));
        }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
