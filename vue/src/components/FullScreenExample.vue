<template>
  <div class="full-screen-example-container">
    <div class="fs-info">
      <div class="full-screen-title">
        <h1>{{ example.title }}</h1>
      </div>
      <div class="full-screen-programming-language">
        <strong><i class="fa-solid fa-droplet"></i> Language</strong>: {{ example.programmingLanguage }}
      </div>
      <div v-for="category in getCategories" :key="category">
        <strong><i class="fa-solid fa-droplet"></i> Categories</strong>: {{ category }}
      </div>
      <div class="full-screen-attribution-container">
        <ul>
          <li v-for="ref in getReferences.other" :key="ref">
            <i class="fa-solid fa-droplet"></i> {{ ref }}
          </li>
          <li v-for="ref in getReferences.links" :key="ref">
            <i class="fa-solid fa-droplet"></i> <example-link :href="ref" />
          </li>
        </ul>
      </div>
      <div class="full-screen-code-description">
        <strong><i class="fa-solid fa-droplet"></i> Description</strong>: {{ example.codeDescription }}
      </div>
    </div>
    <div class="full-screen-copy-button">
      <button
        type="button"
        class="button-64"
        v-clipboard:copy="example.codeSnippet"
        v-clipboard:success="onCopy"
        v-clipboard:error="onError"
      >
        Copy Code
      </button>
    </div>
    <div class="full-screen-downloader">
      <button type="button" class="button-64" @click="download">
        Download Code
      </button>
    </div>
    <div class="full-screen-code-snippet">
      <code-snippet :code="example.codeSnippet" />
    </div>
  </div>
</template>
<script>
import ExampleLink from "./ExampleLink";
import CodeSnippet from "./CodeSnippet.vue";
export default {
  name: "FullScreenExample",
  props: ["example"],
  components: {
    ExampleLink,
    CodeSnippet,
  },
  methods: {
    download() {
      let text = JSON.stringify(this.example.codeSnippet);
      let filename = "snippet.txt";
      let element = document.createElement("a");
      element.setAttribute(
        "href",
        "data:text/plain; charset=utf-8," + encodeURIComponent(text)
      );
      element.setAttribute("download", filename);
      element.style.display = "none";
      document.body.appendChild(element);
      element.click();
      document.body.removeChild(element);
    },
    onCopy: function() {
      alert("Successful copy.");
    },
    onError: function() {
      alert("Failed to copy texts");
    },
  },
  computed: {
    getReferences() {
      let attrs = this.example.attribution;
      let links = [];
      let other = [];
      attrs.split(";").forEach((ref) => {
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
  overflow: hidden;
  display: flex;
  flex-direction:column;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  height: 90%;
}
.full-screen-attribution-container li{
  list-style: none;
}
/* .full-screen-title {} */
/* .full-screen-code-description {} */

.full-screen-code-snippet {
  display:flex;
  justify-content: center;
  align-items: center;
  min-width: 75vw;
  min-height: 50vh;
  width: auto;
  height: auto;
  background-color: rgb(243, 243, 243);
  padding: 0px;
  margin-top: 2vh;
  border-radius: 6px;
  overflow-y: scroll;
}
.full-screen-code-description{
  margin-bottom: 15pt;
}
.button-64 {
display:flex;
  justify-content: center;
  align-items:center;
  width: 15vw;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  margin-bottom: 5px;
  background-color: var(--paradise-pink);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 18px;
  color: #fff;
}
.button-64:hover{
  width: 1%;
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 20px;
}
@media (min-width: 768px) {
  .button-64 {
    font-size: 24px;
    min-width: 196px;
  }
}
</style>
