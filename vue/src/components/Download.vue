<template>
    <a 
    :href="{ exampleId }.url"
    v-text="example.label"
    @click.prevent="downloadExample(example)" />
</template>

<script>
import axios from 'axios'
export default {
    name: 'Download',
    props: {
        exampleId: Number
    },
    created() {
        
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
    }
}
</script>