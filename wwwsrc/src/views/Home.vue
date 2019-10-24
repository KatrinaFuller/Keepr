<template>
  <div class="home container-fluid">
    <navbar />
    <!-- <div class="row justify-content-center">
      <div class="col-2">
        <h1>Keepr</h1>
      </div>
    </div>-->
    <div class="row">
      <keep v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
    <!-- <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>-->
  </div>
</template>

<script>
import navbar from "../components/navbar";
import keep from "../components/keep";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  components: { navbar, keep },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style scoped>
</style>