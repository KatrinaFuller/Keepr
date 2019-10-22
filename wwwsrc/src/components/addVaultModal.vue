<template>
  <div id="add-vault-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add Vault</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addVault()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="keep name"
                placeholder="Enter name of vault"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newVault.description"
              />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "add-vault-modal",
  data() {
    return {
      newVault: {
        userId: this.$store.state.user.id
      }
    };
  },
  computed: {},
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>