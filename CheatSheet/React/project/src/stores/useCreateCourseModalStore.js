import { create } from "zustand";
import { createdCourse } from "../api/Requests/admin";
import { toast } from "react-toastify";
import { getCoursesCategories } from "../api/Requests/courses";

const useCreateCourseModalStore = create((set) => ({
    isCreateModalOpen: false,
    categories: [],
    course: {
        courseName: '1',
        courseDescription: '',
        coursePrice: '',
        courseImageUrl: '',
        startDate: '',
        endDate: '',
        summary: '',
        courseCoverage: '',
        courseCategories: []
    },
    getCourseCategories: async () => {
        try {
            const response = await getCoursesCategories();
            console.log(response);
            if (response.status === 200) {
                set({ categories: response.data.categories });
            }
        } catch (error) {

        }
    },
    setCoursesCategories: (value) => {
        set((state) => {
            const prevCategories = state.course.courseCategories || [];

            if (!prevCategories.includes(value)) {
                return { ...state, course: { ...state.course, courseCategories: [...prevCategories, value] } };
            } else {
                const updatedCategories = prevCategories.filter((category) => category !== value);
                return { ...state, course: { ...state.course, courseCategories: updatedCategories } };
            }
        });
    },
    removeCategory: (value) => {
        set((state) => {
            const prevCategories = state.course.courseCategories || [];

            const updatedCategories = prevCategories.filter((category) => category !== value);
            return { ...state, course: { ...state.course, courseCategories: updatedCategories } };
        });
    },
    setIsCreateModalOpen: () => {
        set((state) => ({ isCreateModalOpen: !state.isCreateModalOpen }));
    },
    updateData: (newData) => set((state) => ({ course: { ...state.course, ...newData } })
    ),
    saveData: async (data) => {
        try {
            console.log(`SEND`);
            const response = await createdCourse(data);
            if (response.status === 200) {
                toast.success(response.data);
            }
        } catch (error) {
            toast.error(error);
        }
    },
}))

export default useCreateCourseModalStore;
