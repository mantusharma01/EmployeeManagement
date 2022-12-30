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
    path: "/employee",
    name: "Employee",
    component: () => import("./components/Employee.vue"),
  },
  {
    path: "/department",
    name: "Department",
    component: () => import("./components/Department.vue"),
  },
  {
    path: "/departmentpost",
    name: "DepartmentPost",
    component: () => import("./components/DepartmentPost.vue"),
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