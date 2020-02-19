<template>
  <div class="container-fluid bg">
    <div class="vaults">
      <vaultsNavbar />
      <div class="row">
        <addVaultModal />
        <button class="btn btn-circle m-1" data-toggle="modal" data-target="#add-vault-modal">
          <i class="fas fa-plus"></i>
        </button>
      </div>
      <div class="row justify-content-center">
        <div class="col-12">
          <h3>Vaults</h3>
        </div>
        <vault v-for="vault in vaults" :key="vault.vaults" :vaultProp="vault" />
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import keep from "../components/keep";
import vaultsList from "../components/vaultsList";
import vault from "../components/vault";
import vaultsNavbar from "../components/vaultsNavbar";
import addVaultModal from "../components/addVaultModal";

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
    vaultsNavbar,
    addVaultModal
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