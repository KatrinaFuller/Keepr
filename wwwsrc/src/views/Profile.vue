<template>
  <div class="container-fluid">
    <div class="profile">
      <profileNavbar />
      <div class="row">
        <addKeepModal />
        <button class="btn btn-primary" data-toggle="modal" data-target="#add-keep-modal">Add Keep</button>
        <addVaultModal />
        <button class="btn btn-primary" data-toggle="modal" data-target="#add-vault-modal">Add Vault</button>
      </div>
      <div class="row">
        <div class="col-6">
          <keepsList />
          <keep v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
        </div>
        <div class="col-6">
          <vaultsList />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import profileNavbar from "../components/profileNavbar";
import addKeepModal from "../components/addKeepModal";
import addVaultModal from "../components/addVaultModal";
import keepsList from "../components/keepsList";
import keep from "../components/keep";
import vaultsList from "../components/vaultsList";

export default {
  name: "profile",
  data() {
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {},
  components: {
    profileNavbar,
    addKeepModal,
    addVaultModal,
    keep,
    keepsList,
    vaultsList
  }
};
</script>


<style scoped>
</style>