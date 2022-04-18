import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Vue from "vue";
import App from "./App.vue";
import router from "./router/index";
import store from "./store/index";
import axios from "axios";
import VueClipboard from "vue-clipboard2";

// import "highlight.js/styles/stackoverflow-light.css";
// import "highlight.js/lib/common";
// import hljsVuePlugin from "@/plugins/vue-plugin";

Vue.use(VueClipboard);

Vue.config.productionTip = false;

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
