<template>
  <div id="nav">
 <nav class="container navbar navbar-expand-lg navbar-light bg-light">
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        
        <div class="navbar-nav">
           
            <router-link to="/home" class="nav-item nav-link">Home</router-link>
            <router-link to="/employee" class="nav-item nav-link">Employee</router-link>
            <router-link to="/department" class="nav-link">Department</router-link>
            <router-link to="/location" class="nav-link">Location</router-link>
        </div>
       
    </div>
</nav>

 </div>
  <router-view/>
</template>

<script>

//import Department form './components/Department'
export default {
  name:"App",
  components:{
  //  Department
  }
};
  


</script>

<style>
 #nav{
background: whitesmoke;
}
#nav {
  padding: 30px;
  text-align: center;
}
#nav a {
  font-weight: bold;
  color: #2c3e50;
}
#nav a.router-link-exact-active {
  color: whitesmoke;
  background: crimson;
  border-radius: .5rem;
}
</style>