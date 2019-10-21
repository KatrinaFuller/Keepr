<template>
  <div id="add-keep-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add Keep</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addKeep()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="keep name"
                placeholder="Enter name of keep"
                v-model="newKeep.name"
                required
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newKeep.description"
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="image"
                placeholder="Enter keep Image"
                v-model="newKeep.img"
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
  name: "add-keep-modal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    addKeep() {
      debugger;
      this.$store.dispatch("addKeep", this.newKeep);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>