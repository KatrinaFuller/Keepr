<template>
  <div class="keep row">
    <div class="col-3 justify-content-start">
      <div class="card" style="width: 18rem;">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <img class="img" v-bind:src="keepProp.img" alt="Keep Image" />
        <div class="card-body">
          <p>
            {{keepProp.name}}
            <span
              class="bg-light text-danger rounded px-1 ml-1 pb-1"
              @click="removeKeep(keepProp)"
            >x</span>
          </p>

          <!-- <p class="card-text">{{keep.description}} keep description</p> -->
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
              <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
            </select>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    // keeps() {
    //   return this.$store.state.keeps;
    // },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    viewKeep(keep) {
      this.$router.push({
        name: "activeKeep",
        params: { keepId: keep.id }
      });
      this.$store.dispatch("getKeepById", keep);
    },
    saveKeep(keep) {},
    removeKeep(keep) {
      this.$store.dispatch("removeKeep", keep.id);
    },
    saveKeep() {
      //need to be able to select a keep
      //needs the keeps id
      //need the id of the optional vaults the keep can be saved to
      // debugger;
      // let payload = {
      //   keepId: keeps
      //   vaultId: this.$store.state.vaults,
      //   newVaultId: this.keeps.vaultId
      // };
      this.$store.dispatch("saveKeep", payload);
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