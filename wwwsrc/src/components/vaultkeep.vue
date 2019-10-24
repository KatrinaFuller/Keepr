<template>
  <div class="vaultkeep row">
    <div class="col-3 justify-content-start">
      <div class="card" style="width: 18rem;">
        <img class="img" v-bind:src="vaultkeepProp.img" alt="Keep Image" />
        <div class="card-body">
          <p>
            {{vaultkeepProp.name}}
            <span
              class="bg-light text-danger rounded px-1 ml-1 pb-1"
              @click="removeKeep(vaultkeepProp)"
            >x</span>
          </p>

          <button class="btn" @click="saveKeep()">
            <i class="fas fa-save"></i>
          </button>
          <button class="btn" @click="viewKeep(vaultkeepProp)">
            <i class="fas fa-eye"></i>
          </button>
          <div></div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaultkeep",
  props: ["vaultkeepProp", "vaultProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  mounted() {
    this.$store.dispatch("getVaultKeeps");
  },
  computed: {
    vaultkeeps() {
      return this.$store.state.vaultkeeps;
    }
  },
  methods: {
    viewKeep(vaultkeepProp) {
      this.$router.push({
        name: "activeKeep",
        params: { keepId: vaultkeepProp.id }
      });
      this.$store.dispatch("getKeepById", vaultkeepProp);
    },
    removeKeep(vaultkeepProp) {
      this.$store.dispatch("removeKeep", vaultkeepProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>