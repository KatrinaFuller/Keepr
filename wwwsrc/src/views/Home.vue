<template>
  <div class="home container-fluid bg">
    <navbar />
    <div class="row justify-content-center">
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
.bg {
  background-color: #f5f5f5;
  min-height: 100vh;
}
h1 {
  font-family: "ZCOOL XiaoWei", serif;
}
</style>