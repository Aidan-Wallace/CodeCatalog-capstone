<template>
  <div>
    {{ example.title }}
    {{ example.programmingLanguage }}
    {{ example.codeDescription }}
    <div v-for="category in getCategories" :key="category">
      {{ category }}
    </div>
    <div class="code-snippet">
      {{ example.codeSnippet }}
    </div>
    <div v-for="attr in getAttributions" :key="attr">
      {{ attr }}
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
    // DOES NO`T WORKf
    if (typeof this.example != "object") {
      this.$router.push({ path: "/" });
    }
  },
};
</script>

<style>
</style>