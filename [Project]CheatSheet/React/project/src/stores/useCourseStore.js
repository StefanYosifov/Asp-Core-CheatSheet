import { create } from "zustand";
import { getAllCourses, getCourseDetailsPreview, getCoursePreviewDetailsExtra, getCoursesCategories, getFeaturedCourses,getCoursePreviewDetails } from "../api/Requests/courses";
import { toast } from "react-toastify";

const useCourseStore = create((set) => ({
    isFeaturedLoading: false,
    featuredCourses: null,
    searchInput: "",
    selectedCategories: [],
    categories: null,
    selectedSort: "",
    sortings: [],
    courses: [],
    totalPages:0,
    coursePreview:[],
    coursePreviewExtra:[],
    setFeaturedCourses: async () => {
        const response = await getFeaturedCourses();
        set({ isFeaturedLoading: true });
        if (response.status === 200) {
            set({
                featuredCourses: response.data,
                isFeaturedLoading: false,
            });
        }
        set({ isFeaturedLoading: false });

    },
    setFilteringData: async () => {
        const response = await getCoursesCategories();
        if (response.status === 200) {
            set({ categories: response.data.categories });
            set({ sortings: response.data.sortings });
        }
    },
    setSearchInput: (value) => {
        set({ searchInput: value });
    },
    setSelectedSort: (value) => {
        console.log(value);
        set({ selectedSort: value });
    },
    setSelectedCategories: (selectedCategories, value) => {
        if (!selectedCategories.includes(value)) {
            set({ selectedCategories: [...selectedCategories, value] });
        } else {
            const updatedCategories = selectedCategories.filter((category) => category !== value);
            set({ selectedCategories: updatedCategories });
        }
    },
    setCourses: async (page, query) => {
        const response=await getAllCourses(page,query);
        try{
            if(response.status===200){
                set({courses:response.data.courses});
                set({totalPages:response.data.totalPages});
            }
        }catch(error){
            toast.error(error);
        }
    },
    setCoursePreviewData:async(id)=>{
        const response=await getCoursePreviewDetails(id);
        if(response.status===200){
            set({coursePreview:response.data});
        }
    },
    setCoursePreviewExtraData:async(id)=>{
        const response=await getCoursePreviewDetailsExtra(id);
        if(response.status===200){
            set({coursePreviewExtra:response.data});
        }
    }
}));

export default useCourseStore;