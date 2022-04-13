<template>
  <div class="example-container" :key="reRenderKey">
    {{ currentExample.title }}
    <!-- 
          TITLE

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
  name: "FullCatalog",
  props: ["codeId"],
  computed: {},
  methods: {
    setKey() {
      this.reRenderKey++;
    }
  },
  data() {
    return {
      currentExample: this.$store.state.currentExample,
      isContentLoaded: false,
      reRenderKey: 0,
    };
  },
  created() {
    CatalogService.getExample(1)
      .then((res) => {
        // this.$store.state.currentExample = res.data;

        this.$store.commit("SET_CURRENT_EXAMPLE", res.data);
        console.log(this.$store.state.currentExample);

        // this.isContentLoaded = true;
        // this.$forceUpdate();
      })
      .catch((err) => {
        console.log(err);
      });
  },
};
</script>