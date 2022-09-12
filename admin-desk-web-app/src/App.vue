<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <div class="container-fluid">
      <i
        class="bi bi-robot"
        style="color: white; margin-left: 20px; width: 30px; scale: 2"
      ></i>
      <a class="navbar-brand" href="/">Admin Desk</a>

      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li v-for="item in navs" :key="item.text" class="nav-item">
            <a
              class="nav-link"
              :class="{ active: activeNav == item.link }"
              aria-current="page"
              :href="item.link"
            >
              {{ item.text }}
            </a>
          </li>
        </ul>
      </div>
    </div>
  </nav>
  <router-view></router-view>
</template>

<script>
export default {
  name: "app",

  data: () => ({
    activeNav: "/",
    navs: [
      { text: "Home", link: "/" },
      { text: "Report By Request", link: "/report1" },
      { text: "Report By Country", link: "/report2" },
    ],
  }),
  methods: {},
  mounted: function () {
    this.activeNav = location.pathname;
    console.log(this.activeNav);
  },
};
</script>
