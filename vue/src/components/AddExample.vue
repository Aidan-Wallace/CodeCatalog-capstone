<template>
  <div class="form-container isSubmitting">
    <div class="isProcessing" :class="{ hide: !isProcessing }"></div>

    <form v-on:submit.prevent="submitNewExample">
      <div class="ae-input add-title-container">
        <label for="title">Title</label>
        <small>50 Character Limit</small>
        <input type="text" name="title" v-model="newExample.title" required />
      </div>

      <div class="ae-input add-language-container" required>
        <label for="language">Programming Language</label>
        <small>Please Select</small>
        <select name="language" v-model="newExample.programmingLanguage">
          <option value="">--</option>
          <option value="csharp">C#</option>
          <option value="css">CSS</option>
          <option value="html">HTML</option>
          <option value="javascript">JavaScript</option>
          <option value="react">React JS</option>
          <option value="vue">Vue JS</option>
          <option value="other">Other</option>
        </select>

        <input
          v-if="newExample.programmingLanguage == 'other'"
          v-model="newExample.addedLanguage"
          type="text"
          placeholder="Please enter language used"
        />
      </div>

      <div class="ae-input add-description-container">
        <label for="description">Code Description</label>
        <small>(Description of input)</small>
        <textarea
          type="text"
          name="description"
          v-model="newExample.codeDescription"
        ></textarea>
      </div>

      <div class="ae-input add-category-container">
        <label for="category">Category</label>
        <small>Please select relevant categories</small>
        <select name="category" v-on:change="addToCategory($event)">
          <option value="">--</option>
          <option v-for="c in categories" :key="c" :value="c">
            {{ c }}
          </option>
        </select>

        <div class="selected-catagories" v-show="newExample.category != ''">
          <div
            class="selected-category"
            v-for="sc in getSelectedCategories"
            :key="sc"
          >
            <i class="fa-solid fa-x" v-on:click="removeFromCategories(sc)"></i>
            {{ sc }}
          </div>
        </div>
      </div>

      <div class="ae-input add-code-snippet-container">
        <label for="code-snippet">Enter Code</label>
        <small>(Description of input)</small>
        <textarea
          type="text"
          name="code-snippet"
          v-model="newExample.codeSnippet"
        ></textarea>
      </div>

      <div class="ae-input add-difficulty-container">
        <label for="difficulty">Code Difficulty</label>
        <small>(Description of input)</small>
        <select name="difficulty" v-model="newExample.difficultyRank">
          <option value="">--</option>
          <option value="easy">Easy</option>
          <option value="medium">Medium</option>
          <option value="hard">Hard</option>
        </select>
      </div>

      <div class="ae-input add-example-container">
        <label for="attribution">Enter references</label>
        <small>Use "https://" format for a valid link</small>
        <input
          v-for="(ref, index) in getReferences"
          :key="ref"
          type="text"
          name="attribution"
          v-model="referenceHolder[index]"
          placeholder="e.g 'https://www.wikipedia.com' or 'John Doe'"
        />
        <!-- NEED ABILITY TO ADD MORE REFERENCES -->
      </div>
      <!-- var arr = ["You added an example"
                    , "You added a second example."
                    , "You added a third example."
                    , "You added a fourth example."
                    , "You added a fifth example."
                    , "You added a sixth example."];

          document.querySelector("button").onclick = function() {
            this.innerHTML = arr.length > 1 ? arr.shift() : arr[0]
          } -->
      <button type="submit">Add Code Example</button>
    </form>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "AddExample",
  data() {
    return {
      newExample: this.$store.state.getNewExample,
      categories: this.$store.state.getCategories,
      isProcessing: false,
      addedLanguage: "",
      referenceHolder: [],
    };
  },
  computed: {
    getSelectedCategories() {
      return this.newExample.category.split(" ");
    },
    getReferences() {
      let references = this.newExample.attribution.split(" ");

      if (references[references.length - 1] != "") {
        return references.length + 1;
      }
      return references.length;
    },
  },
  methods: {
    addToCategory(event) {
      // Determine if space needs to be pre-pended
      const addSpace = this.newExample.category != "" ? " " : "";
      let newCategory = addSpace + event.target.value;

      // Add selected category to newExample categories
      this.newExample.category += newCategory;

      // Remove selected category from categories
      var index = this.categories.indexOf(event.target.value);
      if (index > -1) this.categories.splice(index, 1);
    },

    removeFromCategories(category) {
      // Add deleted category to list of available categories
      this.categories.push(category);

      // Remove category from newExample.category
      let catArr = this.newExample.category.split(" ");
      let index = catArr.indexOf(category);
      catArr.splice(index, 1);

      this.newExample.category = catArr.join(" ");
    },

    submitNewExample() {
      this.isProcessing = true;

      if (this.newExample.programmingLanguage == "other") {
        this.newExample.programmingLanguage = this.addedLanguage;
      }

      CatalogService.addExample(this.newExample)
        .then((response) => {
          console.log(response);

          if (confirm(`Success! Add more code?`)) {
            this.clearForm();
            return;
          } else {
            this.$router.push({ name: "home" });
          }
        })
        .catch((err) => {
          console.log(err);

          if (confirm(`Error! Server responded with: ${err.status}`)) {
            this.clearForm();
          } else {
            return;
          }

          this.isProcessing = false;
        });
    },

    clearForm() {
      this.newExample = this.$store.state.getNewExample;
      this.categories = this.$store.state.getCategories;
      this.addedLanguage = "";
      this.isProcessing = false;
    },
  },
};
</script>

<style scoped>
.form-container {
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100vh;
}

.isProcessing {
  position: absolute;
  z-index: 999;

  background-color: rgba(236, 236, 236, 0.575);

  width: 100%;
  height: 100%;

  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  transition: all 0.16s linear;
}

.hide {
  display: none;
}

form {
  border: 1px solid;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: 40vw;
  padding: 50px 0;
}

.ae-input {
  display: flex;
  flex-direction: column;
  margin: 10px 0;
  width: 90%;
}

label {
  font-weight: 700;
  margin: 0px;
}

input,
textarea {
  width: 100%;
  outline: none;
}

.add-description-container textarea {
  height: 10vh;
  resize: none;
}

.add-code-snippet-container textarea {
  height: 10vh;
  max-height: 30vh;
}

.selected-catagories {
  display: flex;
}

.selected-category {
  border-radius: 16px;
  background-color: #eee;
  padding: 5px 12px;
  margin: 10px;
}

.selected-category > i {
  font-size: 0.8rem;
  font-weight: bold;
  cursor: pointer;
}

form button {
  width: 90%;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  background-color: rgb(71, 245, 149);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 18px;
  color: #fff;
}

form button:hover {
  width: 92%;
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 20px;
}
</style>
