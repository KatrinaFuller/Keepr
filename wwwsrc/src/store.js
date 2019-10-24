import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

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
    vaults: [],
    activeVault: {},
    vaultkeeps: [],
    userKeeps: []
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
      state.keeps = keeps
    },
    setUserKeeps(state, userkeeps) {
      state.userKeeps = userkeeps
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setActiveVault(state, payload) {
      state.activeVault = payload
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps
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
    backToProfile() {
      router.push({ name: "profile" })
    },

    getKeeps({ commit }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    getUserKeeps({ commit }) {
      api.get('keeps/user')
        .then(res =>
          commit('setUserKeeps', res.data))
    },

    getVaults({ commit }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    getVaultKeeps({ commit }) {
      api.get('vaultkeeps')
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },

    async addKeep({ commit, dispatch }, data) {
      try {
        let res = await api.post('/keeps', data)
        dispatch("getKeeps");
        dispatch("getUserKeeps");
      } catch (error) {
        console.error("store.js addKeep")
      }
    },
    async addVault({ commit, dispatch }, data) {
      try {
        let res = await api.post('/vaults', data);
        dispatch("getVaults");
      } catch (error) {
        console.error("store.js addVault")
      }
    },

    async addVaultKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post('/vaultkeeps', payload)
        dispatch("getVaults")
        dispatch("getKeeps")
      } catch (error) {
        console.error("store.js addVaultKeep")
      }
    },

    async getKeepById({ commit }, keep) {
      try {
        let res = await api.get(`/keeps/${keep.id}`)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.error("store.js getKeepById")
      }
    },


    async getVaultById({ commit }, payload) {
      try {
        let res = await api.get(`/vaults/${payload.id}`)
        commit("setActiveVault", res.data)
      } catch (error) {
        console.error("store.js getVaultById")
      }
    },
    async removeKeep({ dispatch }, data) {
      try {
        let res = await api.delete('/keeps/' + data)
        dispatch('getKeeps')
      } catch (error) {
        console.error("store.js removeKeep")
      }
    },

    async removeVault({ dispatch }, data) {
      try {
        let res = await api.delete('/vaults/' + data)
        dispatch('getVaults')
      } catch (error) {
        console.error("store.js removeVault")
      }
    },

    async saveKeep({ dispatch }, payload) {
      try {
        let res = await api.put(`/vaultkeeps/`, payload)
        dispatch("getVaultKeeps", payload)
      } catch (error) {
        console.error("store.js saveKeep")
      }
    },
    async getVaultKeepsById({ commit }, payload) {
      try {
        let res = await api.get(`/vaultkeeps/${payload.vaultId}`)
        commit("setActiveVault", { keepId: payload.keepId, vault: res.data, keepProp: payload.keepProp })
      } catch (error) {
        console.error("store.js getVaultById")
      }
    },

    async getKeepsByVault({ commit }, payload) {
      try {
        let res = await api.get(`/vaultkeeps/${payload}`)
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.error("store.js getKeepsByVault")
      }
    }

  }
})
