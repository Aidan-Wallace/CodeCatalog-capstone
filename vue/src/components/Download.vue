<template>
    <download :href="item.url" v-text="item.label" @click.prevent="downloadItem(item)" />
</template>

<script>
import Axios from "axios";
export default {
  name: "Download",
  props: ["href"],
  methods: {
    downloadItem({ url, label }) {
      Axios.get(url, { responseType: "blob" })
        .then((response) => {
          const blob = new Blob([response.data], { type: "text/strings" });
          const link = document.createElement("download");
          link.href = URL.createObjectURL(blob);
          link.download = label;
          link.click();
          URL.revokeObjectURL(link.href);
        })
        .catch(console.error);
    },
  },
};
</script>