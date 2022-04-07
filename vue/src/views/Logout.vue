<template>
<div>
  <h1>Logout</h1>
  <p>This page should never be displayed</p>
  </div>
</template>

<script>
export default {
  created() {
    this.$store.commit("LOGOUT");
    this.$router.push("/login");
  }
};
</script>
