<template>
  <div id="app">
    <div id="nav">
      <div class="title-logo">
        <img src="@/assets/codecat-logo.png" alt="" />
        <h5>Code Catalog</h5>
      </div>
      <catalog-search />

      <div class="menu-btns">
        <router-link v-bind:to="{ name: 'home' }" v-on:click="retrieveExample"
          >Home
        </router-link>
        <router-link v-bind:to="{ name: 'Catalog' }">Catalog</router-link>
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
  },
};
</script>

<style>
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

#app {
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