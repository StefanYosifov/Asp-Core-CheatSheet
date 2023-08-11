import { create } from "zustand";
import { getDetails } from "../api/Requests/details";
import { changeVisibility, deleteResource, editResource, getResourceToEdit } from "../api/Requests/resources";
import { dislikeResource, likeResource } from "../api/Requests/likes";
import { toast } from "react-toastify";
import { resourceFormValidator } from "../constants/ResourceConstants/ResourceFormValidator";


const useDetailsStore = create((set) => ({
    isLoading: false,
    data: [],
    editData: [],
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
    getResourceEditData: async (id) => {
        try {
            set({ isLoading: true });
            const response = await getResourceToEdit(id);
            set({ isLoading: false, editData: response.data });
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
            set({ isLoading: false });
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
    },
    addCategory: (value) => {
        set((state) => {
          const isCategorySelected = state.editData.chosenCategories.some(
            (category) => category.name === value
          );
      
          if (isCategorySelected) {
            return state;
          }
      
          const categoryToAdd = state.editData.allAvailableCategories.find(
            (category) => category.name === value
          );
      
          if (!categoryToAdd) {
            return state; 
          }
      
          const updatedCategories = [
            ...state.editData.chosenCategories,
            {
              id: categoryToAdd.id,
              name: value,
            },
          ];
      
          return {
            ...state,
            editData: {
              ...state.editData,
              chosenCategories: updatedCategories,
            },
          };
        });
      },
    removeCategory: (value) => {
        console.log(value);
        set((state) => {
            console.log(state.editData.chosenCategories);
            const isCategorySelected = state.editData.chosenCategories.some((ctg) => ctg.name === value);
            console.log(isCategorySelected);

            if (!isCategorySelected) {
                return state;
            }

            const updatedCategories = state.editData.chosenCategories.filter(
                (category) => category.name !== value
            );

            return {
                ...state,
                editData: {
                    ...state.editData,
                    chosenCategories: updatedCategories,
                },
            };
        });

    },
    setEditedResource: async (id, resource) => {
        const errors=resourceFormValidator(resource);
        if(Object.values(errors).length>0){
            Object.values(errors).forEach((error)=>toast.error(error));
            return;
        }

        try {
            set({ isLoading: true });
            const response = await editResource(id, resource);
            console.log(response);
            toast.success(response.data);
            set({ isLoading: false });
        }
        catch (error) {
            console.log(error.message);
        }
    },
    setEditData: (newEditData) => {
        set((state) => ({
            editData: {
                ...state.editData,
                ...newEditData,
            },
        }));
    }
}))


export default useDetailsStore;