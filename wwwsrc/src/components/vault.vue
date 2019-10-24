<template>
  <div class="vault row">
    <div class="col-3">
      <div class="card" style="width: 18rem;">
        <div class="card-body">
          <h4 @click="viewVault(vaultProp)">{{vaultProp.name}}</h4>
          <span
            class="bg-light text-danger rounded px-1 ml-1 pb-1"
            @click="removeVault(vaultProp)"
          >x</span>
          <p class="card-text">{{vaultProp.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["vaultProp"],
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
    // vaults() {
    //   let vaults = this.$store.state.vaults;
    //   return vaults;
    // }
  },
  methods: {
    viewVault(vaultProp) {
      // debugger;
      this.$router.push({
        name: "activeVault",
        params: { vaultId: vaultProp.id }
      });
      this.$store.dispatch("getVaultById", vaultProp);
      // debugger;
      // this.$store.dispatch("getKeepsByVault", vaultProp);
    },
    removeVault(vaultProp) {
      this.$store.dispatch("removeVault", vaultProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>