<template>
  <div class="example-container" v-bind:class="{ expanded: isExpanded }">
    <div class="example-container-child example-title">
      <h2>
        {{ example.title }}
      </h2>
    </div>

    <div class="example-container-child example-code">
      <code-snippet :code="example.codeSnippet" />
    </div>

    <div class="example-container-child example-description">
      <p>
        {{ example.codeDescription }}
      </p>
    </div>

    <div class="example-container-child example-date">
      <span>Last Updated</span> {{ example.exampleDate }}
    </div>

    <div class="example-container-child example-difficulty">
      <span>Experience level</span> {{ example.difficultyRank }}
    </div>

    <div class="example-container-child example-category">
      <span>Code category</span> {{ example.category }}
    </div>

    <div class="example-container-child example-language">
      <span>Language</span> {{ example.programmingLanguage }}
    </div>

    <!-- <div class="example-container-child example-attribution">
      <span>References</span>
      <div v-for="ref in getReferences.links" :key="ref">
        <example-link :href="ref" />
      </div>

      <div v-for="ref in getReferences.other" :key="ref">
        {{ ref }}
      </div>
    </div> -->    
  </div>
</template>

<script>
import CodeSnippet from "./CodeSnippet";
// import Download from "./Download";

export default {
  name: "FullCatalog",
  props: ["example", "isExpanded"],
  components: {
    CodeSnippet,
    // Download
  },
};
</script>

<style scoped>
.example-container {
  width: 90vw;
  max-height: 8vh;

  border-radius: 14px;
  box-shadow: 0 0 9px rgba(0, 0, 0, 0.4);
  overflow: hidden;
  padding: 15px 0 15px 0;
  margin-bottom: 25px;

  display: flex;
  cursor: pointer;
  align-items: center;
  justify-content: space-evenly;
  flex-direction: row;

  transition: all 0.2s linear;
}

.example-container:hover {
  box-shadow: 0 0 25px rgba(0, 0, 0, 0.4);
  width: 92vw;
}

.example-container.expanded {
  max-height: fit-content;
  justify-content: center;
  flex-direction: column;
}

.example-container-child {
  display: none;
  flex-direction: column;
  align-items: center;
  width: 100%;
}

.example-container-child span {
  font-weight: 700;
}

.example-title {
  display: flex;
  overflow: hidden;
  max-width: 30vw;
}

.example-date {
  display: flex;
}

.example-category {
  display: flex;
}

.example-language {
  display: flex;
}

.example-container.expanded .example-container-child {
  display: flex;
}
</style>
