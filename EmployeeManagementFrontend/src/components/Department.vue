<template>
  <div>
    <h1>Department</h1>
    <table border="2px">
      <tr>
        <td>DepartmentId</td>
        <td>DepartmentName</td>
        <td>Action</td>
      </tr>
      <tr v-for="item in list" v-bind:Key="item.id">
        <td>{{ item.departmentId }}</td>
        <td>{{ item.departmentName }}</td>

        <td><button v-on:click="UpdateUser(department.id)">Update</button></td>
        <td><button v-on:click="deleteUser(department.id)">Delete</button></td>
      </tr>
    </table>
    <router-link to="/DepartmentPost" v-on:click="CreateUser">Create</router-link>
  </div>
  <RouterView />
</template>

<script>
import axios from "axios";
export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Department",
  data() {
    return {
      list: ["departmentId", "departmentName"],
    };
  },
  async mounted() {
    let result = await axios.get("https://localhost:5001/api/departments");
    console.warn("api data", result.data);
    this.list = result.data;
  },
};
</script>
