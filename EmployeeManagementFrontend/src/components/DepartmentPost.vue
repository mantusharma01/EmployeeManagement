<template>
  <h1>Department ApI</h1>
  <hr />

  <div class="form-group">
    <input type="text" name="departmentName" v-model="departmentName" /> <br />
  </div>

  <div class="mt-3">
    <button class="btn btn-primary" v-on:click="addDepartment()">Add Department</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "DepartmentPost",
  data() {
    return {
      departmentName: "",
      isSuccess: false,
    };
  },

  methods: {
    async addDepartment() {
      let result = axios.post("https://localhost:5001/api/departments", {
        departmentName: this.departmentName,
      });
      console.warn(result);
    },
  },
};
</script>
