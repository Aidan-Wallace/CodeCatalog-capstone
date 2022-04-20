<template>
  <div>
      <div v-on:click="() => myExample=!myExample ">
    <h1 > My Code</h1>
    </div>
    <div v-show="myExample" v-for="example in examples" :key="example.codeId">
        <catalog-example :example="example" />
       
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

<style></style>
