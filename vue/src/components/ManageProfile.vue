<template>
  <div class="container">
    <div id="title"><h1>Manage Profile</h1></div>
    <div id="username"><h4>Username: {{this.$store.state.user.username}}</h4></div>
    <div class="buttons">
    <button class="button">Manage Profile</button>
    <!-- <button class="button">Edit My Code</button> -->
    <div class="managepending" v-show="$store.state.user.role == 'admin'">
      Manage Pending
      </div>
      <div class="managependingdupe" v-show="$store.state.user.role == 'admin'">
      <div v-for="example in pendingExamples" :key="example.codeId">
        <catalog-example :example="example" />
        <button class="approve" v-on:click.prevent="updateExampleStatus(example.codeId, 1)">
          Approve
        </button>
        <button class="reject" v-on:click.prevent="updateExampleStatus(example.codeId, 2)">
          Reject
        </button>
      </div>
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
    
    this.getExamplesByStatus();
  },
};
</script>

<style>
.container{
  justify-content: center;
  display: flex;
  align-items: center;
  flex-direction: column;
}
.buttons{
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
}
.managepending{
  display:flex;
  justify-content: center;
  align-items:center;
  width: 15vw;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  margin-bottom: 10px;
  background-color: var(--paradise-pink);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 18px;
  color: #fff;
}
.managepending:hover{
  width: 1%;
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 20px;
}
@media (min-width: 768px) {
  .managepending {
    font-size: 24px;
    min-width: 196px;
  }
}
.approve{
width: 10vw;
  border: none;
  border-radius: 16px;
  margin-bottom: 40px;
  margin-right:5px;
  background-color: var(--blue-ncs);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 10px;
  color: #fff;
}
.approve:hover{
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 15px;
}
@media (min-width: 768px) {
  .approve {
    font-size: 12.5px;
    min-width: 100px;
    max-height:35px;
  }
}
.reject{
width: 10vw;
  border: none;
  border-radius: 16px;
  margin-bottom: 40px;
  margin-right:5px;
  background-color: var(--blue-ncs);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 10px;
  color: #fff;
}
.reject:hover{
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 15px;
}
@media (min-width: 768px) {
  .reject {
    font-size: 12.5px;
    min-width: 100px;
    max-height:35px;
  }
}
#title h1{
  display:flex;
  justify-content: center;
  padding-top: 10pt;
  font-weight: bold;
}
#username h4{
  display:flex;
  justify-content: center;
  font-weight: bold;
  font-style:italic;
}
.button{
  width: 15vw;
  border: none;
  border-radius: 16px;
  margin-top: 10px;
  margin-bottom: 10px;
  background-color: var(--paradise-pink);
  height: 3rem;
  box-shadow: 0 0 6px rgba(0, 0, 0, 0.4);
  transition: all 0.1s linear;
  font-size: 18px;
  color: #fff;
}
.button:hover{
  width: 1%;
  box-shadow: 0 0 16px rgba(0, 0, 0, 0.4);
  font-size: 20px;
}
@media (min-width: 768px) {
  .button {
    font-size: 24px;
    min-width: 196px;
  }
}
</style>
