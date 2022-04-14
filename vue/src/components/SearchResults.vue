<template>
  <div class="search-results-container">
    <h1>Search Results...</h1>
    <div v-for="res in searchResults" :key="res.codeId">
      <h1>{{ res.title }}</h1>
    </div>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "SearchResults",
  query: "",
  created() {
    this.query = this.$route.params.query;
  },

  computed: {
    searchResults() {
      console.log(this.query);
      return CatalogService.getQuery(this.query);
    },
  },
};
</script>

<style>
</style>