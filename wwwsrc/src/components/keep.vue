<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card shadow m-2" style="width: 18rem;">
        <!-- <div class="card shadow m-2"> -->
        <img class="img" v-bind:src="keepProp.img" alt="Keep Image" />
        <div class="card-body">
          <p>
            {{keepProp.name}}
            <!-- <span
              class="bg-light text-danger rounded px-1 ml-1 pb-1"
              @click="removeKeep(keepProp)"
            >x</span>-->
          </p>

          <button class="btn" type="button" data-toggle="collapse" data-target="#collapseSave">
            <i class="fas fa-save"></i>
          </button>
          <button class="btn" @click="viewKeep(keepProp)">
            <i class="fas fa-eye"></i>
          </button>
          <!-- profile page -->
          <button v-if="$route.name === 'profile'" class="btn" @click="removeKeep(keepProp)">
            <i class="fas fa-trash-alt"></i>
          </button>
          <!-- home page -->

          <!-- in a vault -->
          <button
            v-if="$route.name === 'activeVault'"
            class="btn"
            @click="removeVaultKeepRelationship()"
          >
            <i class="fas fa-trash-alt"></i>
          </button>
          <div>
            <!-- dropdown  -->
            <div class="collapse" id="collapseSave">
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
    </div>
  </div>
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
      // debugger;
      this.$store.dispatch("removeKeep", keepProp.id);
    },
    removeVaultKeepRelationship() {
      debugger;
      let payload = {
        keepId: this.keepProp.id,
        vaultId: this.$route.params.vaultId
        // userId: this.$store.state.user.id
      };
      this.$store.dispatch("removeVaultKeepRelationship", payload);
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
/* .img {
  max-height: 30vh;
  max-width: 35vw;
} */
.img {
  width: 100%;
  height: auto;
}
</style>