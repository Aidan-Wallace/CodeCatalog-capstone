<template>
  <div>
    <catalog-example />
  </div>
</template>

<script>
import CatalogExample from "@/components/CatalogExample";

export default {
  name: "ExampleView",
  components: {
    CatalogExample,
  },
  methods: {

  },

  data() {
    return {
      CatalogExample: {
        category: '',
        title: '',
        language: '',
        level: '',
        entryDate: '',
        //codeExample:
      },
    }
  },
};
</script>