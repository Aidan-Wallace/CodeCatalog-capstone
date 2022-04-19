<template>
    <button type="button" @click="doCopy">Copy code snippet</button>
</template>

<script>
export default {
data: function () {
    return {
      message: "Copy code snippet",
    }
  },
  methods: {
    doCopy: function () {
      this.$copyText(this.message).then(
        function (e) {
          alert("Copied");
          console.log(e);
        },
        function (e) {
          alert("Can not copy");
          console.log(e);
        }
      );
    },
  },
}
</script>