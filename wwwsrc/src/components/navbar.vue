<template>
  <div class="sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn" type="button" @click="logoutNav" v-if="user.email">Logout</button>
          <button class="btn" type="button" @click="loginNav" v-else>Login</button>
          <h2>Keepr</h2>
          <button
            class="btn"
            type="button"
            @click="usernameButton"
            v-if="user.email"
          >Hello, {{user.username}}</button>
        </form>
      </nav>
    </div>
  </div>
</template>


<script>
export default {
  name: "navbar",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    loginNav() {
      this.$store.dispatch("loginNav");
    },
    logoutNav() {
      this.$store.dispatch("logoutNav");
    },
    usernameButton() {
      this.$store.dispatch("usernameButton");
    }
  },
  components: {}
};
</script>


<style scoped>
.sticky-top {
  position: sticky;
  background-color: #f8ebc3;
}
.form-inline {
  display: contents;
}
.btn {
  background-color: #96ead7;
}
</style>