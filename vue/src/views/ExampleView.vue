<template>
  <div>
    <!-- 1 IS TEMPORARY REPLACE WITH ROUTER -->
    <catalog-example v-bind:codeId="1" />
    <!-- <download v-bind:codeId="1"/> -->
  </div>
</template>

<script>
import CatalogExample from "@/components/CatalogExample";
// import Download from "@/components/Download"

export default {
  name: "ExampleView",
  components: {
    CatalogExample,
    // Download,
  },
  methods: {
    
  },

  data() {
    return {
      CatalogExample: {},
      Download: {},
    };
  },
};
</script>