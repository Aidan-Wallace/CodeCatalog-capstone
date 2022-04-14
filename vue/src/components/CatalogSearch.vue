<template>
  <div class="search-container">
    <form v-on:submit.prevent="getSearch">
      <div class="search">
        <input
          type="text"
          name="search-input"
          v-model="searchQuery"
          placeholder="Search..."
          autocomplete="off"
        />
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "CatalogSearch",
  methods: {
    getSearch() {
      this.$router.push({
        name: "searchResults",
        params: { query: this.searchQuery },
      });
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
      hasSearchTypeDefined: true,
      // keywords: CatalogService.getKeywords(),
      keywords: ["lang", "____"],
    };
  },
};
</script>

<style>
.search-container {
  padding: 10px 10px;
  /* width: 100%; */
}

.search-container input {
  width: 100%;
  transition: 0.2s;
  border: none;
  background-color: #eee;
  border-radius: 8px;
  width: 100%;
}

.search-container input:focus {
  outline: none;
  box-shadow: 0 0 4px rgba(0, 0, 0, 0.4);
}

/* .search-container input::placeholder {} */

.search-container button {
  width: calc(100% - 10px);
  border: none;
}

.search-container select {
  width: 100%;
}
</style>