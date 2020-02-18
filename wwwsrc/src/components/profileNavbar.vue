<template>
  <div class="row sticky-top">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <md-button class="md-icon-button">
            <i class="material-icons" @click="backButton">arrow_back</i>
          </md-button>
          <h2>{{user.username}}'s Dashboard</h2>
          <!-- <button class="btn" type="button" @click="logoutNav">Logout</button> -->
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
    backButton() {
      this.$store.dispatch("backButton");
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
h2 {
  font-family: "ZCOOL XiaoWei", serif;
}
</style>