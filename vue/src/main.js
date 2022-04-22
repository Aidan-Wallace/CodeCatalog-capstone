import Vue from "vue";
import App from "./App";
import router from "./router/index";
import store from "./store/index";

// Additional packages
import axios from "axios";
import VueClipboard from "vue-clipboard2";

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;
Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
})
  .use(VueClipboard)
  .$mount("#app");
