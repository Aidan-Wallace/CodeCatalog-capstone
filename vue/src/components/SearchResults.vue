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
  props: ["query"],
  data() {
    return {
      searchResults: [],
    };
  },
  methods: {
    getSearchResults() {
      CatalogService.getQuery(this.query)
        .then((res) => {
          console.log(res);
          this.searchResults = res;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },

  created() {
    this.getSearchResults();
  },
};
</script>

<style>
</style>