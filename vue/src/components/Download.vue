<template>
    <a 
    :href="download.url"
    v-text="download.label"
    @click.prevent="downloadExample(download)" />
</template>

<script>
import axios from 'axios'
export default {
    name: 'Download',
    mounted() {
        this.downloadExample;
    },
    methods: {
        downloadExample ({url, label}) {
            axios.get(url, {responseType: 'blob'})
            .then(response => {
                const blob = new Blob([response.data], {type: 'application/JSON'})
                const link = document.createElement('a')
                link.href = URL.createObjectURL(blob)
                link.download = label
                link.click()
                URL.revokeObjectURL(link.href)
                }).catch(console.error)
        }
    },
}
</script>