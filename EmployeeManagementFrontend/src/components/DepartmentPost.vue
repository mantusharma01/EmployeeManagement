<template>
    <div>
    <form @submit="PostData" method="post">
    <input type="text" name = "DepartmentName" placeholder="DepartmentName" v-model="posts.DepartmentName"> 
       <br><br>

       <button type="Create">Post</button>
   
    
   </form>
    </div>
</template>
<script>
export default {
    name:"DeaprtmentPost",
    data(){
        return{
            posts:[
                "DepartmentName",
        ]
        }

    },
    methods:{
        PostData(e)
        {
            this.axios.post("https://localhost:5001/api/departments".this.posts)
            .then((result)=>{
                console.warn(result)

            })
            console.warn(this.posts)
            e.preventDefault();
            

        }

    }

    }

</script>