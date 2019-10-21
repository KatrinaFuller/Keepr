<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card" style="width: 18rem;">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <img src="http://placehold.it/200x200" alt="Keep Image" />
        <div class="card-body">
          <p class="card-text">Keep Name</p>
          <button class="btn">
            <i class="fas fa-save"></i>
          </button>
          <button class="btn">
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
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>