<template>
  <div>
    <h1>Manage Profile</h1>
    <h1>Edit My Code</h1>
    <div v-show="$store.state.user.role == 'admin'">
      Manage Pending
      <div v-for="example in pendingExamples" :key="example.codeId">
        <catalog-example :example="example" />
        <button v-on:click.prevent="updateExampleStatus(example.codeId, 1)">
          Approve
        </button>
        <button v-on:click.prevent="updateExampleStatus(example.codeId, 2)">
          Reject
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileService from "@/services/ProfileService";
import CatalogExample from "./CatalogExample.vue";

export default {
  components: { CatalogExample },
  name: "ManageProfile",
  data() {
    return {
      userId: this.$store.state.user.userId,
      examples: {},
      pendingExamples: [],
    };
  },

  methods: {
    getExamplesByUserId() {
      ProfileService.getExamples(this.userId)
        .then((response) => {
          if (200 <= response.status && response.status < 300) {
            this.examples = response.data;
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },
    getExamplesByStatus() {
      ProfileService.getPending()
        .then((response) => {
          if (200 <= response.status && response.status < 300) {
            this.pendingExamples = response.data;
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },
    updateExampleStatus(codeId, status) {
      this.pendingExamples.forEach((example, i) => {
        if (example.codeId == codeId) {
          example.submissionStatus = status;

          ProfileService.updateStatus(codeId, example)
            .then((response) => {
              if (200 <= response.status && response.status < 300) {
                this.pendingExamples[i].pop();

                console.log("Status updated", response);
              }
            })
            .catch((err) => {
              console.log(err);
            });
        }
      });
    },
  },
  created() {
    this.getExamplesByUserId();
    this.getExamplesByStatus();
  },
};
</script>

<style></style>
