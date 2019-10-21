<template>
  <div class="keepsList border">
    <h1>Keeps List</h1>
    <keep />
  </div>
</template>


<script>
import keep from "../components/keep";

export default {
  name: "keepsList",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: { keep }
};
</script>


<style scoped>
</style>