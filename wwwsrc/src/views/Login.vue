<template>
  <div class="container-fluid bg">
    <div class="row">
      <div class="col">
        <h1 class="my-5">Keepr</h1>
      </div>
    </div>
    <div class="login my-3">
      <form v-if="loginForm" @submit.prevent="loginUser">
        <input class="m-1" type="email" v-model="creds.email" placeholder="email" />
        <input class="m-1" type="password" v-model="creds.password" placeholder="password" />
        <button class="btn m-2" type="submit">Login</button>
      </form>
      <form v-else @submit.prevent="register">
        <input class="m-1" type="text" v-model="newUser.username" placeholder="name" />
        <input class="m-1" type="email" v-model="newUser.email" placeholder="email" />
        <input class="m-1" type="password" v-model="newUser.password" placeholder="password" />
        <button class="btn m-2" type="submit">Create Account</button>
      </form>
      <div @click="loginForm = !loginForm">
        <p v-if="loginForm">No account Click to Register</p>
        <p v-else>Already have an account click to Login</p>
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
.btn {
  background-color: #7ddc1f;
}
</style>