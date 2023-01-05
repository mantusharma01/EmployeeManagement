<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <form @submit="AddEmployee()">
    <div>
      <label for="firstName">First Name</label>
      <input
        type="text"
        id="firstName"
        class="form-control"
        v-model="firstName"
      />
    </div>
    <div>
      <label for="lastName">Last Name</label>
      <input type="text" id="lastName" class="form-control" v-model="lastName" />
    </div>
    <div>
      <label for="email"> Email </label>
      <input type="text" id="email" class="form-control" v-model="email" />
    </div>
    <div>
      <label for="phoneNumber"> PhoneNumber </label>
      <input
        type="text"
        id="phoneNumber"
        class="form-control"
        v-model.number="phoneNumber"
      />
    </div>
    <div>
      <label for="department">Department</label>
      <select v-model="selectedDepartment" @change="changeDepartment($event)" class="form-control sl" id="department">
        <option v-for="list of lists" :key="list.departmentId" :value="list.departmentId">
          {{ list.departmentName }}
        </option>
      </select>
    </div>

    <div>
      <label for="location">Location</label>
      <select v-model="selectedLocation" @change="changeLocation($event)" class="form-control sl" id="location">
        <option v-for="list of listslocation" v-bind:key="list.loctionId" :value="list.locationId"> 
          {{ list.locationData }}
        </option>
      </select>
    </div>

    <button class="btn btn-primary" type="submit" >Submit!</button>
  </form>
</template>
<script>
import axios from "axios";

const baseUrl = "https://localhost:5001/api/departments/";

export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: "EmployeeCreate",

  data() {
    return {
      firstName:"",
      lastName:"",
      email:"",
      phoneNumber:"",
      departmentId:0,
      locationId:0,
      userData:null,
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

    changeDepartment(event){
      this.departmentId=event.target.value;
    },
    
    changeLocation(event){
      this.locationId=event.target.value;
    },

    async AddEmployee(){
      await axios.post("https://localhost:5001/api/employees/",{
        firstName:this.firstName,
        lastName:this.lastName,
        email:this.email,
        phoneNumber:this.phoneNumber,
        locationId:this.locationId,
        departmentId:this.departmentId

      }).catch((err)=>{
        console.error(err)
      })

      

    }
  },

  mounted() {
    this.GetApi();
    this.Getlocation();
    this.AddEmployee();
  },
};
</script>
