<template>
  <div class="code-container" :class="{ hide: code == '' }">
    {{ code }}
  </div>
</template>

<script>
export default {
  props: ["code"],
};
</script>

<style>
.code-container {
  background-color: #eee;
  padding: 15px;
  width: 64%;
}

.code-container.hide {
  background-color: transparent;
}
</style>