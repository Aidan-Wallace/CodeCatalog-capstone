<template>
  <div id="app">
    <app-nav />
    <router-view />
  </div>
</template>

<script>
import AppNav from "@/components/AppNav"

export default {
  components: {
    AppNav
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@400;700;900&display=swap");

* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

body {
  /* IMPORTED FONT FAMILIES
  - Roboto
    - font weights: 400(regular), 700(bold), 900(black)
   */

  font-family: Roboto, sans-serif;
  font-weight: 400;
}
</style>