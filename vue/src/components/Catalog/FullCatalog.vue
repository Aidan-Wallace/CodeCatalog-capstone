<template>
  <div class="catalog-container">
    <h1 v-on:click.prevent="getGenericExamples()">Code Catalog</h1>
    <div
      class="outer-example"
      v-for="example in getExamplesSorted"
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
  computed: {
    getExamplesSorted() {
      let newList = [];

      for (let i = this.examples.length - 1; i >= 0; i--) {
        newList.push(this.examples[i]);
      }

      return newList;
    },
  },
  methods: {
    getGenericExamples() {
      CatalogService.getGenericExamples()
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
    this.getGenericExamples();
  },
};
</script>

<style>
.catalog-container {
  display: flex;
  align-items: center;
  flex-direction: column;
}
.catalog-container h1 {
  font-weight: bold;
  padding-top: 10pt;
}
</style>
