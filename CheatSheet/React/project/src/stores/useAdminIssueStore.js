import { create } from "zustand";
import { getIssues, getIssuesFilteringCategories, resolveIssue } from "../api/Requests/admin";
import { toast } from "react-toastify";


const useAdminIssueStore = create((set) => ({
    issues: null,
    isLoading: true,
    search: '',
    filteringCategories: null,
    page:1,
    setIssues: async (query) => {
        try {
            set({ isLoading: true });
            const response = await getIssues(query);
            if (response.status === 200) {
                set({ issues: response.data });
            }
        } catch (error) {

        }
        finally {
            set({ isLoading: false });
        }
    },
    setFilteringCategories: async () => {
        try {
            set({ isLoading: true });
            const response = await getIssuesFilteringCategories();
            if (response.status === 200) {
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);
                console.log(response.data);

                set({ filteringCategories: response.data });
            }
        } catch (error) {
            console.log(error);
        }
        finally {
            set({ isLoading: false });
        }
    },
    resolveIssue: async (issueId) => {
        try {
          const response = await resolveIssue(issueId);
          if (response.status === 200) {
            set((state) => ({
              issues: state.issues.filter((issue) => issue.id !== issueId),
            }));
            toast.success(response.data);
          }
        } catch (error) {
          toast.error(error);
        }
      },
    modifyPage:(value)=>{
        set({page:value});
    }

}))

export default useAdminIssueStore;