<template>
  <div id="app">
    <app-nav />
    <div class="router-view">
      <router-view />
    </div>
  </div>
</template>

<script>
import AppNav from "@/components/AppNav";

export default {
  components: {
    AppNav,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@400;700;900&display=swap");

:root {
  /* CSS HEX */
  --paradise-pink: rgb(239, 71, 71);
  --orange-yellow-crayola: #ffd166ff;
  --caribbean-green: #06d6a0ff;
  --blue-ncs: #118ab2ff;
  --midnight-green-eagle-green: #073b4cff;
}

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

.router-view {
  padding-top: 7vh;
}
</style>
