import { createWebHistory, createRouter } from "vue-router";
import { RouteRecordRaw } from "vue-router";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    alias: "/home",
    name: "Home",
    component: () => import("./components/Home.vue"),
  },
 
  {
    path: "/department",
    name: "Department",
    component: () => import("./components/Department.vue"),
  },
  {
    path: "/employeecreate",
    name: "EmployeeCreate",
    component: () => import("./components/EmployeeCreate.vue"),
  },


  {
    path: "/location",
    name: "Location",
    component: () => import("./components/Location.vue"),
  },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;