<template>
  <div class="container-fluid bg">
    <div class="profile">
      <profileNavbar />
      <div class="row">
        <addKeepModal />
        <addVaultModal />
        <!-- add button -->
        <button class="btn m-1" type="button" data-toggle="collapse" data-target="#collapseAdd">
          <i class="fas fa-plus"></i>
        </button>
      </div>
      <div class="row">
        <!-- add keep or add vault -->
        <div class="collapse" id="collapseAdd">
          <button class="btn m-1" data-toggle="modal" data-target="#add-keep-modal">Add Keep</button>
        </div>
      </div>
      <div class="row">
        <div class="collapse" id="collapseAdd">
          <button class="btn m-1" data-toggle="modal" data-target="#add-vault-modal">Add Vault</button>
        </div>
      </div>
      <div class="row">
        <!-- <div class="col-3"> -->
        <div class="col-12">
          <h3>Keeps</h3>
        </div>
        <keep v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
        <!-- </div> -->
      </div>
      <div class="row">
        <!-- <div class="col-6"> -->
        <div class="col-12">
          <h3>Vaults</h3>
        </div>
        <vault v-for="vault in vaults" :key="vault.vaults" :vaultProp="vault" />
        <!-- </div> -->
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import profileNavbar from "../components/profileNavbar";
import addKeepModal from "../components/addKeepModal";
import addVaultModal from "../components/addVaultModal";
import keep from "../components/keep";
import vaultsList from "../components/vaultsList";
import vault from "../components/vault";

export default {
  name: "profile",
  data() {
    return {};
  },
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
    addVaultModal,
    keep,
    vault,
    vaultsList
  }
};
</script>


<style scoped>
.bg {
  background-color: #e9f4f1;
  min-height: 100vh;
}
h3 {
  color: #48897a;
}
</style>