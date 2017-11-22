<!--**********VUE**************-->
<!--The view, which is just a declarative mapping of the state;-->
<template>
  <div>
    <b-row class="bg-dark" style="height: 100%; margin-top: 0px; margin-bottom: 0px;">
      <b-col md="2" class="bg-dark" style="height:100%;">
        <nav id="bd-docs-nav" class="bd-links navbar-collapse collapse show" style="padding-top: 30px">
          <b-collapse id="collapse1" class="mt-2">
            <b-card  bg-variant="light" text-variant="dark">
              <p class="card-text">
                mail :<br/>
                {{auth.email}}<br/>
                firstName :<br/>
                {{item.firstName}}<br/>
                lastname :<br/>
                {{item.lastName}}<br/>
                birthdate :<br/>
                {{item.birthdate}}<br/>
                phone :<br/>
                {{item.phone}}<br/>
              </p>
              <b-button href="/Home/profile/edit" variant="primary">Edit profile</b-button>
            </b-card>
          </b-collapse>

          <b-nav-item variant="dark" href="#">Créer un évènement</b-nav-item>
          <b-nav-item variant="dark" href="#">Mes contacts</b-nav-item>
          <b-nav-item variant="dark" href="#">Calendrier</b-nav-item>
          <b-nav-item variant="dark" href="#">Ma liste de cadeau</b-nav-item>
        </nav>
      </b-col>

      <b-col md="8" class="bg-light">

        <b-carousel id="friend_carousel"
                style="text-shadow: 1px 1px 2px #333; margin-top: 20px; margin-bottom: 20px;"
                controls
                indicators
                background="#ababab"
                :interval="0"
                img-width="1024"
                img-height="512"
                v-model="slide1"
                @sliding-start="onSlideStart1"
                @sliding-end="onSlideEnd1">

          <b-carousel-slide img-blank img-alt="Blank image">
            <b-row>
              <b-col md="4">
                <b-card title="Bulbizar"
                      img-src="https://img4.hostingpics.net/pics/518638Image1.png"
                      img-alt="Image"
                      img-top
                      tag="article"
                      style="max-width: 16rem;"
                      class="mb-2">
                <p class="card-text">
                  Some quick example text to build on the card title and make up the bulk of the card's content.
                </p>
                <b-button href="#" variant="primary">Go</b-button>
                </b-card>
              </b-col>

              <b-col md="4">
                <b-card title="Salamèche"
                      img-src="https://img4.hostingpics.net/pics/211052Image2.png"
                      img-alt="Image"
                      img-top
                      tag="article"
                      style="max-width: 16rem;"
                      class="mb-2">
                <p class="card-text">
                  Some quick example text to build on the card title and make up the bulk of the card's content.
                </p>
                <b-button href="#" variant="primary">Go</b-button>
                </b-card>
              </b-col>

              <b-col md="4">
                <b-card title="Carapuce"
                      img-src="https://img4.hostingpics.net/pics/527500Image3.png"
                      img-alt="Image"
                      img-top
                      tag="article"
                      style="max-width: 16rem;"
                      class="mb-2">
                <p class="card-text">
                  Some quick example text to build on the card title and make up the bulk of the card's content.
                </p>
                <b-button href="#" variant="primary">Go</b-button>
                </b-card>
              </b-col>
            </b-row>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <!-- Slide with blank fluid image to maintain slide aspect ratio -->
          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

        </b-carousel>

        <!--b-carousel id="event_carousel"
                style="text-shadow: 1px 1px 2px #333;"
                controls
                indicators
                background="#ababab"
                :interval="0"
                img-width="1024"
                img-height="256"
                v-model="slide2"
                @sliding-start="onSlideStart2"
                @sliding-end="onSlideEnd2">

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>

          <b-carousel-slide img-blank img-alt="Blank image">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
              eros felis, tincidunt a tincidunt eget, convallis vel est. Ut pellentesque
              ut lacus vel interdum.
            </p>
          </b-carousel-slide>
        </b-carousel-->


        <!--b-row>
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
        </b-row-->
      </b-col>
    </b-row>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import UserApiService from "../services/UserApiService";
import { mapGetters, mapActions } from "vuex";
import "../directives/requiredProviders";

export default {
  //*********STATE*********
  //The state, which is the source of truth that drives our app;
  data() {
    return {
    userEmail: null,
    item: {},

    slide1: 0,
    slide2: 0,
    sliding: null,

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
    onSlideStart1(slide1) {
        this.sliding = true;
    },
    onSlideEnd1(slide1) {
        this.sliding = false;
    },
    onSlideStart2(slide2) {
        this.sliding = true;
    },
    onSlideEnd2(slide2) {
        this.sliding = false;
    }
  },

  async mounted() {
    var userEmail = AuthService.emailUser();
    this.item = await UserApiService.getUserAsync(userEmail);
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