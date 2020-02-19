<template>
  <div class="container-fluid bg">
    <div class="profile">
      <profileNavbar />
      <div class="row">
        <addKeepModal />
        <button class="btn btn-circle m-1" data-toggle="modal" data-target="#add-keep-modal">
          <i class="fas fa-plus"></i>
        </button>
      </div>

      <div class="row">
        <div class="col-12">
          <h3>Keeps</h3>
        </div>
        <keep v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import profileNavbar from "../components/profileNavbar";
import addKeepModal from "../components/addKeepModal";
import keep from "../components/keep";
import vaultsList from "../components/vaultsList";
import vault from "../components/vault";

export default {
  name: "profile",
  data() {
    return {};
  },
  // data: () => ({
  //   active: false,
  //   value: null
  // }),
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {
    profileNavbar,
    addKeepModal,
    keep,
    vault,
    vaultsList
  }
};
</script>


<style scoped>
.bg {
  background-color: #f5f5f5;
  min-height: 100vh;
}
.btn-circle {
  border-radius: 50%;
}
h3 {
  color: #2c2f33;
}
</style>