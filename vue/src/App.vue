<template>
  <div id="app">
    <div id="nav">
      <div class="title-logo">
        <img
          src="@/assets/codecat-logo.png"
          alt="CodeCatalog Logo"
          v-on:click.prevent="goHome"
        />
        <h5 v-on:click.prevent="goHome">Code Catalog</h5>
      </div>
      <catalog-search />

      <div class="menu-btns">
        <router-link v-bind:to="{ name: 'home' }" v-on:click="retrieveExample"
          >Home
        </router-link>
        <router-link v-bind:to="{ name: 'Catalog' }">Catalog</router-link>
        <router-link v-bind:to="{ name: 'addExample' }">Add Code</router-link>
        <router-link
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
        >
          Logout</router-link
        >
        <router-link
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token == ''"
        >
          Log In</router-link
        >
        <i class="fa-solid fa-circle-user"></i>
      </div>
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
  methods: {
    retrieveExample() {},
    goHome() {
      this.$router.push({ path: "/" });
    },
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@400;700;900&display=swap");

* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

body {
  /* IMPORTED FONT FAMILIES
  - Roboto
    - font weights: 400(regular), 700(bold), 900(black)
   */

  font-family: Roboto, sans-serif;
  font-weight: 400;
}

#nav {
  width: 100vw;
  border: 1px solid;
  height: 5vh;

  display: grid;
  grid-template-columns: 1fr 2fr 1fr;
}

.title-logo {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.title-logo > * {
  cursor: pointer;
}

.title-logo img {
  width: 50px;
}

nav {
  font-size: 1.2rem;
  display: flex;
  flex-direction: row;
}

.menu-btns {
  display: flex;
  justify-content: space-evenly;
  align-items: center;
}

.menu-btns {
  text-decoration: none;
}

.menu-btns *:visited {
  color: black;
}

.menu-btns i:hover {
  box-shadow: 0 0 8px rgba(0, 0, 0, 0.4);
}

router-link {
  width: fit-content;
}
</style>