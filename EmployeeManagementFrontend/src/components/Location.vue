<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <h3 id="head">Locations</h3>
    <form class="form-inline" name="form1">
      <div class="form-group mb-2">
        <input type="text" id="ltn" class="form-control" v-model="locationData"
         maxlength="15"
         placeholder="Enter Location name" oninvalid="this.setCustomValidity('Enter Department Name')"
         oninput="this.setCustomValidity('')" required />
      </div>
      <button
        type="submit"
        class="btn btn-primary mb-2"
        id="btnsubmit"
        v-on:click="PostApi(lists.locationData)"
      >
        Save
      </button>
    </form>

    <h3 id="head">All Available Locations Names</h3>
  <div class="container">
      <table class="table table-striped table-dark" >
      <tr>
        <td id="th"><b>LocationData</b></td>
        <td id="th1"><b>Action</b></td>
      </tr>
      <tr v-for="list of lists" v-bind:key="list.locationId">
        <td><input type="text" v-model="list.locationData" /></td>
        <td class="btn-group">
          <button class="btn btn-info" v-on:click="PutApi(list.locationId, list.locationData)">Update</button>
          <button class="btn btn-danger" v-on:click="DeleteApi(list.locationId)">Delete</button>
        </td>
      </tr>
    </table>
  </div>
  </div>
</template>

<script>
import axios from "axios";

const baseUrl = "https://localhost:5001/api/locations/";

export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Location",

  data() {
    return {
      lists: ["locationId", "locationData"],
    };
  },

  methods: {
    async GetApi() {
      await axios
        .get(baseUrl)
        .then((resp) => {
          this.lists = resp.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    async PostApi() {
      await axios
        .post(baseUrl, { locationData: this.locationData })
        .then((resp) => {
          console.log(resp);
          this.locationData = "";
          this.GetApi();
        })
        .catch((err) => {
          console.log(err);
        });
    },

    async DeleteApi(locationId) {
      await axios
        .delete(baseUrl + locationId)
        .then((resp) => {
          console.log(resp);
          this.GetApi();
        })
        .catch((err) => {
          console.log(err);
        });
    },

    async PutApi(locationId, locationData) {
      await axios
        .put(baseUrl + locationId, { locationData: locationData })
        .then((resp) => {
          console.log(resp);
          this.GetApi();
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },

  mounted() {
    this.GetApi();
  },
};
</script>
<style scoped>
table {
  border-collapse: collapse;
  width: 100%;
}
td {
  text-align:center;
}

tr:nth-child(even) {
  background-color: #515855;
}

#head {
  font-family: Arial, Helvetica, sans-serif;
  color: gray;
  text-align: center;
  padding: 20px;
}
#th {
  color: black;
}
#th1{
  text-align: left;
}

#btnsubmit{
  margin: 10px;
}
#ltn{
  margin-left: 10px;
  display: block;
  outline: none;
  border: 2px solid #eee;
  font-size: 20px;
  padding: 10px;
  background: #eee;
  border-radius: 6px;
}
#app{
  margin-top: 10px;
}

</style>
