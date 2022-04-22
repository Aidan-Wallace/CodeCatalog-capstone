<template>
  <div class="search-results-container">
    <h1>Search Results...</h1>
    <div
      class="outer-result"
      v-for="(example, index) in searchResults"
      :key="example.codeId"
    >
      <h4>{{ index + 1 }}.)</h4>
      <catalog-example v-bind:example="example" v-bind:isExpanded="false" />
    </div>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";
import CatalogExample from "@/components/CatalogExample";

export default {
  name: "SearchResults",
  props: ["query"],
  components: {
    CatalogExample,
  },
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
          this.searchResults = res.data;
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
.search-results-container {
  display: flex;
  align-items: center;
  flex-direction: column;
}
</style>
