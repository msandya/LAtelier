<template>
  <div class="hello">
    <h1>CatMash</h1>

    
  </div>
</template>

<script>
import imagesCats from './data.json'
import { mapGetters, mapActions } from 'vuex'
import $ from 'jquery'

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
    fonction(){
      console.log(this.images);
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
