<!--**********VUE**************-->
<!--The view, which is just a declarative mapping of the state;-->
<template>
  <div>
    <b-row>
      <b-col md="2" class="bg-dark">
        <nav id="bd-docs-nav" class="bd-links navbar-collapse collapse show" style="padding-top: 30px">
          <b-nav-item variant="dark" href="#">Créer un évènement</b-nav-item>
          <b-nav-item variant="dark" href="#">Mes contacts</b-nav-item>
          <b-nav-item variant="dark" href="#">Calendrier</b-nav-item>
          <b-nav-item variant="dark" href="#">Ma liste de cadeau</b-nav-item>
        </nav>
      </b-col>

      <b-col md="8" class="bg-light">
        <b-row>
            <b-col><b-btn variant="primary" href="#">Ma liste de cadeau</b-btn></b-col>
            <b-col><b-btn variant="success" href="#">Mes contacts</b-btn></b-col>
        </b-row>
        <b-row>
            <b-col>
              <b-row>
                <b-col md="5">
                  Evènements récents :
                </b-col>

                <b-col md="1">
                  <b-btn variant="primary" href="#" style="width: auto;">GO</b-btn>
                </b-col>

                <b-col md="6">                  
                  <b-form-select v-model="re_selected" :options="recent_event">
                  </b-form-select>
                </b-col>
              </b-row>
            </b-col>
            
            <b-col>
              <b-row>
                <b-col md="5">
                  Evènements anciens :
                </b-col>

                <b-col md="1">  
                  <b-btn variant="success" href="#" style="width: auto;">GO</b-btn>
                </b-col>

                <b-col md="6">                  
                  <b-form-select v-model="oe_selected" :options="old_event">
                  </b-form-select>
                </b-col>
              </b-row>
            </b-col>
        </b-row>
        <b-row>
            <b-col><b-btn variant="primary" href="#">Créer un évènement</b-btn></b-col>
            <b-col><b-btn variant="success" href="#">calendrier</b-btn></b-col>
        </b-row>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import UserApiService from "../services/AuthService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";

export default {
  //*********STATE*********
  //The state, which is the source of truth that drives our app;
  data() {
    return {
    re_selected: null,
    recent_event: [
      { value: null, text: 'Please select an option' },
      { value: 'a', text: 'This is First option' },
      { value: 'b', text: 'Selected Option' },
      { value: {'C':'3PO'}, text: 'This is an option with object value' },
      { value: 'd', text: 'This one is disabled', disabled: true }
    ],

    oe_selected: null,
    old_event: [
      { value: null, text: 'Please select an option' },
      { value: 'a', text: 'Not this one' },
      { value: 'b', text: 'Pls No' },
      { value: 'd', text: 'Ye this one'}
    ],

      userEmail: null
    };
  },

  ///******ACTION********
  //The actions, which are the possible ways the state could change in reaction to user inputs from the view.
  methods:{

  },

  
  computed: {
    ...mapGetters(["isLoading"]),
    auth: () => AuthService
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

.row {
  margin: 20px;
}

.btn {
  width: 100%;
}
</style>