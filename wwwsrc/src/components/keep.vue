<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card" style="width: 18rem;" v-for="keep in keeps" :key="keep.id">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <img v-bind:src="`${keep.img}`" alt="Keep Image" />
        <div class="card-body">
          <p>{{keep.name}}</p>
          <!-- <p class="card-text">{{keep.description}} keep description</p> -->
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
    viewKeep() {
      // debugger;
      this.$router.push({
        name: "activeKeep",
        params: { keepId: this.keeps.keepId }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>