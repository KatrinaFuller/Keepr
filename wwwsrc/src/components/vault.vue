<template>
  <div class="vault row">
    <div class="col-3">
      <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault.vaults">
        <div class="card-body" @click="viewVault()">
          <h4>
            {{vault.name}}
            <span
              class="bg-light text-danger rounded px-1 ml-1 pb-1"
              @click="removeVault(vault)"
            >x</span>
          </h4>
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
    // viewVault() {
    //   // debugger;
    //   this.$router.push({
    //     name: "activeVault",
    //     params: { vaultId: this.vault }
    //   });
    // },
    removeVault(vault) {
      this.$store.dispatch("removeVault", vault.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>