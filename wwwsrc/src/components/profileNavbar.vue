<template>
  <div class="row sticky-top">
    <div class="col-12">
      <nav class="profileNavbar">
        <form class="form-inline">
          <button class="btn" type="button" @click="backButton">Back</button>
          <h3>{{user.username}}'s Dashboard</h3>
          <button class="btn" type="button" @click="logoutNav">Logout</button>
        </form>
      </nav>
    </div>
  </div>
</template>


<script>
export default {
  name: "profileNavbar",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logoutNav() {
      this.$store.dispatch("logoutNav");
    },
    backButton() {
      debugger;
      this.$store.dispatch("backButton");
    }
  },
  components: {}
};
</script>


<style scoped>
.sticky-top {
  position: sticky;
  background-color: wheat;
}
.form-inline {
  display: contents;
}
</style>