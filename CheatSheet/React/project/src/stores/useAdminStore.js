import { create } from "zustand";
import { getCategories } from "../api/Requests/categories";
import { getAdminCourses } from "../api/Requests/admin";
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
            console.log(response.data);

            if (response.status === 200) {
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
        if(value){
            set({selectedCourseName:value})
        }
    },
    setSearchInput:(value)=>{
        if (value !== null) {
            set({ searchInput: value })
        }
    }

}))

export default useAdminStore;