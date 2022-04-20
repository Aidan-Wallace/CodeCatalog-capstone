<template>
  <div class="full-screen-example-container">
    <div class="fs-info">
      <div class="full-screen-title">
        <h1>{{ example.title }}</h1>
      </div>

      <div class="full-screen-programming-language">
        <strong>Language</strong>: {{ example.programmingLanguage }}
      </div>

      <div v-for="category in getCategories" :key="category">
        <strong>Categories</strong>: {{ category }}
      </div>

      <div class="full-screen-attribution-container">
        <ul>
          <li v-for="ref in getReferences.other" :key="ref">
            {{ ref }}
          </li>

          <li v-for="ref in getReferences.links" :key="ref">
            <example-link :href="ref" />
          </li>
        </ul>
      </div>
      <div class="full-screen-code-description">
        <strong>Description</strong>: {{ example.codeDescription }}
      </div>
    </div>

    <div class="full-screen-code-snippet">
      {{ example.codeSnippet }}
    </div>
  </div>
</template>

<script>
import ExampleLink from "./ExampleLink";
export default {
  name: "FullScreenExample",
  props: ["example"],
  components: {
    ExampleLink,
  },
  computed: {
    getReferences() {
      let attrs = this.example.attribution;

      let links = [];
      let other = [];

      attrs.split(" ").forEach((ref) => {
        if (ref.includes("http://") || ref.includes("https://")) {
          links.push(ref);
        } else {
          other.push(ref);
        }
      });
      return {
        links: links,
        other: other,
      };
    },
    getCategories() {
      return this.example.category.split(" ");
    },
    getAttributions() {
      return this.example.attribution.split(" ");
    },
  },
  created() {
    // DOES NOT WORK
    if (typeof this.example != "object") {
      this.$router.push({ path: "/" });
    }
  },
};
</script>

<style>
.full-screen-example-container {
  height: 100vh;
  max-height: 100vh;
  justify-content: center;
  display: flex;
  align-items: center;
  flex-direction: column;
}

/* .full-screen-title {} */
/* .full-screen-code-description {} */

.full-screen-code-snippet {
  width: 40vw;
  height: 30vh;
  background-color: rgb(243, 243, 243);
  padding: 10px;
  margin-top: 20vh;
  border-radius: 6px;
  overflow-y: scroll;
}
</style>
