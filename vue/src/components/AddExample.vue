<template>
  <div>
    <div class="form-container">
      <form action="">
        <div class="ae-input add-title-container">
          <label for="title">Title</label>
          <small>(Description of input)</small>
          <input type="text" name="title" />
        </div>

        <div class="ae-input add-language-container">
          <label for="language">Programming Language</label>
          <small>(Description of input)</small>
          <input type="text" name="language" />
        </div>

        <div class="ae-input add-description-container">
          <label for="description">Code Description</label>
          <small>(Description of input)</small>
          <textarea type="text" name="description" resize></textarea>
        </div>

        <div class="ae-input add-category-container">
          <label for="category">Category</label>
          <small>(Description of input)</small>
          <input type="text" name="category" />
        </div>

        <div class="ae-input add-code-snippet-container">
          <label for="code-snippet">Enter Code</label>
          <small>(Description of input)</small>
          <textarea type="text" name="code-snippet"></textarea>
        </div>

        <div class="ae-input add-difficulty-container">
          <label for="difficulty">Code Difficulty</label>
          <small>(Description of input)</small>
          <select name="difficulty">
            <option value="">--</option>
            <option value="easy">Easy</option>
            <option value="medium">Medium</option>
            <option value="hard">Hard</option>
          </select>
        </div>

        <div class="ae-input add-example-container">
          <label for="attribution">Enter References</label>
          <small>(Description of input)</small>
          <input type="text" name="attribution" />
          <!-- NEED ABILITY TO ADD MORE REFERENCES -->
        </div>
        <button type="submit">Add Code Example</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {};
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