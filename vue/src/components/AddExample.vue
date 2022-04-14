<template>
  <div>
    <div class="form-container">
      <form action="">
        <div class="ae-input add-title-container">
          <label for="title">Title</label>
          <small>(Description of input)</small>
          <input type="text" name="title" class="" />
        </div>

        <div class="ae-input add-language-container">
          <label for="language">Programming Language</label>
          <small>(Description of input)</small>
          <input type="text" name="language" class="" />
        </div>

        <div class="ae-input add-description-container">
          <label for="description">Code Description</label>
          <small>(Description of input)</small>
          <textArea type="text" name="description" class=""></textArea>
        </div>

        <div class="ae-input add-category-container">
          <label for="category">Category</label>
          <small>(Description of input)</small>
          <input type="text" name="category" class="" />
        </div>

        <div class="ae-input add-code-snippet-container">
          <label for="code-snippet">Enter Code</label>
          <small>(Description of input)</small>
          <textArea type="text" name="code-snippet" class=""></textArea>
        </div>

        <div class="ae-input add-difficulty-container">
          <label for="difficulty">Code Difficulty</label>
          <small>(Description of input)</small>
          <select name="difficulty" class="">
            <option value="">--</option>
            <option value="easy">Easy</option>
            <option value="medium">Medium</option>
            <option value="hard">Hard</option>
          </select>
        </div>

        <div class="ae-input add-example-container">
          <label for="attribution">Enter References</label>
          <input type="text" name="attribution" class="" />
          <!-- NEED ABILITY TO ADD MORE REFERENCES -->
        </div>
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
}

label {
    font-weight: 700;
}
</style>