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
          <li
            class="full-screen-attribution"
            v-for="attr in getAttributions"
            :key="attr"
          >
            {{ attr }}
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
export default {
  name: "FullScreenExample",
  props: ["example"],
  computed: {
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

.full-screen-title {
}

.full-screen-code-description {
}

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