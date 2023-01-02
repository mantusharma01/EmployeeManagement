<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <input type="text" v-model="departmentName" v-on:keyup.enter="PostApi()" />

    <table border="4px">
      <tr>
        <td>DepartmentId</td>
        <td>DepartmentName</td>
        <td>Action</td>
      </tr>

      <tr v-for="list of lists" v-bind:key="list.departmentId">
        <td>{{ list.departmentId }}</td>
        <td><input type="text" v-model="list.departmentName" /></td>

        <td>
          <button v-on:click="PutApi(list.departmentId, list.departmentName)">
            Update
          </button>
        </td>

        <td><button v-on:click="DeleteApi(list.departmentId)">Delete</button></td>
      </tr>
    </table>
  </div>
</template>

<script>
import axios from "axios";

const baseUrl = "https://localhost:5001/api/departments/";

export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Location",

  data() {
    return {
      lists: ["departmentId", "departmentName"],
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

        .post(baseUrl, { departmentName: this.departmentName })

        .then((resp) => {
          console.log(resp);

          this.departmentName = "";

          this.GetApi();
        })

        .catch((err) => {
          console.log(err);
        });
    },

    async DeleteApi(departmentId) {
      await axios

        .delete(baseUrl + departmentId)

        .then((resp) => {
          console.log(resp);

          this.GetApi();
        })

        .catch((err) => {
          console.log(err);
        });
    },

    async PutApi(departmentId, departmentName) {
      await axios

        .put(baseUrl + departmentId, { departmentName: departmentName })

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
