<template>
  <div class="vault row">
    <div class="col-3">
      <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault">
        <div class="card-body" @click="viewVault()">
          <h4>{{vault.name}}</h4>
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
      newVault: {
        name: "",
        description: "",
        userId: this.$store.state.user.id
      }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      debugger;
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>