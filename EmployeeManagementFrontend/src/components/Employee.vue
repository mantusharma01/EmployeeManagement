<template>
  <div>
    <h1>Employee</h1>
    <table border="2px">
      <tr>
        <td>EmployeeId</td>
        <td>FirstName</td>
        <td>LastName</td>
        <td>Email</td>
        <td>PhoneNumber</td>
        <td>LocationId</td>
        <td>DepartmentId</td>
      </tr>
      <tr v-for="item in list" v-bind:Key="item.id">
        <td>{{ item.employeeId }}</td>
        <td>{{ item.firstName }}</td>
        <td>{{ item.lastName }}</td>
        <td>{{ item.email }}</td>
        <td>{{ item.phoneNumber }}</td>
        <td>{{ item.locationId }}</td>
        <td>{{ item.departmentId }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
import axios from "axios";
export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Location",
  data() {
    return {
      list: [
        "employeeId",
        "firstName",
        "lastName",
        "email",
        "phoneNumber",
        "locationId",
        "departmentId",
      ],
    };
  },
  async mounted() {
    let result = await axios.get("https://localhost:5001/api/Employees");
    console.warn("api data", result.data);
    this.list = result.data;
  },
};
</script>

<style></style>
