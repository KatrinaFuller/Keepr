<template>
  <div class="container-fluid">
    <div class="row">
      <div class="activeKeep">
        <button class="btn" type="button" @click="backToProfile">Back to Profile</button>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h1>{{keep.name}}</h1>
      </div>
      <div class="col-12">
        <img v-bind:src="`${keep.img}`" />
      </div>
      <div class="col-12">
        <h4>{{keep.description}}</h4>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "activeKeep",
  data() {
    return {};
  },
  mounted() {
    // debugger;
    this.$store.dispatch("getKeepById");
  },
  computed: {
    keep() {
      // debugger;
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    backToProfile() {
      this.$store.dispatch("backToProfile");
    }
  },
  components: {}
};
</script>


<style scoped>
</style>