import { create } from "zustand";

const useCommentStore = create((set) => ({
    comment: "",
    setComment: (newComment) => set({ comment: newComment }),
    clearComment: () => set({ comment: "" }),
  }));

export default useCommentStore;