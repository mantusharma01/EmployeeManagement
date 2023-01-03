<template>
  <div id="app">
    <table border="4px">
      <tr>
        <td>EmployeeId</td>
        <td>FirstName</td>
        <td>LastName</td>
        <td>Email</td>
        <td>PhoneNumber</td>
        <td>LocationId</td>
        <td>DepartmentId</td>
        <td>Action</td>
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
  <button><router-link to="/employeeCreate" class="nav-link">Create</router-link></button>
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

<style></style>
