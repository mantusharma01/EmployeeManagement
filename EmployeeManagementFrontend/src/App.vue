<template>


<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand">EmployeeManagement</a>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item active">
          <a><router-link to="/home" class="nav-item nav-link"> Home </router-link></a> 
     
      </li>
      <li class="nav-item">
             <router-link to="/department" class="nav-link"> Department </router-link>
      </li>
      <li class="nav-item"> 
          <router-link to="/location" class="nav-link"> Location </router-link>
      </li>
    </ul>
  </div>
</nav>
  <router-view />
</template>

<script>

export default {
  name: "App",
  components: { 
  },
};
</script>
<style>
#app {
 
  margin-top: 60px;
}

@import'~bootstrap/dist/css/bootstrap.css'
</style>

