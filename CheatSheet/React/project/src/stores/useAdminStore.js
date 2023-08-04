import { create } from "zustand";
import { getCategories } from "../api/Requests/categories";
import { getAdminCourses, getAdminTopicsByCourseName } from "../api/Requests/admin";
import { getCoursesCategories } from "../api/Requests/courses";


const useAdminStore = create((set) => ({
    categoriesAndFilters: null,
    categories: null,
    selectedCategory: null,

    filters:null,
    selectedFilter: null,

    courseNameDropDownList: null,
    selectedCourseName:null,
    searchInput:'',

    topics:null,

    details:null,

    setCategories: async () => {
        try {
            const response = await getCoursesCategories();
            if (response.status === 200) {
                console.log(response.data);
                set({ categories: response.data.categories});
                set({ filters: response.data.sortings });
            }
        } catch (error) {
            console.log(error);
        }
    },
    setDropDownListOfCourses: async (search) => {
        try {
            const response = await getAdminCourses(search);

            if (response.status === 200) {
                console.log(response.data);
                set({ courseNameDropDownList: response.data });
            }
        } catch (error) {
            console.log(error);
        }
    },
    setSelectedCategory: (value) => {
        if (value !== null) {
            set({ selectedCategory: value })
        }
    },
    setSelectedFilter:(value)=>{
        if (value !== null) {
            set({ selectedFilter: value })
        }
    },
    setSelectedCourseName:(value)=>{
        console.log(value);
        if(value){
            set({selectedCourseName:value})
        }
    },
    setSearchInput:(value)=>{
        if (value !== null) {
            set({ searchInput: value })
        }
    },
    setTopics: async (courseName,courseCollection)=>{
        try {
            const getCourse = courseCollection.find((course) => course.name === courseName);
            if (!getCourse) {
              console.log(`Course with name '${courseName}' not found.`);
              return;
            }


            console.log(getCourse.id);
            const response=await getAdminTopicsByCourseName(getCourse.id);
            if(response.status===200){
                set({topics:response.data});
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);

            }
        } catch (error) {
            console.log(error);
        }
    },
    setDetails:async(id)=>{
        
    }

}))

export default useAdminStore;