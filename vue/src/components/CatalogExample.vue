<template>
  <div class="example-container">
    <!-- <div class="example-title">{{ getExample.title }}</div> -->
    <!-- 
          TITLE //

          CODE DISPLAY

          DESCRIPTION

          REFS

          KEYWORDS
       -->
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "CatalogExample",
  props: ["codeId"],
  data() {
    return {
      catalogExample: {
        category: "",
        title: "",
        language: "",
        level: "",
        entryDate: "",
        //codeExample:
      },
    };
  },
  created() {
    const example = CatalogService.getExample(1);
    this.$store.state.currentExample = example;
  },
};
</script>