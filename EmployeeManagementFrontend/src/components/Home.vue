<template>
  <h3 id="head" > All Registered Employee Names</h3>
  <button><router-link to="/employeeCreate" class="nav-link">Add New Employee</router-link></button>

  <div id="app">
    <table>
      <tr>
        <td><b>EmployeeId</b></td>
        <td><b>FirstName</b></td>
        <td><b>LastName</b></td>
        <td><b>Email</b></td>
        <td><b>PhoneNumber</b></td>
        <td><b>LocationId</b></td>
        <td><b>DepartmentId</b></td>
        <td><b>Action</b></td>
      </tr>

      <tr v-for="list of lists" v-bind:key="list.employeeId">
        <td>{{ list.employeeId }}</td>

        <td><input type="text" v-model="list.firstName" /></td>
        <td><input type="text" v-model="list.lastName" /></td>
        <td><input type="text" v-model="list.email" /></td>
        <td><input type="text" v-model="list.phoneNumber" /></td>
        <td><input type="text" v-model="list.locationId" /></td>
        <td><input type="text" v-model="list.departmentId" /></td>

        <td>
          <button
            v-on:click="
              PutApi(
                list.employeeId,
                list.firstName,
                list.lastName,
                list.email,
                list.phoneNumber,
                list.locationId,
                list.departmentId
              )
            "
          >
            Update
          </button>
        </td>

        <td><button v-on:click="DeleteApi(list.employeeId)">Delete</button></td>
      </tr>
    </table>
  </div>
</template>

<script>
import axios from "axios";

const baseUrl = "https://localhost:5001/api/employees/";

export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Home",

  data() {
    return {
      lists: [
        "firstName",
        "lastName",
        "email",
        "phoneNumber",
        "locationId",
        "departmentId",
      ],
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

    async DeleteApi(employeeId) {
      await axios

        .delete(baseUrl + employeeId)

        .then((resp) => {
          console.log(resp);

          this.GetApi();
        })

        .catch((err) => {
          console.log(err);
        });
    },

    async PutApi(
      employeeId,
      firstName,
      lastName,
      email,
      phoneNumber,
      locationId,
      departmentId
    ) {
      await axios

        .put(baseUrl + employeeId, {
          firstName: firstName,
          lastName: lastName,
          email: email,
          phoneNumber: phoneNumber,
          locationId: locationId,
          departmentId: departmentId,
        })

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

tr:nth-child(even){background-color: #04AA6D}

#head {
    font-family: Arial, Helvetica, sans-serif;
    color:gray;
    text-align: center;
    padding: 30px;
}
#th{
  color: black;
}
#th1{
  text-align: center;
}
</style>
