<template>
  <div class="form-container isSubmitting">
    <div class="isProcessing" :class="{ hide: !isProcessing }"></div>

    <form v-on:submit.prevent="submitNewExample">
      <div class="ae-input add-title-container">
        <label for="title">Title</label>
        <small>50 Character Limit</small>
        <input
          type="text"
          name="title"
          v-model="newExample.title"
          required
          maxlength="50"
        />
      </div>

      <div class="ae-input add-language-container">
        <label for="language">Programming Language</label>
        <small>(optional) Please Select</small>
        <select
          name="language"
          v-model="newExample.programmingLanguage"
          required
        >
          <option value="">--</option>
          <option
            v-for="(lang, index) in $store.state.availableLanguages"
            :key="index"
            :value="lang.toUpperCase()"
            >{{ lang }}</option
          >
        </select>

        <!-- <input
          v-if="newExample.programmingLanguage == 'other'"
          v-model="newExample.addedLanguage"
          type="text"
          placeholder="Please enter language used"
        /> -->
      </div>

      <div class="ae-input add-description-container">
        <label for="description">Code Description</label>
        <small>(optional) Enter a description</small>
        <textarea
          type="text"
          name="description"
          v-model="newExample.codeDescription"
        ></textarea>
      </div>

      <div class="ae-input add-category-container">
        <label for="category">Category</label>
        <small>(optional) Please select relevant categories</small>
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
        <label for="code-snippet">Code</label>
        <small>Enter code snippet</small>
        <textarea
          type="text"
          name="code-snippet"
          v-model="newExample.codeSnippet"
          required
        ></textarea>
      </div>

      <div class="ae-input add-difficulty-container">
        <label for="difficulty">Code Difficulty</label>
        <small>(optional) Please select a difficulty</small>
        <select name="difficulty" v-model="newExample.difficultyRank">
          <option value="">--</option>
          <option value="easy">Easy</option>
          <option value="medium">Medium</option>
          <option value="hard">Hard</option>
        </select>
      </div>

      <div class="ae-input add-example-container">
        <label for="attribution">Enter references</label>
        <small>Use "http[s]://" format for a valid link</small>
        <div
          v-for="(ref, index) in getReferences"
          :key="index"
          class="reference"
        >
          <input
            type="text"
            name="attribution"
            v-model="referenceHolder[index]"
            placeholder="e.g 'https://www.wikipedia.com' or 'John Doe'"
          />
          <i
            class="fa-solid fa-plus"
            v-on:click="addReference"
            v-show="index + 1 == referenceHolder.length"
          ></i>
        </div>
      </div>
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
      referenceHolder: [""],
    };
  },
  computed: {
    getSelectedCategories() {
      return this.newExample.category.split(" ");
    },
    getReferences() {
      if (this.referenceHolder == []) {
        return 1;
      }
      return this.referenceHolder.length;
    },
  },
  methods: {
    addReference() {
      this.referenceHolder.push("");
    },

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

      this.newExample.attribution = this.referenceHolder.join(";");

      CatalogService.addExample(this.newExample, this.$store.state.user.userId)
        .then((/* response */) => {
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
      this.newExample = {
        title: "",
        programmingLanguage: "",
        codeDescription: "",
        category: "",
        codeSnippet: "",
        difficultyRank: "",
        attribution: "",
      };
      this.categories = [
        "algorithms",
        "artificial",
        "data",
        "databases",
        "functional",
        "mathematics",
        "web",
        "other",
      ];

      this.addedLanguage = "";
      this.referenceHolder = [""];
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
  box-shadow: 0 0 12px rgba(0, 0, 0, 0.4);
  background-color: var(--paradise-pink);
  border-radius: 12px;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: 40vw;
  padding: 50px 0;
}

form select {
  background: var(--midnight-green-eagle-green);
  border-radius: 4px;
  color: #eee;
}

form select option {
  background-color: #fff;
  color: #000;
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
  color: #fff;
}

small {
  color: rgb(0, 0, 0);
}

input,
textarea {
  width: 100%;
  outline: none;
  background: transparent;
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

.reference {
  display: flex;
  align-items: center;
}

.reference i {
  margin-left: 10px;
  cursor: pointer;
}

form button {
  width: 90%;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  background-color: var(--blue-ncs);
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
