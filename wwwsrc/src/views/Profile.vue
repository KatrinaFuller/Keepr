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
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import profileNavbar from "../components/profileNavbar";
import addKeepModal from "../components/addKeepModal";
import addVaultModal from "../components/addVaultModal";

export default {
  name: "profile",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: { profileNavbar, addKeepModal, addVaultModal }
};
</script>


<style scoped>
</style>