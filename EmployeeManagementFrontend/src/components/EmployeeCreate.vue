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
                    <input type="text" id="firstName" class="form-control" v-model="firstName"
                      required  min="3"
                      @keyup="validateFirstName" placeholder="Empoloyee First Name"/>
                    <label for="firstName" class="invalid-warning" v-if="!isValidfstName">
                        Invalid First Name!
                    </label>
              </div>

              <div class="form-outline mb-4">
                    <input type="text" id="lastName" class="form-control" v-model="lastName"
                     required min="3" @keyup="validatelastName" placeholder="Empoloyee Last Name"/>
                    <label for="lastName" class="invalid-warning" v-if="!isValidlstName">
                        Invalid Last Name!
                    </label>
              </div>

              <div class="form-outline mb-4">
                    <input type="text" id="phoneNumber" class="form-control" v-model.number="phoneNumber"
                     required @keyup="validatePhoneNumber" maxlength="10"  placeholder="Empoloyee Phone Number"/>
                    <label for="phoneNumber" class="invalid-warning" v-if="!isValidphnNum">
                        Invalid Phone Number!
                    </label>
              </div>

              <div class="form-outline mb-4">
                    <input type="text" id="email" class="form-control" v-model="email"
                    required @keyup="validateEmailAddress" placeholder="Empoloyee Email Address" />
                    <label for="email" class="invalid-warning" v-if="!isValidEmail">
                        Invalid Email Address!
                    </label>
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
              <div class="row">
                <button type="submit"  :disabled='!isValidfstName || !isValidlstName || !isValidEmail || !isValidphnNum' 
                 class="btn btn-success btn-lg mb-1">Submit
                </button> &nbsp;&nbsp;
                <router-link to="/" custom v-slot="{ navigate }">
                    <button  class="btn btn-info btn-lg mb-1"
                       @click="navigate"
                        role="link">
                        Back
                    </button>
                  </router-link>
              </div>
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
      isValidfstName:true,
      isValidlstName:true,
      isValidphnNum:true,
      isValidEmail:true,
    };
  },

  methods: {
    validateFirstName() {
      const validationRegex = /^[A-Za-z]+$/;
      if (this.firstName.match(validationRegex)) {
        this.isValidfstName = true;
      } else {
        this.isValidfstName = false;
      }
    },
    validatelastName() {
      const validationRegex = /^[A-Za-z]+$/;
      if (this.lastName.match(validationRegex)) {
        this.isValidlstName = true;
      } else {
        this.isValidlstName = false;
      }
    },
    validatePhoneNumber() {
      const validationRegex = /^\d{10}$/;
      if (this.phoneNumber.match(validationRegex)) {
        this.isValidphnNum = true;
      } else {
        this.isValidphnNum = false;
      }
    },
     validateEmailAddress() {
      const validationRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;
      if (this.email.match(validationRegex)) {
        this.isValidEmail = true;
      } else {
        this.isValidEmail = false;
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
<style>
.invalid-warning {
  color: red;
}
</style>

