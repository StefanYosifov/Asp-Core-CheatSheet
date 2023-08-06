import { create } from "zustand";
import { createdTopic } from "../api/Requests/admin";
import { toast } from "react-toastify";

const useCreateTopicsModalStore = create((set) => ({
    isTopicModalOpen: false,
    topics: {
        videoName: '',
        videoUrl: '',
        topicName: '',
        topicContent: '',
        topicStartDate: '',
        topicEndDate: '',
    },
    updateData: (data) =>
        set((state) => ({
            topics: {
                ...state.topics,
                ...data,
            },
        })), clearComment: () => set({ comment: "" }
        ),
    setIsTopicModalOpen: () => {
        set((state) => ({ isTopicModalOpen: !state.isTopicModalOpen }));
    },
    sendData:async (courseName,data)=>{
        try {
            const response=await createdTopic(courseName,data);
            console.log(response.data);
            if(response.status===200){
                toast.success(response.data);
            }
        } catch (error) {
            toast.error(error);
        }
    }
}));

export default useCreateTopicsModalStore;