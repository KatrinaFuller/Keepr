<template>
  <div class="home container-fluid">
    <navbar />
    <keep />
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
  components: { navbar, keep },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>