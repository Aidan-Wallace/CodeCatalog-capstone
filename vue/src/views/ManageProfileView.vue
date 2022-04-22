<template>
  <div>
    <manage-profile />
    <my-example />
  </div>
</template>

<script>
import ManageProfile from "@/components/ManageProfile/ManageProfile";
import MyExample from "@/components/ManageProfile/MyExample";

export default {
  name: "ManageProfileView",
  components: {
    ManageProfile,
    MyExample,
  },
};
</script>
