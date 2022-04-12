<template>
  <div>
    <!-- 1 IS TEMPORARY REPLACE WITH ROUTER -->
    <catalog-example v-bind:codeId="1" />
  </div>
</template>

<script>
import CatalogExample from "@/components/CatalogExample";

export default {
  name: "ExampleView",
  components: {
    CatalogExample,
  },
  methods: {},

  data() {
    return {
      CatalogExample: {},
    };
  },
};
</script>