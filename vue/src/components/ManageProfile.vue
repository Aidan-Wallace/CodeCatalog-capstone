<template>
  <div>
    <h1>Manage Profile</h1>
  </div>
</template>

<script>
import ProfileService from "@/services/ProfileService";

export default {
name: "ManageProfile",
data(){
    return {
        userId:null,
    }
},
computed: {
    getExamplesByUserId(){
        let examples;
        ProfileService.getExamples(this.userId)
        .then((response) => {
            console.log(response);
            if(response==202){
                examples=response;  
            }
        })
        .catch((err) => {
          console.log(err);
        });
        return examples;
    },
},
}
</script>

<style>
</style>