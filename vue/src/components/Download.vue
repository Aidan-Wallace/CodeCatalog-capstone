<template>
    <a 
    :href="item.url"
    v-text="item.label"
    @click.prevent="downloadItem(item)" />
</template>

<script>
export default {
    methods: {
        downloadItem ({url, label}) {

        }
    }
}
</script>