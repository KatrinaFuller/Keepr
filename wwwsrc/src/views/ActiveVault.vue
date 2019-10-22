<template>
  <div class="container-fluid">
    <div class="row">
      <div class="activeVault">
        <button class="btn" type="button" @click="backToProfile">Back to Profile</button>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <!-- <vault v-for="vault in vaults" :vault="vault" :key="vault._id" /> -->
        <!-- <h1>{{vault.name}}</h1> -->
        <!-- <h5>{{vault.description}}</h5> -->
      </div>
    </div>
  </div>
</template>


<script>
// import vault from "../components/vault";

export default {
  name: "activeVault",
  data() {
    return {};
  },
  // mounted() {
  //   // debugger;
  //   // let payload = {
  //   //   id: this.$route.params.vaultId
  //   // };
  //   this.$store.dispatch("getVaultById");
  // },
  computed: {
    vault() {
      // debugger;
      return this.$store.state.activeVault;
    }
  },
  methods: {
    backToProfile() {
      this.$store.dispatch("backToProfile");
    }
  },
  components: {}
};
</script>


<style scoped>
</style>