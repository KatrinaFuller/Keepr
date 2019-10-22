<template>
  <div class="vault row">
    <div class="col-3">
      <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault.vaults">
        <div class="card-body">
          <h4 @click="viewVault(vault)">{{vault.name}}</h4>
          <span class="bg-light text-danger rounded px-1 ml-1 pb-1" @click="removeVault(vault)">x</span>
          <p class="card-text">{{vault.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {
      // newVault: {
      //   name: "",
      //   description: "",
      //   userId: this.$store.state.user.id
      // }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      let vaults = this.$store.state.vaults;
      return vaults;
    }
  },
  methods: {
    viewVault(vault) {
      debugger;
      this.$router.push({
        name: "activeVault"
      });
      this.$store.dispatch("getVaultById", vault);
    },
    removeVault(vault) {
      this.$store.dispatch("removeVault", vault.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>