<!-- eslint-disable vue/no-parsing-error -->
<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div id="app">
    <h3 id="head">Departments</h3>
    <form class="form-inline" name="form1">
        <div class="form-group mb-2" >
        <input type="text" id="dept" name="deptName"  v-model="departmentName" maxlength="15" 
         placeholder="Enter Department Name" required 
         @keyup="validateDepartmentName"
         >
        </div>
        <button id="btnsubmit"
          type="submit"
          class="btn btn-primary mb-2"
          :disabled='!isValidDeptName'
          v-on:click="PostApi(lists.departmentName)">
          Save
        </button>
        <label for="dept" class="invalid-warning" v-if="!isValidDeptName">
            Invalid Department Name!
        </label>
    </form>
    <h3 id="head">All Available Departments Names</h3>
    <div class="container">
      <table class="table table-striped table-dark">
        <tr>
            <td id="th"><b>DepartmentName</b></td>
            <td id="th1"><b>Action</b></td>
        </tr>
      <tr v-for="list of lists" v-bind:key="list.departmentId">
        <td><input type="text" v-model="list.departmentName" /></td>
        <td class="btn-group">
          <button class="btn btn-info" @keyup="validateDepartmentName" 
          :disabled='!isValidDeptName'
          v-on:click="PutApi(list.departmentId, list.departmentName)">
            Update</button>
          <button class="btn btn-danger" v-on:click="DeleteApi(list.departmentId)">Delete</button></td>
      </tr>
    </table>
    </div>

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
      isValidDeptName:true,
    };
  },

  methods: {
  validateDepartmentName() {
      const validationRegex = /^[A-Za-z]+$/;
      if (this.departmentName.match(validationRegex)) {
        this.isValidDeptName = true;
      } else {
        this.isValidDeptName = false;
      }
    }, 
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
  text-align:center;
}

tr:nth-child(even) {
  background-color: #515855;
}

#head {
  font-family: Arial, Helvetica, sans-serif;
  color: grey;
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
#dept{
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
  margin: 0px;
  background-color: rgb(182, 222, 222);
 
}

.invalid-warning {
  color: red;
}

</style>
