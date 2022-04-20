<template>
  <div>
    <button v-on:click="() => (myExample = !myExample)">My Code</button>

    <div v-show="myExample" v-for="example in examples" :key="example.codeId">
      <catalog-example :example="example" />
      <button v-on:click.prevent="makePublic" :value="codeId">
        Make Public
      </button>
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
      myExample: false,
    };
  },

  methods: {
    getExamplesByUserId() {
      ProfileService.getExamples(this.userId)
        .then((response) => {
          if (200 <= response.status && response.status < 300) {
            this.example = response.data;
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },
    makePublic(event) {
      console.log(event);
      //   this.examples.forEach((example, i) => {
      //     if (example.codeId == codeId) {
      //       example.isPublic = 1;

      //       ProfileService.makePublic(this.codeId, example)
      //         .then((response) => {
      //           if (200 <= response.status && response.status < 300) {
      //             this.pendingExamples[i].pop();

      //             console.log("Code set to public.", response);
      //           }
      //         })
      //         .catch((err) => {
      //           console.log(err);
      //         });
      //     }
      //   });
    },
  },
  created() {
    this.getExamplesByUserId();
  },
};
</script>

<style></style>
