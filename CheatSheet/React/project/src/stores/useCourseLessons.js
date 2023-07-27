import { create } from "zustand";
import { getPdfFile } from "../api/Requests/pdfFile";
import { getVideoId } from "../api/Requests/videos";
import { toast } from "react-toastify";



const useCourseLessons = create((set) => ({
    isLoading: false,
    pdfFile: "",
    page: 1,
    videoUrl: "",
    setCourseLessonData: async (id) => {
        try {
            set({ isLoading: true });
            const responsePdf = await getPdfFile(id);
            const responseVideo = await getVideoId(id);
            if (responsePdf.status == 200) {
                set({ pdfFile: responsePdf.data });
            }
            if (responseVideo.status === 200) {
                set({ videoUrl: responseVideo.data });
            }
        } catch (error) {
            toast.error(error);
        }
        set({ isLoading: true });
    },
}))

export default useCourseLessons;