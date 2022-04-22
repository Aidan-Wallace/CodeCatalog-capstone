<template>
  <div id="app">
    <app-nav />
    <div class="router-view">
      <router-view />
    </div>
  </div>
</template>

<script>
import AppNav from "@/components/Navigation/AppNav";

export default {
  components: {
    AppNav,
  },
};
</script>

<style>
#app {
  height: 100vh;
}

.router-view {
  height: 100%;
  padding-top: 7vh;
}
</style>
