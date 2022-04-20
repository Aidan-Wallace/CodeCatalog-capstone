<template>
  <div>
    <manage-profile />
    <my-example />
  </div>
</template>

<script>
import ManageProfile from "@/components/ManageProfile";
import MyExample from "@/components/MyExample";

export default {
  name: "ManageProfileView",
  components: {
    ManageProfile,
    MyExample,
  },
};
</script>

<style>
</style>