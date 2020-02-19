<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card shadow m-2" style="width: 18rem;">
        <!-- <div class="card" style="width: 18rem;">
        <md-card>
          <md-card-media>
            <md-ripple>
              <img
                class="img shadow"
                v-bind:src="keepProp.img"
                alt="Keep Image"
                @click="viewKeep(keepProp)"
              />
            </md-ripple>
          </md-card-media>

          <md-card-actions>
            <md-menu md-align-trigger>
              <md-button md-menu-trigger class="md-icon-button" v-if="user.username">
                <md-icon>save</md-icon>
              </md-button>
              <md-menu-content>
                <md-select v-model="newVaultId">
                  <md-option
                    v-for="vault in vaults"
                    :key="vault.id"
                    :value="vault.id"
                    :vaultProp="vault"
                    @click="saveKeep()"
                  >{{vault.name}}</md-option>
                </md-select>
              </md-menu-content>
            </md-menu>

            <md-button class="btn" v-if="$route.name === 'profile'" @click="removeKeep(keepProp)">
              <md-icon>delete</md-icon>
            </md-button>

            <md-button
              class="btn"
              v-if="$route.name === 'activeVault'"
              @click="removeVaultKeepRelationship()"
            >
              <md-icon>delete</md-icon>
            </md-button>
          </md-card-actions>
        </md-card>-->

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
            data-target="#collapseSave"
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
    this.$store.dispatch("getVaults");
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
/* .card:hover {
  transform: scale(0.9, 0.9);
  box-shadow: 5px 5px 30px 15px rgba(0, 0, 0, 0.25),
    -5px -5px 30px 15px rgba(0, 0, 0, 0.22);
  cursor: pointer;
} */
</style>