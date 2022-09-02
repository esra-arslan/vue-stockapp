import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '../views/HomeView.vue'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },


    {
      path: '/stock',
      name: 'stock',
      component: () => import('../views/stock/addIndex.vue')
    },

    {
      path: '/order',
      name: 'order',
      component: () => import('../views/stock/orderIndex.vue')
    },

    {
      path: '/hamper',
      name: 'hamper',
      component: () => import('../views/hamper.vue')
    },

  ]
})

export default router
