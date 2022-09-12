import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView    },
    {
      path: '/report1',
      name: 'report1',
      component: () => import('../views/ReportByRequestView.vue')
    }
    ,
    {
      path: '/report2',
      name: 'report2',
      component: () => import('../views/ReportByCountryView.vue')
    }
  ]
})

export default router
