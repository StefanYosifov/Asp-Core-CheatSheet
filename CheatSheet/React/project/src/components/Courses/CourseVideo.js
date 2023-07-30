import { useEffect, useState, useRef } from 'react';
import { Link, useParams } from 'react-router-dom';
import YouTube from 'react-youtube';
import useCourseLessons from '../../stores/useCourseLessons';
import { Document, Page, pdfjs } from 'react-pdf';
import { PdfPage } from '../Helper components/PdfPage';
import WebViewer from '@pdftron/webviewer';



export const CourseVideo = () => {
    const { id } = useParams();

    const isLoading = useCourseLessons((state) => state.isLoading);
    const pdfFile = useCourseLessons((state) => state.pdfFile);
    const videoUrl = useCourseLessons((state) => state.videoUrl);
    const setCourseLessonData = useCourseLessons((state) => state.setCourseLessonData);
    const [numPages, setNumPages] = useState(null);
    const [pageNumber, setPageNumber] = useState(1);

    const viewer = useRef(null);
    useEffect(() => {
        setCourseLessonData(id);
    }, [id]);

    useEffect(() => {
        if (pdfFile) {
            WebViewer(
                {
                    path: '/lib',
                    licenseKey: 'demo:1690468731274:7c49d2c60300000000293f429259b048c56758548ea60240897bd88dd9',
                    disabledElements: [
                        'viewControlsButton',
                        'viewControlsOverlay'
                    ]
                },
                viewer.current
            ).then((instance) => {
                const { documentViewer } = instance.Core;
                documentViewer.loadDocument(pdfFile);
            });
        }
    }, [pdfFile]);




    return (
        <div className='bg-bgWhiteUI-0'>
            {isLoading && pdfFile && videoUrl ? (
                <>
                    <div className="w-full shadow-md flex-row divide-y border mx-4 mt-2">
                        <div className='h-128 mx-64 flex overflow-y-scroll justify-center items-center'>
                            <>
                                <div className='h-full w-full' ref={viewer}></div>
                            </>
                        </div>
                        <div className='my-2 mx-64 p-6 '>
                            <p className='font-sans text-sm'>You can temporarily view the pdf file in this link</p>
                            <Link to={pdfFile}><span className='hover:text-pinkUI-0 text-sm'>Click me</span></Link>
                        </div>
                    </div>
                    <div className='flex justify-center mt-4'>
                        <YouTube videoId={videoUrl} />
                    </div>
                </>
            ) : (
                <p>WAITING</p>
            )}

        </div>
    );
};

