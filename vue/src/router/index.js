// Required imports
import Vue from "vue";
import Router from "vue-router";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";
import store from "../store/index";
// Added Views
import Home from "@/views/Home.vue";
import ExampleView from "@/views/ExampleView";
import DownloadView from "@/views/DownloadView";
import CatalogView from "@/views/CatalogView";
import SearchView from "@/views/SearchView";
import AddExampleView from "@/views/AddExampleView";
import FullScreenView from "@/views/FullScreenView";
import ManageProfileView from "@/views/ManageProfileView";

Vue.use(Router);

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
      meta: {
        requiresAuth: false,
      },
    },

    /*
     ** VIEW PATHS
     */
    {
      path: "/manageProfile",
      name: "ManageProfile",
      component: ManageProfileView,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/searchResults/:query",
      name: "searchResults",
      component: SearchView,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/viewExample/:example",
      name: "ViewExample",
      component: FullScreenView,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/addExample",
      name: "addExample",
      component: AddExampleView,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/example",
      name: "example",
      component: ExampleView,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/download",
      name: "download",
      component: DownloadView,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/catalog",
      name: "Catalog",
      component: CatalogView,
      meta: {
        requiresAuth: false,
      },
    },

    /*
     ** AUTHENTICATION ROUTES
     */
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
      },
    },
  ],
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
