<template>
  <div class="catalog-container">
    <h1 v-on:click.prevent="getGenericExamples()">Catalog</h1>
    <h3>Sort By</h3>
    <h3>Show: My Code | All Code</h3>
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

      for (let i = this.examples.length - 1; i > 0; i--) {
        newList.push(this.examples[i]);
      }

      return newList;
    },
  },
  methods: {
<<<<<<< HEAD
    getExamples() {
=======
    getGenericExamples() {
>>>>>>> 8b085253317bb49f44fe4fa4e540e9afa4da2599
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
</style>
