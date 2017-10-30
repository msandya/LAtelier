<template>
    <div class="jumbotron">
        <h1>Bienvenue sur ITI.KDO</h1>
        <p>
            {{ message }}
        </p>
        <p>
            {{ date }}
        </p>
        <p v-if="showText">
            Les deux textes sont affichés.
        </p>
        <button type="button" @click="changeAll()">Afficher le texte</button>
        <p>
            Compteur : {{ counter }}
            <br />
            <button type="button" @click="increment()">+1</button>
        </p>
        <ul>
            <li v-for="n of numbers">{{ n }}</li>
        </ul>
        <form>
            <label>Prénom : </label>
            <input type="text" v-model="firstName" />
            <button type="button" @click="resetFirstName()">Remettre à zéro</button>
        </form>
        {{ incrementedFirstName }}
        <button :class="buttonClass" class="btn btn-lg" type="button" @click="changeClass()">Un bouton</button>
        <p>
            <a class="btn btn-primary btn-lg" href="http://vuejs.org/v2/guide/" role="button">Guide Vue 2.0</a>
            <a class="btn btn-primary btn-lg" href="http://vuejs.org/v2/api/" role="button">Documentation API Vue 2.0</a>
        </p>
        <my-alert color="green" message="Ceci est une erreur"></my-alert>
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