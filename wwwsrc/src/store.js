import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeKeep: {},
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, keeps) {
      // debugger
      state.keeps = keeps
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload
    },
    setVaults(state, vaults) {
      // debugger
      state.vaults = vaults
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async loginNav() {
      try {
        router.push({ name: "login" })
      } catch (error) {
        console.error(error)
      }
    },

    async logoutNav({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    usernameButton() {
      router.push({ name: "profile" })
    },
    backButton() {
      router.push({ name: "home" })
    },

    getKeeps({ commit }) {
      // debugger
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    getVaults({ commit }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },

    async addKeep({ commit }, data) {
      try {
        // debugger
        let res = await api.post('/keeps', data)
        commit('setKeeps', res.data)
      } catch (error) {
        console.error("store.js addKeep")
      }
    },

    async getKeepById({ commit }, payload) {
      try {
        // debugger
        let res = await api.get(`/keeps/${payload._id}`, payload)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.error("store.js getKeepById")
      }
    },

    async addVault({ commit }, data) {
      try {
        // debugger
        let res = await api.post('/vaults', data)
        commit('setVaults', res.data)
      } catch (error) {
        console.error("store.js addVault")
      }
    },

  }
})
