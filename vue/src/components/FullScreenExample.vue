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

    <div class="full-screen-copy-button">
      <button
        type="button"
        class="button-64"
        v-clipboard:copy="example.codeSnippet"
        v-clipboard:success="onCopy"
        v-clipboard:error="onError"
      >
        Copy snippet:
      </button>
    </div>

    <div class="full-screen-downloader">
      <button type="button" class="button-64" @click="download">
        Download snippet:
      </button>
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
    onCopy: function () {
      alert("Successful copy.");
    },
    onError: function () {
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

/* .full-screen-copy-button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 0.25em 0.75em;
  min-width: 10ch;
  min-height: 44px; }*/

.button-64 {
  align-items: center;
  background-image: linear-gradient(144deg, #af40ff, #5b42f3 50%, #00ddeb);
  border: 0;
  border-radius: 8px;
  box-shadow: rgba(151, 65, 252, 0.2) 0 15px 30px -5px;
  box-sizing: border-box;
  color: #ffffff;
  display: flex;
  font-family: Phantomsans, sans-serif;
  font-size: 20px;
  justify-content: center;
  line-height: 1em;
  max-width: 100%;
  min-width: 140px;
  padding: 3px;
  text-decoration: none;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  cursor: pointer;
}

.button-64:active,
.button-64:hover {
  outline: 0;
}

.button-64 span {
  background-color: rgb(5, 6, 45);
  padding: 16px 24px;
  border-radius: 6px;
  width: 100%;
  height: 100%;
  transition: 300ms;
}

.button-64:hover span {
  background: none;
}

@media (min-width: 768px) {
  .button-64 {
    font-size: 24px;
    min-width: 196px;
  }
}
</style>