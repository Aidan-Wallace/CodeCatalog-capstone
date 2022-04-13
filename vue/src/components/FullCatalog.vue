<template>
  <div class="catalog-container">
    <h1>Catalog</h1>
    <div
      class="outer-example"
      v-for="example in examples"
      :key="example.codeId"
    >
      <catalog-example v-bind:example="example" v-bind:isExpanded="true" />
    </div>
  </div>
</template>

<script>
import CatalogExample from "@/components/CatalogExample";
import CatalogService from "@/services/CatalogService";

export default {
  name: "FullCatalog",
  components: {
    CatalogExample,
  },
  data() {
    return {
      isContentLoaded: false,
      examples: [],
    };
  },
  methods: {
    getExamples() {
      CatalogService.getExamples()
        .then((res) => {
          // this.isContentLoaded = true;
          this.examples = res.data;
          console.log(this.examples);
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  created() {
    this.getExamples();
  },
};
</script>

<style>
.catalog-container {
  display: flex;
  align-items: center;
  flex-direction: column;
}
</style>