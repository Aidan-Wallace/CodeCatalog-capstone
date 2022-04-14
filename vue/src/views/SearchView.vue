<template>
  <search-results v-bind:query="getQuery" />
</template>

<script>
import SearchResults from "@/components/SearchResults";

export default {
  name: "SearchView",
  components: {
    SearchResults,
  },
  computed: {
    getQuery() {
      return this.$route.params.query;
    },
  },
};
</script>