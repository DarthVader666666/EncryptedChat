<template>
  <div id="app">
    <div id="theWarning" class="alert alert-warning" v-if="error">{{ error }}</div>
    <router-view/>
  </div>
</template>

<script>
import { mapState } from "vuex"
import store from "./store"
import chatHub from "./chatHub"

export default {
  store,
  computed: mapState([ "error" ]),

  monted() {
    chatHub.client.on("SendMessage", function (message) {

    });

    chatHub.start();
  }
}

</script>


<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
