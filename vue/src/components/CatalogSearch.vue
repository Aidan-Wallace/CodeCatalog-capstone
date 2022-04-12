<template>
  <div class="search-container">
    <form v-on:submit.prevent="getQuery">
      <div class="search">
        <input type="text" name="search-input" v-model="searchQuery" />
        <button type="submit" v-bind:disabled="isDisabled == false">Search</button>
      </div>
      <select name="" id="">
        <option value="">--</option>
        <option v-for="option in keywords" v-bind:key="option.keyword" value="">
          {{ option.keyword }}
        </option>
      </select>
    </form>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "CatalogSearch",
  methods: {
    getQuery(query) {
      /* NEED TO TROUBLESHOOT QUERY RESPONSE AFTER QUERY DAO/CONTROLLER IS IMPLEMENTED */

      let response = CatalogService.getQuery(query);
      console.log(response);

      this.resetForm();
    },
    resetForm() {
      this.searchQuery = "";
    },
  },
  computed: {
    isDisabled() {
      return this.hasSearchTypeDefined;
    },
  },
  data() {
    return {
      searchQuery: "",
      hasSearchTypeDefined: false,
      // keywords: CatalogService.getKeywords(),
      keywords: ["lang", "____"]
    };
  },
};
</script>

<style>
.search-container {
  padding: 10px 10px;
}

.search-container select {
    width: 100%;
}
</style>