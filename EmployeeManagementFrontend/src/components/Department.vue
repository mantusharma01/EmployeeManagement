<!-- eslint-disable vue/no-parsing-error -->
<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <h3 id="head">Departments</h3>
    <form>
      <div class="form-group">
        <input type="text" class="form-control" v-model="departmentName" />
        <small class="form-text text-muted"> Enter New Department name </small>
        <button
          type="submit"
          class="btn btn-primary"
          v-on:click="PostApi(lists.departmentName)"
        >
          Save
        </button>
      </div>
    </form>

    <h3 id="head">All Available Departments Names</h3>
    <table class="table table-striped table-dark" id="tab">
      <tr>
        <td id="th"><b>DepartmentId</b></td>
        <td id="th"><b>DepartmentName</b></td>
        <td id="th1"><b>Action</b></td>
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
  name: "Department",

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
