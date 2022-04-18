<template>
    <div class="downloads-container">
        <div 
        class="download-container"
        v-for="example in downloads"
        :key="example.codeId"
        >
        </div>
        <download 
    </div>
</template>

<script>
import CatalogExample from "@/Services/CatalogExample"
import Download from '@/Components/Download.vue'
export default {

}
</script>Download