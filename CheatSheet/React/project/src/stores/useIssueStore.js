import { create } from "zustand";
import { getIssueCategories, postIssue } from "../api/Requests/issues";

const useIssueStore = create((set) => ({
    isOpen:false,
    issue:{
        title:'',
        location:[],
        description:'',
        IssueCategoryId:'',
    },
    setIsOpen:()=>{
        set((state) => ({ isOpen: !state.isOpen }));
    },
    setLocation: async () => {
        const response = await getIssueCategories(); 
        console.log(response.data);
        console.log(response.data);

        set((state) => ({
          issue: {
            ...state.issue,
            location: response.data, 
          },
        }));
      },
    sendIssue:async(data)=>{
        const response=postIssue(data).catch((error)=>console.log(error));
    },
    updateIssueProperty: (name,value) => {
      console.log(name);
      console.log(value);
        set((state) => ({
          issue: {
            ...state.issue,
            [name]: value,
          },
        }));
      },
}));

export default useIssueStore;