<template>
  <div class="catalog-container">
    <h1>Catalog</h1>
    <h3>Sort By</h3>
    <h3>Show: My Code | All Code</h3>
    <div
      class="outer-example"
      v-for="example in examples"
      :key="example.codeId"
      v-on:click="
        $router.push({
          name: 'ViewExample',
          params: {
            example: example,
          },
        })
      "
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
  goFullScreen() {
    this.$router.push({
      name: "viewExample",
      params: {
        example: "example",
      },
    });
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