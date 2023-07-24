import { create } from "zustand"
import { getDetails } from "../api/Requests/details";
import { changeVisibility, deleteResource } from "../api/Requests/resources";
import { dislikeResource, likeResource } from "../api/Requests/likes";
import { toast } from "react-toastify";


const useDetailsStore = create((set) => ({
    isLoading: false,
    data: [],
    getResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await getDetails(id);
            set({ isLoading: false, data: response.data });
        }
        catch (error) {
            console.log(error.message);
        }
    },
    likeResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await likeResource(id);
            set((state) => ({
                ...state,
                data: {
                    ...state.data,
                    hasLiked: !state.data.hasLiked,
                    likes: state.data.likes + 1,
                },
            }));
            toast.success(response.data);
        } catch (error) {
            console.log(error.message);
        }
    },
    dislikeResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await dislikeResource(id);
            console.log(response);
            set((state) => ({
                ...state,
                data: {
                    ...state.data,
                    hasLiked: !state.data.hasLiked,
                    likes: state.data.likes - 1,
                },
            }));
            toast.success(response.data);
        } catch (error) {
            console.log(error.message);
        }
    },
    deleteResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await deleteResource(id);
            if (response.status === 200) {
                set((state) => ({
                    ...state,
                    data: {
                        ...state.data,
                        isPublic: !state.data.isPublic,
                    },
                }));
            }
            set({ isLoading: false });
        } catch (error) {
            set({isLoading: false});
        }
    },
    changeVisibility: async (id) => {
        try {
            set({ isLoading: true });
            const response = await changeVisibility(id);
            if (response.status === 200) {
                toast.success(response.data);
                set((state) => ({
                    ...state,
                    data: {
                        ...state.data,
                        isPublic: !state.data.isPublic,
                    },
                }));  
            }
            set({ isLoading: false });
        } catch (error) {
            toast.error(error);
        }
    }
})
)

export default useDetailsStore;