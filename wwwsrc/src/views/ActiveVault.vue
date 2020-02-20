<template>
  <div class="container-fluid bg">
    <div class="row">
      <div class="activeVault">
        <md-button class="md-icon-button">
          <i class="material-icons" @click="backButton">arrow_back</i>
        </md-button>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h1>{{vault.name}}</h1>
        <h5>{{vault.description}}</h5>
      </div>
    </div>
    <div class="row justify-content-center">
      <keep v-for="keep in vaultkeeps" :keepProp="keep" :key="keep.id" />
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
    backButton() {
      this.$store.dispatch("backButton");
    }
  },
  components: { keep }
};
</script>


<style scoped>
.bg {
  background-color: #f5f5f5;
  min-height: 100vh;
}
h1 {
  color: #d54c52;
}
</style>