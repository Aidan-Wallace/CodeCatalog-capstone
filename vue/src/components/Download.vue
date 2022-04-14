<template>
    <a 
    :href="item.url"
    v-text="item.label"
    @click.prevent="downloadItem(item)" />
</template>

<script>
import axios from 'axios'
export default {
    methods: {
        downloadItem ({url, label}) {
            axios.get(url, {responseType: 'blob'})
            .then(response => {
                const blob = new Blob([response.data], {type: ''})
                const link = document.createElement('a')
                link.href = URL.createObjectURL(blob)
                link.download = label
                link.click()
                URL.revokeObjectURL(link.href)
                }).catch(console.error)
        }
    }
}
</script>