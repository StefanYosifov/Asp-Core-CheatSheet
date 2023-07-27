import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import YouTube from 'react-youtube';
import useCourseLessons from '../../stores/useCourseLessons';
import { Document, Page, pdfjs } from 'react-pdf';
import { PdfPage } from '../Helper components/PdfPage';


export const CourseVideo = () => {
    const { id } = useParams();

    const isLoading = useCourseLessons((state) => state.isLoading);
    const pdfFile = useCourseLessons((state) => state.pdfFile);
    const videoUrl = useCourseLessons((state) => state.videoUrl);
    const setCourseLessonData = useCourseLessons((state) => state.setCourseLessonData);
    const [numPages, setNumPages] = useState(null);
    const [pageNumber, setPageNumber] = useState(1);

    useEffect(() => {
        setCourseLessonData(id);
    }, [id]);


    return (
        <>
            <p>asdsadas</p>
                {isLoading && pdfFile ? (
                     <div className="w-full max-w-3xl mx-auto border border-gray-300 shadow-md">

                        <PdfPage url={pdfFile} />
                        <YouTube videoId={videoUrl}></YouTube>
                     </div>
                ) : (
                    <p>WAITING</p>
                )}
            
        </>
    );
};

