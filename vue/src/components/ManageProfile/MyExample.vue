<template>
  <div class="container">
    <button class="mycode" v-on:click="() => (myExample = !myExample)">
      My Code
    </button>
    <div class="myExample">
      <div
        class="example"
        v-show="myExample"
        v-for="example in examples"
        :key="example.codeId"
      >
        <catalog-example :example="example" />

        <div class="public-private">
          <button
            class="public"
            v-on:click.prevent="makePublic(example.codeId, 1)"
          >
            Make Public
          </button>
          <button
            class="private"
            v-on:click.prevent="makePublic(example.codeId, 0)"
          >
            Make Private
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileService from "@/services/ProfileService";
import CatalogExample from "../Snippet/CatalogExample.vue";

export default {
  components: { CatalogExample },
  name: "ManageProfile",
  data() {
    return {
      userId: this.$store.state.user.userId,
      examples: [],
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
    makePublic(codeId, status) {
      this.examples.forEach((example) => {
        if (example.codeId == codeId) {
          example.isPublic = status;

          ProfileService.makePublic(codeId, example)
            .then((response) => {
              if (200 <= response.status && response.status < 300) {
                //this.examples[i].pop();

                console.log("Code set to public.", response);
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
  },
};
</script>

<style>
.mycode {
  width: 15vw;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  margin-bottom: 30px;
  background-color: var(--paradise-pink);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 18px;
  color: #fff;
}
.mycode:hover {
  width: 1%;
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 20px;
}
@media (min-width: 768px) {
  .mycode {
    font-size: 24px;
    min-width: 196px;
  }
}
.myExample .example {
}
.public-private {
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  width: 15.5vw;
}
.public {
  width: 10vw;
  border: none;
  border-radius: 16px;
  margin-bottom: 40px;
  margin-right: 5px;
  background-color: var(--blue-ncs);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 10px;
  color: #fff;
}
.public:hover {
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 15px;
}
@media (min-width: 768px) {
  .public {
    font-size: 12.5px;
    min-width: 100px;
    max-height: 35px;
  }
}
.private {
  width: 10vw;
  border: none;
  border-radius: 16px;
  margin-bottom: 40px;
  margin-right: 5px;
  background-color: var(--blue-ncs);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 10px;
  color: #fff;
}
.private:hover {
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 15px;
}
@media (min-width: 768px) {
  .private {
    font-size: 12.5px;
    min-width: 100px;
    max-height: 35px;
  }
}
</style>
