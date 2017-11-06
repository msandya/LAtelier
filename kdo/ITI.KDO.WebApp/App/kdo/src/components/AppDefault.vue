<template>
    <div class="jumbotron">
        <h1>Bienvenue sur ITI.PrimarySchool</h1>
        <p>
            <a class="btn btn-primary btn-lg" href="http://vuejs.org/v2/guide/" role="button">Guide Vue 2.0</a>
            <a class="btn btn-primary btn-lg" href="http://vuejs.org/v2/api/" role="button">Documentation API Vue 2.0</a>
        </p>
    </div>
</template>
<script>
    import MyAlert from './MyAlert.vue';

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