import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/profile',
      name: 'profile',
      component: function () {
        return import(/* webpackChunkName: "profile" */ './views/Profile.vue')
      }
    },
    {
      path: '/vaults',
      name: 'vaultsView',
      component: function () {
        return import(/* webpackChunkName: "profile" */ './views/Vaults.vue')
      }
    },
    {
      path: '/keeps/:keepId',
      name: 'activeKeep',
      component: function () {
        return import(/* webpackChunkName: "activeKeep" */ './views/ActiveKeep.vue')
      }
    }, {
      path: '/vaults/:vaultId',
      name: 'activeVault',
      component: function () {
        return import(/* webpackChunkName: "activeVault" */ './views/ActiveVault.vue')
      }
    }
  ]
})
