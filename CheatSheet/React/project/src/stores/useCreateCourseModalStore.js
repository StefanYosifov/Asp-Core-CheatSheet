import { create } from "zustand";
import { createdCourse } from "../api/Requests/admin";
import { toast } from "react-toastify";

const useCreateCourseModalStore = create((set) => ({
    isCreateModalOpen: false,
    course: {
        title: '1',
        description: '',
        price: '',
        imageUrl: '',
        startDate: '',
        endDate: '',
        summary: '',
        coverage: '',
      },
    setIsCreateModalOpen: () => {
        set((state) => ({ isCreateModalOpen: !state.isCreateModalOpen }));
    },
    updateData: (newData) => set((state) => ({ course: { ...state.course, ...newData } })
    ),
    saveData: async(data)=>{
        try {
            const response=await createdCourse(data);    
            if(response.status===200){
                toast.success(response.data);
            }   
        } catch (error) {
            toast.error(error);
        }
    },
}))

export default useCreateCourseModalStore;
