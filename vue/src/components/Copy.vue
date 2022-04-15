<template>
  <div id="copy-button">
        <button v-if="canCopy" @click="copy(something)">Copy</button>  
    </div>
</template>

<script>
export default {
  data() {
    return {
      text: 'Copy test'
    };
  },
  methods: {
    copy() {
      this.$refs.clone.focus();
      document.execCommand('copy');
    }
  }
};
</script>