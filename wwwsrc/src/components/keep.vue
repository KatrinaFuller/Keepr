<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card shadow m-2" style="width: 18rem;">
        <img
          class="img shadow"
          v-bind:src="keepProp.img"
          alt="Keep Image"
          @click="viewKeep(keepProp)"
        />

        <span>
          <button
            v-if="user.username"
            class="btn"
            type="button"
            data-toggle="collapse"
            v-bind:data-target="`#save${id}`"
            :id="`saveButton${id}`"
          >
            <i class="material-icons">save</i>
          </button>

          <!-- profile page -->
          <button v-if="$route.name === 'profile'" class="btn" @click="removeKeep(keepProp)">
            <i class="material-icons">delete</i>
          </button>

          <!-- in a vault -->
          <button
            v-if="$route.name === 'activeVault'"
            class="btn"
            @click="removeVaultKeepRelationship()"
          >
            <i class="material-icons">delete</i>
          </button>
        </span>
        <div>
          <!-- dropdown  -->
          <div class="collapse" v-bind:id="`save${id}`">
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
</template>


<script>
export default {
  name: "keep",
  props: ["keepProp", "vaultProp"],
  data() {
    return {
      newVaultId: "",
      id: null
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
    this.id = this._uid;
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.user;
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
    removeKeep(keepProp) {
      this.$store.dispatch("removeKeep", keepProp.id);
    },
    removeVaultKeepRelationship() {
      let payload = {
        keepId: this.keepProp.id,
        vaultId: this.$route.params.vaultId
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
      const dropdrown = document.getElementById(`save${this.id}`);
      dropdrown.classList.remove("show");
    }
  },
  components: {}
};
</script>


<style scoped>
.material-icons {
  color: black;
}
.img {
  width: 100%;
  height: 16rem;
  display: block;
}
</style>