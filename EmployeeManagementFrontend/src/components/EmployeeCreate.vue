<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <form action="/action_page.php">
    <div>
      <label for="firstName">First Name</label>
      <input
        type="text"
        id="firstname"
        class="form-control"
        v-model="userData.firstName"
      />
    </div>
    <div>
      <label for="lastName">Last Name</label>
      <input
        type="text"
        id="firstname"
        class="form-control"
        v-model="userData.lastName"
      />
    </div>
    <div>
      <label for="email"> Email </label>
      <input type="text" id="email" class="form-control" v-model="userData.email" />
    </div>
    <div>
      <label for="phoneNumber"> PhoneNumber </label>
      <input
        min="1"
        max="10"
        type="number"
        id="phoneNumber"
        class="form-control"
        v-model.number="userData.phoneNumber"
      />
    </div>
    <div>
      <label for="department">Department</label>
      <select id="department" class="form-control" v-model="selectedDepartment">
        <!-- <option v-for="department in departments">{{ department }}</option> -->
      </select>
    </div>
    <div>
      <label for="location">Location</label>
      <select id="location" class="form-control" v-model="selectedLocation">
        <!-- <option v-for="location in locations">{{ location }}</option> -->
      </select>
    </div>
  </form>

  <br />

  <button class="btn btn-primary" @click.prevent="submitted">Submit!</button>
</template>
<script>
//import axios from "axios";

export default {
  name: "EmployeeCreate",
  data() {
    return {
      userData: {
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
      },
      departments: ["High", "Medium", "Low"],
      locations: ["High", "Medium", "Low"],
    };
  },
  methods: {
    submitted(e) {
      this.axios
        .post("https://localhost:5001/api/employees", this.userData)
        .then((result) => {
          console.warn(result);
        });
      e.preventDefault();
    },
  },
};
</script>
