<template>
  <div class="keep row">
    <div class="col-3">
      <div class="card" style="width: 18rem;">
        <!-- <img class="card-img-top" v-bind:src="`${keep.Img}`" alt="keep image" /> -->
        <div class="card-body">
          <p class="card-text">{{Keep.Description}}</p>
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