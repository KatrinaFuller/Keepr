<template>
  <div class="container-fluid">
    <div class="profile">
      <profileNavbar />
      <div class="row">
        <addKeepModal />
        <button class="btn btn-primary" data-toggle="modal" data-target="#add-keep-modal">Add Keep</button>
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import profileNavbar from "../components/profileNavbar";
import addKeepModal from "../components/addKeepModal";

export default {
  name: "profile",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: { profileNavbar, addKeepModal }
};
</script>


<style scoped>
</style>