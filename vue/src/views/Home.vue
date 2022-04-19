<template>
  <div class="home">
    <img
      src="@/assets/cloudcodefinal.svg"
      alt="CodeCatalog Logo"
      v-on:click.prevent="goHome"
    />
    <!-- <catalog-example /> -->
    <!-- <download /> -->
  </div>
</template>

<script>
// import Download from '../components/Download.vue';
// import CatalogExample from "../components/CatalogExample.vue";

export default {
  name: "home",
  components: {
    // Download
    // CatalogExample,
  },

  created() {},
};
</script>

<style scoped>
.home {
  display: flex;
  justify-content: center;
}

img {
  width: 40vw;
}
</style>