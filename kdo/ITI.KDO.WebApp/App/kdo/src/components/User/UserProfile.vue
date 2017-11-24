<template>
    <div>
        <img :src="item.photo" /> <br />
        {{auth.email}} <br />
        {{item.firstName}} <br />
        {{item.lastName}} <br />
        {{item.birthdate}} <br />
        {{item.phone}} <br />
        <router-link :to="`/userProfile/edit`">Edit profile</router-link>
        <a href="#" @click="modifyPassword()">Modify Password</a>
    </div>
</template>
<script>
    import AuthService from "../../services/AuthService";
    import UserApiService from "../../services/UserApiService";
    import { mapGetters, mapActions } from "vuex";
    import "../../directives/requiredProviders";
    import Vue from 'vue';
    import Vuex from 'vuex';

    export default {
        data() {
            return {
                userEmail: null,
                item: {}
            };
        },

        computed: {
            ...mapGetters(["isLoading"]),
            auth: () => AuthService
        },

        async mounted() {
            var userEmail = AuthService.emailUser();
            this.item = await UserApiService.getUserAsync(userEmail);
        },

        methods: {
            modifyPassword(){
                AuthService.modifyPassword();
            },
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
    @import "../../styles/global.less";
</style>