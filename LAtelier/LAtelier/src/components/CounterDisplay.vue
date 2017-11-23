<template>
<h1>{{ counter }}</h1>
</template>

<script>
import store from '../store.js'
import { mapGetters, mapActions } from 'vuex'

export default {
  computed: {
    counter () {
      return store.state.counter
    }
  }
}
</script>