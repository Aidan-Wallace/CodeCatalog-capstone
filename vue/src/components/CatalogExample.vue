<template>
  <div class="example-container" v-bind:class="{ expanded: isExpanded }">
    <div class="example-container-child example-title">
      <h2>
        {{ example.title }}
      </h2>
    </div>

    <div class="example-container-child example-code">
      {{ example.codeSnippet }}
<!--       <input type="text" v-model="message" />
      <button type="button" @click="doCopy">Copy code snippet</button>
 -->    </div>

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
    <div class="example-container-child example-download">
      <!-- <download /> -->
    </div>
  </div>
</template>

<script>
// import Download from './Download.vue';
export default {
  // components: { Download },
  name: "FullCatalog",
  /* *** PROP USES ***
    - "example"    :: A object passed in with each code example.
    - "isExpanded" :: A boolean to add proper styling to .example-container 
        element to help reuse this component. If set to false(by default),
        the component will return a closed and clickable element with just a 
        few details rather than the whole code block.
  */
  props: ["example", "isExpanded"],
/*   data: function () {
    return {
      message: "Copy code snippet",
    };
  },
  methods: {
    doCopy: function () {
      this.$copyText(this.message).then(
        function (e) {
          alert("Copied");
          console.log(e);
        },
        function (e) {
          alert("Can not copy");
          console.log(e);
        }
      );
    },
  },
 */};
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

.example-code {
  background-color: #eee;
  padding: 15px;
  width: 64%;
}
</style>