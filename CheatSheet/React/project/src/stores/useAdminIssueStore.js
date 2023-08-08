import { create } from "zustand";
import { getIssues } from "../api/Requests/admin";


const useAdminIssueStore = create((set) => ({
    issues:null,
    isLoading:true,
    search:'',
    setIssues:async(query)=>{
        try {
            set({isLoading:true});
            const response=await getIssues(query);
            if(response.status===200){
                set({issues:response.data});
            }
        } catch (error) {
            
        }
        finally{
            set({isLoading:false});
        }
    }
    

}))

export default useAdminIssueStore;