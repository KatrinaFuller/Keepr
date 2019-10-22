<template>
  <div class="keep row">
    <div class="col-3 justify-content-start">
      <div class="card" style="width: 18rem;" v-for="keep in keeps" :key="keep.id">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <img class="img" v-bind:src="`${keep.img}`" alt="Keep Image" />
        <div class="card-body">
          <p>
            {{keep.name}}
            <span
              class="bg-light text-danger rounded px-1 ml-1 pb-1"
              @click="removeKeep(keep)"
            >x</span>
          </p>

          <!-- <p class="card-text">{{keep.description}} keep description</p> -->
          <button class="btn" @click="saveKeep(keep)">
            <i class="fas fa-save"></i>
          </button>
          <button class="btn" @click="viewKeep(keep)">
            <i class="fas fa-eye"></i>
          </button>
          <div>
            <!-- dropdown  -->
            <select v-model="newVaultId" @change="moveKeep(keep)">
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
  props: ["keepsProp"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    viewKeep(keep) {
      this.$router.push({
        name: "activeKeep"
      });
      this.$store.dispatch("getKeepById", keep);
    },
    saveKeep(keep) {},
    removeKeep(keep) {
      this.$store.dispatch("removeKeep", keep.id);
    },
    moveKeep(keep) {}
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