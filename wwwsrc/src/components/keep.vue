<template>
  <div class="keep row">
    <div class="col-3">
      <!-- <div class="card shadow m-2 container" style="width: 18rem;"> -->
      <div class="container" style="width: 18rem;">
        <img class="img" v-bind:src="keepProp.img" alt="Keep Image" />
        <div class="overlay">
          <p>{{keepProp.name}}</p>

          <button
            v-if="user.username"
            class="btn"
            type="button"
            data-toggle="collapse"
            data-target="#collapseSave"
          >
            <i class="fas fa-save"></i>
          </button>

          <button v-if="user.username" class="btn" @click="viewKeep(keepProp)">
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
    saveKeep(keep) {},
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
    }
  },
  components: {}
};
</script>


<style scoped>
.fas {
  color: white;
}

* {
  box-sizing: border-box;
}

.container {
  position: relative;
  width: 50%;
  max-width: 300px;
}

.img {
  width: 100%;
  height: auto;
  display: block;
}

/* .card:hover {
  transform: scale(0.9, 0.9);
  box-shadow: 5px 5px 30px 15px rgba(0, 0, 0, 0.25),
    -5px -5px 30px 15px rgba(0, 0, 0, 0.22);
  cursor: pointer;
} */

/* The overlay effect - lays on top of the container and over the image */
.overlay {
  position: absolute;
  bottom: 0;
  background: rgb(0, 0, 0);
  background: rgba(0, 0, 0, 0.5); /* Black see-through */
  color: #f1f1f1;
  width: 100%;
  transition: 0.5s ease;
  opacity: 0;
  color: white;
  font-size: 20px;
  padding: 20px;
  text-align: center;
}

/* When you mouse over the container, fade in the overlay title */
.container:hover .overlay {
  opacity: 1;
}
</style>