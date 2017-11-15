<template>
   <h1>This is default app.</h1>
   
</template>
<script>
    import MyAlert from './MyAlert.vue';
    import AuthService from "../services/AuthService";

    export default {
        components: {
            MyAlert
        },

        data() {
            return {
                message: '',
                date: '',
                numbers: [],
                counter: 0,
                firstName: '',
                buttonClass: 'btn-primary'
            }
        },

        computed: {
            incrementedFirstName() {
                return this.counter + this.firstName;
            },

            showText() {
                return this.message != '' && this.date != '';
            }
        },

        methods: {
            
            changeText() {
                this.message = "Cette application est réalisée à l'aide du framework Vue 2.0 RC";
            },

            changeDate() {
                this.date = "19/04/2017";
            },

            changeAll() {
                this.changeText();
                this.changeDate();
            },

            increment() {
                this.numbers.push(this.counter);
                this.counter++;
            },

            resetFirstName() {
                this.firstName = '';
            },

            changeClass() {
                this.buttonClass = 'btn-warning';
            }
        }
    }
</script>
<style lang="less">

</style>