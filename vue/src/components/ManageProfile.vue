<template>
  <div>
    <h1>Manage Profile</h1>
  </div>
</template>

<script>
import ProfileService from "@/services/ProfileService";

export default {
  name: "ManageProfile",
  data() {
    return {
      userId: this.$store.state.currentUser,
      examples: {},
    };
  },

  methods: {
    getExamplesByUserId() {
      ProfileService.getExamples(this.userId)
        .then((response) => {
          if (200 <= response.status && response.status < 300) {
            console.log(response.status);

            this.examples = response.data;
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  created() {
    this.getExamplesByUserId();
  },
};
</script>

<style>
</style>