<template>
  <div id="app">
    <div id="nav">
      <nav>
        <router-link v-bind:to="{ name: 'home' }">Home</router-link
        >&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'Examples' }"> Catalog </router-link>
        <router-link
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
        >
          &nbsp;|&nbsp; Logout</router-link
        >
      </nav>
      <catalog-search />
    </div>
    <router-view />
  </div>
</template>

<script>
import CatalogSearch from "@/components/CatalogSearch";

export default {
  components: {
    CatalogSearch,
  },
};
</script>

<style>
#nav {
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: row;
}
</style>