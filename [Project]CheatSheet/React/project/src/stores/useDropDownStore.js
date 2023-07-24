import { create } from "zustand";
import { getCategories } from "../api/Requests/categories";
import {shallow} from "zustand/shallow"

const useDropDownStore = create((set) => ({
    inputSearch:"",
    selectedCategory: "",
    categories: [],
    selectedSort:"",
    sorting:[],

    onChangeCategory:(value)=>{
        set({selectedCategory:value});
    },
    setCategories: async () => {
        const response = await getCategories();
        set({categories:response.data.categories});
        set({sorting:response.data.sorting});
    },
    onChangeSort:(value)=>{
        set({selectedSort:value});
    },
    onInputChange:(value)=>{
        set({inputSearch:value});
    }
}))


export default useDropDownStore;