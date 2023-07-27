import { create } from "zustand"
import { getPublicResources } from "../api/Requests/resources";

const useResourceListStore = create((set) => ({
    isLoading: false,
    data: [],
    pageCount: 0,

    setResourceList: async (id, search) => {
        try {
            search = String(search).replace('+', '');
            set({ isLoading: true });
            const response = await getPublicResources(id, search);
            set({
                data: response.data.resources,
                pageCount: response.data.totalPageCount,
                isLoading: false,
            });
            return response;
        }
        catch (error) {
            console.log(error.message);
        }
    },
})
)

export default useResourceListStore;