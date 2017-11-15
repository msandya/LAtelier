<template>
    <div>
        <img :src="item.photo" /> <br />
        {{auth.email}} <br />
        {{item.firstName}} <br />
        {{item.lastName}} <br />
        {{item.birthdate}} <br />
        {{item.phone}} <br />
        <router-link :to="`/profile/edit`">Edit profile</router-link>
    </div>
</template>
<script>
    import AuthService from "../services/AuthService";
    import $ from 'jquery'
    import { mapGetters, mapActions } from "vuex";
    import "../directives/requiredProviders";
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
            this.item = await AuthService.getUserAsync(userEmail);
        },

        methods: {
            login() {
                this.$router.replace('/login');
            },

            register() {
                AuthService.register();
            }
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
</style>