<template>
  <div class="catalog-container">
    <h1>Catalog</h1>
    <div
      class="example-container"
      v-for="example in examples"
      :key="example.codeId"
    >
      <div class="example-title">
        {{ example.title }}
      </div>

      <div class="example-code">
        {{ example.codeSnippet }}
      </div>

      <div class="example-description">
        {{ example.codeDescription }}
      </div>

      <div class="example-date">
        {{ example.exampleDate }}
      </div>

      <div class="example-difficulty">
        {{ example.difficultyRank }}
      </div>

      <div class="example-category">
        {{ example.catalog }}
      </div>

      <div class="example-language">
        {{ example.programmingLanguage }}
      </div>

      <!-- 
          TITLE

          CODE DISPLAY

          DESCRIPTION

          REFS

          KEYWORDS
       -->
    </div>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "FullCatalog",
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
  data() {
    return {
      isContentLoaded: false,
      examples: [],
    };
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

.catalog-container > div {
  width: 90vw;

  border-radius: 14px;
  box-shadow: 0 0 9px rgba(0, 0, 0, 0.4);
  padding: 15px 0 15px 0;
  margin-bottom: 25px;

  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
}
</style>