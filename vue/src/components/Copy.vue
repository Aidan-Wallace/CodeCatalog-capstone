<template>
  <div>
    <input type="text" placeholder="" v-model="message" />
    <button
      type="button"
      v-clipboard:copy="message"
      v-clipboard:success="onCopy"
      v-clipboard:error="onError"
    >
      Copy code example
    </button>
  </div>
</template>

<script>
export default {
  name: "Copy",
  data: function () {
    return {
      message: "The code example at hand will be copied to the clipboard.",
    };
  },
  methods: {
    onCopy: function (e) {
      alert("You just copied the following text to the clipboard: " + e.text);
    },
    onError: function (e) {
      alert("Sorry, the example was not copied.");
      console.log(e);
    },
  },
};
</script>
