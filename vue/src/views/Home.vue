<template>
  <div class="home">
    <h1>Code Catalog</h1>
    <!-- <catalog-example /> -->
    <download />
  </div>
</template>

<script>
import Download from '../components/Download.vue';
// import CatalogExample from "../components/CatalogExample.vue";

export default {
  name: "home",
  components: {
    Download
    // CatalogExample,
  },

  created() {
  }
};
</script>

<style scoped>
.home {
  display: flex;
  justify-content: center;
}
</style>