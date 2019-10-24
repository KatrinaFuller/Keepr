<template>
  <!-- <div class="keep row"> -->
  <div class="col-3">
    <!-- <div class="card" style="width: 18rem;"> -->
    <div class="card" style="width: 18rem;">
      <img class="img" v-bind:src="keepProp.img" alt="Keep Image" />
      <div class="card-body">
        <p>
          {{keepProp.name}}
          <span
            class="bg-light text-danger rounded px-1 ml-1 pb-1"
            @click="removeKeep(keepProp)"
          >x</span>
        </p>

        <button class="btn" @click="saveKeep()">
          <i class="fas fa-save"></i>
        </button>
        <button class="btn" @click="viewKeep(keepProp)">
          <i class="fas fa-eye"></i>
        </button>
        <div>
          <!-- dropdown  -->
          <select v-model="newVaultId" @change="saveKeep()">
            <option disabled value>Move keep to:</option>
            <option
              v-for="vault in vaults"
              :key="vault.id"
              :value="vault.id"
              :vaultProp="vault"
            >{{vault.name}}</option>
          </select>
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>


<script>
export default {
  name: "keep",
  props: ["keepProp", "vaultProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    viewKeep(keepProp) {
      this.$router.push({
        name: "activeKeep",
        params: { keepId: keepProp.id }
      });
      this.$store.dispatch("getKeepById", keepProp);
    },
    saveKeep(keep) {},
    removeKeep(keepProp) {
      this.$store.dispatch("removeKeep", keepProp.id);
    },
    saveKeep() {
      let payload = {
        keepId: this.keepProp.id,
        vaultId: this.newVaultId,
        keepProp: this.keepProp
      };
      this.$store.dispatch("addVaultKeep", payload);
    }
  },
  components: {}
};
</script>


<style scoped>
.img {
  max-height: 30vh;
  max-width: 35vw;
}
</style>