<template>
  <div class="sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <h2>Keepr</h2>

          <md-menu md-size="medium" md-align-trigger>
            <md-button md-menu-trigger class="md-icon-button md-raised">
              <i class="material-icons">person</i>
            </md-button>

            <md-menu-content>
              <md-menu-item @click="usernameButton" v-if="user.email">My Keeps</md-menu-item>
              <md-menu-item @click="vaultsView" v-if="user.email">My Vaults</md-menu-item>
              <md-menu-item @click="logoutNav" v-if="user.email">Logout</md-menu-item>
              <md-menu-item @click="loginNav" v-else>Login</md-menu-item>
            </md-menu-content>
          </md-menu>
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
    },
    vaultsView() {
      this.$store.dispatch("vaultsView");
    }
  },
  components: {}
};
</script>


<style scoped>
.sticky-top {
  position: sticky;
  background-color: #7ddc1f;
}
.form-inline {
  display: contents;
}
h2 {
  /* font-family: "ZCOOL XiaoWei", serif; */
  color: #2c2f33;
}
</style>