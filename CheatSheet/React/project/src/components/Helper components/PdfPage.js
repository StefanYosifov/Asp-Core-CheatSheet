import React, { useState } from 'react'
import { Document, Page, pdfjs } from 'react-pdf';
import 'react-pdf/dist/esm/Page/AnnotationLayer.css';
import 'react-pdf/dist/esm/Page/TextLayer.css';

pdfjs.GlobalWorkerOptions.workerSrc = new URL(
    'pdfjs-dist/build/pdf.worker.min.js',
    import.meta.url,
).toString();

export const PdfPage = ({ url }) => {
    console.log(url);
    const [numPages, setNumPages] = useState(null);
    const [pageNumber, setPageNumber] = useState(1);

    function onDocumentLoadSuccess({ numPages }) {
        setNumPages(numPages);
        setPageNumber(1);
    }

    function changePage(offSet) {
        setPageNumber(prevPageNumber => prevPageNumber + offSet);
    }

    function changePageBack() {
        changePage(-1)
    }

    function changePageNext() {
        changePage(+1)
    }


    const options = {
        standardFontDataUrl: `https://unpkg.com/pdfjs-dist@${pdfjs.version}/standard_fonts`,
    };
    return (
        <>
            <header>
                <Document file={url}
                    onLoadSuccess={onDocumentLoadSuccess}>
                    <div className='w-1/12'>
                        <Page pageNumber={Number(pageNumber)} />
                    </div>
                </Document>
                <div className='bg-slate-700 flex'>
                    <p> Page {pageNumber} of {numPages}</p>

                    {pageNumber > 1 &&
                        <button onClick={changePageBack}>Previous Page</button>
                    }
                    {
                        pageNumber < numPages &&
                        <button onClick={changePageNext}>Next Page</button>
                    }
                </div>
            </header>
            <center>
                <div>
                    <Document file={url} onLoadSuccess={onDocumentLoadSuccess}>
                        {Array.from(
                            new Array(numPages),
                            (el, index) => (
                                <Page
                                    key={`page_${index + 1}`}
                                    pageNumber={index + 1}
                                />
                            )
                        )}
                    </Document>
                </div>
            </center>
        </>
    );
}