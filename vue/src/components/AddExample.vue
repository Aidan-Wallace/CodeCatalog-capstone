<template>
  <div>
    <div class="form-container">
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
          <small>(Description of input)</small>
          <select name="category" v-model="newExample.category">
            <option value="">--</option>
            <option value="">TBD</option>
          </select>
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
          <small>(Description of input)</small>
          <input
            type="text"
            name="attribution"
            v-model="newExample.attribution"
          />
          <!-- NEED ABILITY TO ADD MORE REFERENCES -->
        </div>
        <button type="submit">Add Code Example</button>
      </form>
    </div>
  </div>
</template>

<script>
import CatalogService from "@/services/CatalogService";

export default {
  name: "AddExample",
  data() {
    return {
      newExample: {
        title: "",
        programmingLanguage: "",
        codeDescription: "",
        category: "",
        codeSnippet: "",
        difficultyRank: "",
        attribution: "",
      },
    };
  },
  methods: {
    submitNewExample() {
      console.log(this.newExample);

      CatalogService.addExample(this.newExample)
        .then((response) => {
          console.log(response.status);
          this.clearForm();
        })
        .catch((err) => {
          console.log(err);
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
    },
  },
};
</script>

<style scoped>
.form-container {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100vh;
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