import { create } from "zustand"
import { deleteComment, editComment, getComments, sendAComment } from "../api/Requests/comments";
import { toast } from "react-toastify";
import { dislikeComment, likeComment } from "../api/Requests/likes";



const useCommentsStore = create((set) => ({
    isLoading: false,
    data: [],
    getAllComments: async (id) => {
        try {
            set({ isLoading: true });
            const response = await getComments(id);
            set({ isLoading: false, data: response.data });
        }
        catch (error) {
            console.log(error.message);
        }
    },
    submitAComment: async (comment, id) => {
        try {
            set({ isLoading: true });
            const response = await sendAComment({ comment, id });
            set((prevState) => ({ ...prevState, data: [...prevState.data, comment] }));
            set({ isLoading: false});
        }
        catch (error) {
            console.log(error.message);
        }
    },
    updateComment: async (commentId, newContent) => {
        set({ isLoading: true });
        const response = await editComment(commentId, newContent);
        console.log(response);
        if (response.status === 200) {
            set((state) => ({
                data: state.data.map((comment) =>
                    comment.id === commentId ? { ...comment, content: newContent } : comment
                ),
            }));
            toast.success(response.data);
        }
    },
    likeAComment: async (commentId) => {
        const response = await likeComment(commentId);
        console.log(response);

        if (response.status === 200) {
            set((state) => ({
                data: state.data.map((comment) =>
                comment.id === commentId
                  ? {
                      ...comment,
                      hasLiked: true, 
                      likeCount: !comment.hasLiked ? comment.likeCount + 1 : comment.likeCount,
                      hasDisliked: !comment.hasDisliked,
                    }
                  : comment
                ),
            }));
        }
    },
    dislikeAComment: async (commentId) => {
        const response = await dislikeComment(commentId);
        if (response.status === 200) {
            set((state) => ({
                data: state.data.map((comment) =>
                comment.id === commentId
                  ? {
                      ...comment,
                      hasLiked: false, 
                      likeCount: comment.hasLiked ? comment.likeCount - 1 : comment.likeCount,
                      hasDisliked: !comment.hasDisliked,
                    }
                  : comment
              ),
            }));
        }
    },
    deleteAComment: async (commentId) => {
        const response = await deleteComment(commentId);
        if (response.status === 200) {
            set((state) => ({
                data: state.data.filter((comment) => comment.id !== commentId),
            }));
            toast.success(response.data);
        }
        return response;
    }
}))

export default useCommentsStore;