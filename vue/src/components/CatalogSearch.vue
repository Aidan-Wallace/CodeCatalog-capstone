<template>
  <div class="search-container">
    <form class="search-form" v-on:submit.prevent="getSearch">
      <input
        type="text"
        name="search-input"
        v-model="searchQuery"
        placeholder="Search..."
        autocomplete="off"
      />
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
  height: 100%;
  width: 100%;
}

.search-form {
  position: relative;
  top: 50%;
  transform: translateY(-50%);
}

.search-container input {
  width: 100%;
  transition: 0.2s;
  border: none;
  background-color: #eee;
  border-radius: 8px;
  padding-left: 8px;
  font-size: 1.4rem;
}

.search-container input:focus {
  outline: none;
  box-shadow: 0 0 4px rgba(0, 0, 0, 0.4);
}
</style>
