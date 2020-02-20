<template>
  <div class="container-fluid bg">
    <div class="row">
      <div class="col">
        <h1 class="my-5">Keepr</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-5">
        <div v-if="loginForm" @submit.prevent="loginUser">
          <md-field>
            <label>Email</label>
            <md-input type="email" v-model="creds.email"></md-input>
          </md-field>
          <md-field>
            <label>Password</label>
            <md-input type="password" v-model="creds.password"></md-input>
          </md-field>
          <md-button class="md-raised button-color" type="submit" @click="loginUser">Login</md-button>
        </div>

        <div v-else @submit.prevent="register">
          <md-field>
            <label>Name</label>
            <md-input type="text" v-model="newUser.username"></md-input>
          </md-field>
          <md-field>
            <label>Email</label>
            <md-input type="email" v-model="newUser.email"></md-input>
          </md-field>
          <md-field>
            <label>Password</label>
            <md-input type="password" v-model="newUser.password"></md-input>
          </md-field>
          <md-button class="md-raised button-color" type="submit" @click="register">Create Account</md-button>
        </div>

        <div @click="loginForm = !loginForm">
          <p v-if="loginForm">No account? Click to Register</p>
          <p v-else>Already have an account? Click to Login</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "login",
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  beforeCreate() {
    if (this.$store.state.user.id) {
      this.$router.push({ name: "home" });
    }
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    }
  }
};
</script>

<style scoped>
.bg {
  background-color: #f5f5f5;
  min-height: 100vh;
}
h1 {
  font-family: "ZCOOL XiaoWei", serif;
  font-size: 9.5rem;
  color: #2c2f33;
}
.md-button.md-theme-default.md-raised:not([disabled]) {
  background-color: #7ddc1f;
}
</style>