<!-- eslint-disable vue/multi-word-component-names -->

<template>
  <div>
    <h1>Location</h1>
    <table border="2px">
      <tr>
        <td>LocationId</td>
        <td>LocationData</td>
      </tr>
      <tr v-for="item in list" v-bind:Key="item.id">
        <td>{{ item.locationId }}</td>
        <td>{{ item.locationData }}</td>

      </tr>
    </table>
  </div>

</template>
  
<script>

import axios from 'axios';
export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: 'Location',
  data() {
    return {
     list: [
        "locationId",
        "locationData",
      ] 
    }
  },
  async mounted() {
    let result = await axios.get("https://localhost:5001/api/locations");
    console.warn("api data",result.data);
    this.list = result.data;
  }
};
</script>
  
  
<style>

</style>