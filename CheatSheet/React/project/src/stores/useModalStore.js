import { create } from "zustand";
import { getTopicSecondaryDetailsByTopicId, updateTopicSecondaryDetails } from "../api/Requests/admin";
import { toast } from "react-toastify";


const useModalStore = create((set) => ({
    isModalOpen: false,
    data:null,
    setModalIsOpen: () => {
        set((state) => ({ isModalOpen: !state.isModalOpen }));
      },
    setData:async(topicId)=>{
        try {
            const response=await getTopicSecondaryDetailsByTopicId(topicId);
            if(response.status===200){
                console.log(response.data);
                set({data:response.data});
            }
        } catch (error) {
            
        }
    },
    updateData: (newData) => set((state) => ({ data: { ...state.data, ...newData } })),
    sendUpdateRequest: async (topicId,data)=>{
        try {
            const response=await updateTopicSecondaryDetails(topicId,data);
            if(response.status===200){
                toast.success(response.data);
            }
        } catch (error) {
            toast.error(error);
        }finally{

        }
    }
}))


export default useModalStore;