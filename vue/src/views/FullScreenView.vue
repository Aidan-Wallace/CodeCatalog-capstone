<template>
  <full-screen-example :example="$route.params.example" />
</template>

<script>
import FullScreenExample from "@/components/FullScreenExample";

export default {
  name: "FullScreenView",
  components: {
    FullScreenExample,
  },
};
</script>