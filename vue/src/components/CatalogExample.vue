<template>
  <div class="example-container" v-bind:class="{ expanded: !isExpanded }">
    <div class="example-title">
      <h2>
        {{ example.title }}
      </h2>
    </div>

    <div class="example-code">
      {{ example.codeSnippet }}
    </div>

    <div class="example-description">
      <p>
        {{ example.codeDescription }}
      </p>
    </div>

    <div class="example-date">Updated: {{ example.exampleDate }}</div>

    <div class="example-difficulty">
      Experience level: {{ example.difficultyRank }}
    </div>

    <div class="example-category">code category: {{ example.category }}</div>

    <div class="example-language">
      {{ example.programmingLanguage }}
    </div>
  </div>
</template>

<script>
export default {
  name: "FullCatalog",
  /* *** PROP USES ***
    - "example"    :: A object passed in with each code example.
    - "isExpanded" :: A boolean to add proper styling to .example-container 
        element to help reuse this component. If set to false(by default),
        the component will return a closed and clickable element with just a 
        few details rather than the whole code block.
  */
  props: ["example", "isExpanded"],
};
</script>

<style scoped>
.example-container {
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

.example-container.expanded {
  display: none;
}

.example-code {
  background-color: #eee;
  padding: 5px;
}
</style>