<template>
  <div class="vault row">
    <div class="col-3 m-2">
      <div class="card shadow" style="width: 18rem;">
        <div class="card-body">
          <div class="row justify-content-end">
            <div class="col-1 delete">
              <span
                class="bg-light text-danger rounded px-1 ml-1 pb-1"
                @click="removeVault(vaultProp)"
              >x</span>
            </div>
          </div>
          <div class="row">
            <div class="col-12">
              <h3 @click="viewVault(vaultProp)">{{vaultProp.name}}</h3>
            </div>
            <div class="col-12">
              <p class="card-text">{{vaultProp.description}}</p>
            </div>
          </div>

          <!-- <button class="btn" @click="removeVault(vaultProp)">
            <i class="fas fa-trash-alt"></i>
          </button>-->
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {},
  methods: {
    viewVault(vaultProp) {
      this.$router.push({
        name: "activeVault",
        params: { vaultId: vaultProp.id }
      });
      this.$store.dispatch("getVaultById", vaultProp);
    },
    removeVault(vaultProp) {
      this.$store.dispatch("removeVault", vaultProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
.delete {
  margin-right: 18px;
}
.card {
  height: 10rem;
}
.card:hover {
  transform: scale(0.9, 0.9);
  box-shadow: 5px 5px 30px 15px rgba(0, 0, 0, 0.25),
    -5px -5px 30px 15px rgba(0, 0, 0, 0.22);
  cursor: pointer;
}
</style>