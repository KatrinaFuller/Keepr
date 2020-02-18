<template>
  <div class="container-fluid bg">
    <div class="row">
      <div class="activeKeep">
        <md-button class="md-icon-button">
          <i class="material-icons" @click="backButton">arrow_back</i>
        </md-button>
      </div>
    </div>
    <div class="row">
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
    <div class="row">
      <div class="col"></div>
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
  background-color: #e9f4f1;
  min-height: 100vh;
}
.btn {
  background-color: #96ead7;
}
/* .img {
  max-height: 30vh;
  max-width: 35vw;
} */
.img {
  max-width: 60%;
}
h1 {
  color: #48897a;
}
</style>