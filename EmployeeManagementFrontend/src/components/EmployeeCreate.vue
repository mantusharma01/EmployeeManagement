<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <form action="/action_page.php">
    <div>
      <label for="firstName">First Name</label>
      <input
        type="text"
        id="firstName"
        class="form-control"
        v-model="userData.firstName"
      />
    </div>
    <div>
      <label for="lastName">Last Name</label>
      <input type="text" id="lastName" class="form-control" v-model="userData.lastName" />
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
      <select v-model="selected" class="form-control sl">
        <option v-for="list of lists" v-bind:key="list.departmentId">
          {{ list.departmentName }}
        </option>
      </select>
    </div>

    <div>
      <label for="location">Location</label>
      <select v-model="selected" class="form-control sl">
        <option v-for="list of listslocation" v-bind:key="list.loctionId">
          {{ list.locationData }}
        </option>
      </select>
    </div>

    <button class="btn btn-primary" @click.prevent="submitted">Submit!</button>
  </form>
</template>
<script>
import axios from "axios";

const baseUrl = "https://localhost:5001/api/departments/";

export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Department",

  data() {
    return {
      userData() {
        "firstName", "lastName", "email", "phoneNumber";
      },
      lists: ["departmentId", "departmentName"],
      listslocation: ["locationId", "locationData"],
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

    async Getlocation() {
      await axios

        .get("https://localhost:5001/api/locations/")

        .then((result) => {
          this.listslocation = result.data;
        })

        .catch((err) => {
          console.log(err);
        });
    },
  },

  mounted() {
    this.GetApi();
    this.Getlocation();
  },
};
</script>
