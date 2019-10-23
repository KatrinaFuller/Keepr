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
        <h1>{{vault.name}}</h1>
        <h5>{{vault.description}}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-3">
        <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
        <!-- <keep /> -->
      </div>
    </div>
  </div>
</template>


<script>
import keep from "../components/keep";

export default {
  name: "activeVault",
  props: ["keepProp"],
  data() {
    return {};
  },
  mounted() {
    debugger;
    this.$store.dispatch("getVaultWithKeepId", keepProp);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    backToProfile() {
      this.$store.dispatch("backToProfile");
    }
  },
  components: { keep }
};
</script>


<style scoped>
</style>