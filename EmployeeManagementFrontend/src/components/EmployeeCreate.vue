<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <section class="h-100 h-custom" style="background-color: #8fc4b7;">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-lg-8 col-xl-6">
        <div class="card rounded-3">
          <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/img3.webp"
            class="w-100" style="border-top-left-radius: .3rem; border-top-right-radius: .3rem;"
            alt="Sample photo">
          <div class="card-body p-4 p-md-5">
            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5 px-md-2">Registration Info</h3>
            <form class="px-md-2" @submit="AddEmployee()">
              <div class="form-outline mb-4">
                    <input type="text" id="firstName" class="form-control" v-model="firstName"/>
                    <label class="form-label" for="firstName">Empoloyee First Name</label>
              </div>

              <div class="form-outline mb-4">
                    <input type="text" id="lastName" class="form-control" v-model="lastName"/>
                    <label class="form-label" for="lastName">Empoloyee Last Name</label>
              </div>
              <div class="form-outline mb-4">
                    <input type="text" id="phoneNumber" class="form-control" v-model.number="phoneNumber"/>
                    <label class="form-label" for="lastName">Empoloyee Phone Number</label>
              </div>
              <div class="form-outline mb-4">
                    <input type="text" id="email" class="form-control" v-model="email" />
                    <label class="form-label" for="lastName">Empoloyee Email Address</label>
              </div>

              <div class="row">
                <div class="col-md-6 mb-4">
                   <select v-model="selectedDepartment" @change="changeDepartment($event)" class="form-control sl" id="department">
                        <option v-for="list of lists" :key="list.departmentId" :value="list.departmentId">
                             {{ list.departmentName }}
                        </option>
                   </select>
                   <label for="department">Department</label>
                </div>
                <div>      
                    <select v-model="selectedLocation" @change="changeLocation($event)" class="form-control sl" id="location">
                         <option v-for="list of listslocation" v-bind:key="list.loctionId" :value="list.locationId"> 
                              {{ list.locationData }}
                          </option>
                    </select>
                    <label for="location">Location</label>
                </div>
              </div>
              <button type="submit" class="btn btn-success btn-lg mb-1">Submit</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
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

