<template>
  <div class="container-fluid">
    <div class="vaults">
      <vaultsNavbar />
      <div class="col-12">
        <h3>Vaults</h3>
      </div>
      <vault v-for="vault in vaults" :key="vault.vaults" :vaultProp="vault" />
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import keep from "../components/keep";
import vaultsList from "../components/vaultsList";
import vault from "../components/vault";
import vaultsNavbar from "../components/vaultsNavbar";

export default {
  name: "vaults",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {
    keep,
    vault,
    vaultsList,
    vaultsNavbar
  }
};
</script>


<style scoped>
</style>