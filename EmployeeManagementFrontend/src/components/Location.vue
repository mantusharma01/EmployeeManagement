<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <h3 id="head">Locations</h3>
    <form>
      <div class="form-group">
        <input type="text" class="form-control" v-model="locationData" />
        <small class="form-text text-muted"> Enter New Location name </small>
      </div>
      <button
        type="submit"
        class="btn btn-primary"
        v-on:click="PostApi(lists.locationData)"
      >
        Save
      </button>
    </form>

    <h3 id="head">All Available Locations Names</h3>
    <table>
      <tr>
        <td id="th"><b>LocationId</b></td>
        <td id="th"><b>LocationData</b></td>
        <td id="th1"><b>Action</b></td>
      </tr>
      <tr v-for="list of lists" v-bind:key="list.locationId">
        <td>{{ list.locationId }}</td>
        <td><input type="text" v-model="list.locationData" /></td>
        <td>
          <button v-on:click="PutApi(list.locationId, list.locationData)">Update</button>
        </td>
        <td><button v-on:click="DeleteApi(list.locationId)">Delete</button></td>
      </tr>
    </table>
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
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #04aa6d;
}

#head {
  font-family: Arial, Helvetica, sans-serif;
  color: gray;
  text-align: center;
  padding: 30px;
}
#th {
  color: black;
}
#th1 {
  text-align: center;
}
</style>
