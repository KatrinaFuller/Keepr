<template>
  <div class="container-fluid">
    <div class="row">
      <div class="activeVault">
        <button class="btn" type="button" @click="backToProfile">Back to Profile</button>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h1>{{vault.name}}</h1>
        <h5>{{vault.description}}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-3">
        <keep v-for="keep in vaultkeeps" :keepProp="keep" :key="keep.id" />
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
    return {
      activeVault: this.$store.state.activeVault
    };
  },
  mounted() {
    this.$store.dispatch("getKeepsByVault", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultkeeps() {
      return this.$store.state.vaultkeeps;
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