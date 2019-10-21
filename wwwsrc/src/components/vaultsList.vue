<template>
  <div class="vaultsList border">
    <h1>Vaults list</h1>
    <vault :vault="vault" />
  </div>
</template>


<script>
import vault from "../components/vault";

export default {
  name: "vaultsList",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: { vault }
};
</script>


<style scoped>
</style>