<template>
  <div id="nav">
    <div class="title-logo">
      <img
        src="@/assets/cloudcodefinal.svg"
        alt="CodeCatalog Logo"
        v-on:click.prevent="goHome"
      />
      <h5 v-on:click.prevent="goHome">Code Cloud</h5>
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
      <i
        v-on:click="
          $router.push({
            name: 'ManageProfile',
          })"
        class="fa-solid fa-circle-user"
      ></i>
    </div>
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

<style scoped>
#nav {
  width: 100vw;
  border: 1px solid;
  height: 20%;
  min-height: 20%;

  display: grid;
  grid-template-columns: 1fr 2fr 1fr;
}

.title-logo {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
}

.title-logo > * {
  cursor: pointer;
}

.title-logo img {
  width: 50px;
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