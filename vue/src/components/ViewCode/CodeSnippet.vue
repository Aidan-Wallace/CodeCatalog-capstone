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
  padding: 15px;
  width: 100%;
}

.code-container.hide {
  background-color: transparent;
}
</style>