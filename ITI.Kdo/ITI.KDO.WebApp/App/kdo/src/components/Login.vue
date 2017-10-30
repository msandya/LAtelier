<template>
    <div>
        <div class="text-center">
            <div class="page-header">
                <h1>Bienvenue sur ITI.KDO</h1>
            </div>
        </div>
    </div>
</template>

<script>
    import AuthService from '../services/AuthService'
    import Vue from 'vue'
    import $ from 'jquery'

    export default {
        data() {
            return {
                endpoint: null
            }
        },

        mounted() {
            AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
        },

        beforeDestroy() {
            AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
        },

        methods: {
            login(provider) {
                AuthService.login(provider);
            },

            onAuthenticated() {
                 this.$router.replace('/');
            }
        }
    }
</script>

<style lang="less">
    iframe {
        width: 100%;
        height: 600px;
    }
</style>