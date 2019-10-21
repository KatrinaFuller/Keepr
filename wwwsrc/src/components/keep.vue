<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card" style="width: 18rem;">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <img src="http://placehold.it/200x200" alt="Keep Image" />
        <div class="card-body">
          <p class="card-text">{{keeps.description}}</p>
          <button class="btn">
            <i class="fas fa-save"></i>
          </button>
          <button class="btn" @click="viewKeep()">
            <i class="fas fa-eye"></i>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  data() {
    return {};
  },
  mounted() {
    // debugger;
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      // debugger;
      return this.$store.state.keeps;
    }
  },
  methods: {
    viewKeep() {
      // debugger;
      this.$router.push({
        name: "activeKeep",
        params: { Keep }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>