<template>
  <div class="keepsList">
    <keep :keep="keep" />
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