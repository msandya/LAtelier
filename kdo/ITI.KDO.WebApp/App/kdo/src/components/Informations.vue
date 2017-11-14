<template>
    <div class="container">
        <div class="page-header">
            <h1>EDIT PROFILE</h1>
        </div>
        <form asp-controller="Account" asp-action="Register" method="post" @submit="onSubmit($event)">

            <div class="form-group">
                <label asp-for="Email">Email : </label>
                <input asp-for="Email" class="form-control" v-model="auth.email"/>
                <span asp-validation-for="Email"></span>
            </div>
            <div class="form-group">
                <label asp-for="FirstName">FirstName : </label>
                <input asp-for="FirstName" class="form-control" v-model="item.firstName"/>
                <span asp-validation-for="FirstName"></span>
            </div>
            <div class="form-group">
                <label asp-for="LastName">LastName : </label>
                <input asp-for="LastName" class="form-control" v-model="item.lastName"/>
                <span asp-validation-for="LastName"></span>
            </div>

            <div class="form-group">
                <label asp-for="Birthdate">BirthDate : </label>
                <input asp-for="Birthdate" class="form-control" v-model="item.birthdate"/>
                <span asp-validation-for="Birthdate"></span>
            </div>
            <div class="form-group">
                <label asp-for="Phone">Phone : </label>
                <input asp-for="Phone" class="form-control" v-model="item.phone"/>
                <span asp-validation-for="Phone"></span>
            </div>
            <div class="form-group">
                <label asp-for="Photo">Photo : </label>
                <input asp-for="Photo" class="form-control" v-model="item.photo"/> <br />
                <img :src="item.photo" />
                <span asp-validation-for="Photo"></span>
            </div>

            <input type="submit" class="btn btn-primary btn-block" value="Modifier"/>
        </form>
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
            async onSubmit(e) {
                await AuthService.updateUserAsync(this.item);
            }
        }
    }
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