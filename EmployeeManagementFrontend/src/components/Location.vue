<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <input type="text" v-model="locationData" v-on:keyup.enter="PostApi()" />

    <table border="4px">
      <tr>
        <td>LocationId</td>
        <td>LocationData</td>
        <td>Action</td>
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
