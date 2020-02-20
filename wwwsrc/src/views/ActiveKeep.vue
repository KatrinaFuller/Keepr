<template>
  <div class="container-fluid bg">
    <div class="row">
      <div class="activeKeep">
        <md-button class="md-icon-button">
          <i class="material-icons" @click="backButton">arrow_back</i>
        </md-button>
      </div>
    </div>
    <div class="row align-items-center">
      <div class="col-12">
        <img class="img" v-bind:src="`${keep.img}`" />
      </div>
      <div class="col-12">
        <h1>{{keep.name}}</h1>
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
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    backButton() {
      this.$store.dispatch("backButton");
    }
  },
  components: {}
};
</script>


<style scoped>
.bg {
  background-color: #f5f5f5;
  min-height: 100vh;
}
.img {
  max-height: 28rem;
  max-width: 28rem;
}
.img {
  max-width: 60%;
}
h1 {
  color: #d54c52;
}
</style>