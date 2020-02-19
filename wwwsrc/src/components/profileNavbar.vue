<template>
  <div class="row sticky-top">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn">
            <h4 @click="home">Keepr</h4>
          </button>
          <h2>{{user.username}}'s Dashboard</h2>
          <md-menu md-size="medium" md-align-trigger>
            <md-button md-menu-trigger class="md-icon-button md-raised">
              <i class="material-icons">person</i>
            </md-button>

            <md-menu-content>
              <md-menu-item>
                <md-button @click="vaultsView">My Vaults</md-button>
              </md-menu-item>
              <md-menu-item>
                <md-button @click="logoutNav">Logout</md-button>
              </md-menu-item>
            </md-menu-content>
          </md-menu>
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
    vaultsView() {
      this.$store.dispatch("vaultsView");
    },
    logoutNav() {
      this.$store.dispatch("logoutNav");
    },
    home() {
      this.$store.dispatch("home");
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