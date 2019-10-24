<template>
  <div class="vault row">
    <div class="col-3 m-2">
      <div class="card shadow" style="width: 18rem;">
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
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {},
  methods: {
    viewVault(vaultProp) {
      this.$router.push({
        name: "activeVault",
        params: { vaultId: vaultProp.id }
      });
      this.$store.dispatch("getVaultById", vaultProp);
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