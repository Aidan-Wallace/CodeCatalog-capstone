<template>
  <div class="code-container" :class="{ hide: code == '' }">
    <pre><code class="language-javascript">{{code}}</code></pre>
  </div>
</template>
<script>
export default {
  props: ["code"],
};
</script>
<style>
.code-container {
  display:flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(236, 236, 236);
  background-position:center;
  border-radius: 10px;
  padding: 15px;
  width: auto;
  height: auto;
}
.code-container.hide {
  background-color: transparent;
}
</style>