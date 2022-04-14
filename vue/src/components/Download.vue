<template>
    <a 
    :href="download.url"
    v-text="download.label"
    @click.prevent="downloadExample({
        url: `https://localhost:8080/download/${codeId}`,
        label: 'Script download'
    })" />
</template>

<script>
import axios from 'axios'
export default {
  name: 'Download',
  methods: {
    async downloadItem({ url, label }) {
      const response = await axios.get(url, { responseType: 'blob' });
      const blob = new Blob([response.data], { type: 'application/json' });
      const link = document.createElement('a');
      link.href = URL.createObjectURL(blob);
      link.download = label;
      link.click();
      URL.revokeObjectURL(link.href);
    },
  },
};
</script>