<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h1>{{ counter }}</h1>
        <h3>Increment:</h3>
    <vote></vote>
    <div class="container">
        <div class="list-group">
            <div class="list-group-item">
                <div class="row">
                      <tr v-for="i of images">
                        <td><img :src="i.url" height="200" width="200"/></td>vote:0
                      </tr>
                </div>
            </div>
        </div>
    </div>
    
  </div>
</template>

<script>
import store from '../store.js'
import Vote from './Vote.vue'
import imagesCats from './data.json'
import { mapGetters, mapActions } from 'vuex'
import $ from 'jquery'


export default {
  name: 'Accueil',
  data () {
    return {
      msg: 'Classement des chats',
      images: imagesCats.images,
      item: {},
      datas: []
    }
  },
  computed:{
       counter () {
      return store.state.counter
    }
  },
   methods:{
    fonction(){
      console.log(this.images);
    }
  },
  components: {
    Vote
  },
  events: {
    'button-pressed': function () {
      // Send a message to all children
      this.$broadcast('increment')
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
