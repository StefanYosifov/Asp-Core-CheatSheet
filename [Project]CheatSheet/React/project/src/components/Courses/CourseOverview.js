import { useEffect, useState } from "react";
import { BsCheck, BsClock, BsGraphUp, BsPeople, BsYoutube } from "react-icons/bs";
import { Link, useLocation, useNavigate, useParams } from "react-router-dom";
import YouTube, { YouTubeProps } from 'react-youtube';
import useCourseStore from "../../stores/useCourseStore";
import { Accordion } from "../Helper components/Accordion";
import { URLS } from "../../constants/URLConstants";
import { AiOutlineFilePdf, AiOutlinePlayCircle } from "react-icons/ai"
import { GrCertificate } from "react-icons/gr"


const HeaderView = () => {
    return (
        <div>
            <div className="bg-pinkUI-0 w-full h-96">
                <div className="flex">
                    <section className="flex-row justify-center w-5/12 ml-56 mt-12 text-slate-100 font-sans">
                        <h1 className="font-bold text-3xl">GETTING STARTED WITH JS</h1>
                        <p className="text-lg my-4">
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui
                            maiores a natus quo dignissimos, perferendis ipsa, architecto
                            assumenda omnis libero blanditiis molestias exercitationem sunt
                            earum repellat iste asperiores ipsam odio.
                        </p>
                        <div class="flex flex-row text-sm">
                            <div className="mx-1">
                                <span>Star Course</span>
                            </div>
                            <div className="mx-1">
                                <span>1000 people</span>
                                <BsPeople className="w-6" />
                            </div>
                            <div className="mx-1">
                                <span>Intermediate</span>
                                <BsGraphUp className="w-6 " />
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    );
};

const Main = () => {
    const { id } = useParams();
    const location = useLocation();
    const navigate = useNavigate();
    const [activeTab, setActiveTab] = useState("tab1");

    const previewDetails = useCourseStore((state) => state.coursePreview);
    const previewDetailsExtra = useCourseStore((state) => state.coursePreviewExtra);

    const setPreviewDetails = useCourseStore((state) => state.setCoursePreviewData);
    const setPreviewDetailsExtra = useCourseStore((state) => state.setCoursePreviewExtraData);

    const opts = {
        width: '100%',
        height: '250px'
    };

    const navigateURL=`${URLS.COURSES_JOIN}${id}`;

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    useEffect(() => {

        setPreviewDetails(id);
        setPreviewDetailsExtra(id);
    }, [location]);


    console.log(previewDetails);
    console.log(previewDetailsExtra);


    return (
        <>
            <div className="flex">
                <div className="w-1/2 ml-56 rounded-md shadow-sm border border-collapse">
                    <div className="h-full w-full">
                        <div className="flex mb-4">
                            <button
                                className={`flex-1 px-4 py-2 border-b-2 ${activeTab === "tab1" ? "border-slate-600" : "border-transparent"
                                    }`}
                                onClick={() => handleTabChange("tab1")}
                            >
                                Tab 1
                            </button>
                            <button
                                className={`flex-1 px-4 py-2 border-b-2 ${activeTab === "tab2" ? "border-slate-600" : "border-transparent"
                                    }`}
                                onClick={() => handleTabChange("tab2")}
                            >
                                Tab 2
                            </button>
                            <button
                                className={`flex-1 px-4 py-2 border-b-2 ${activeTab === "tab3" ? "border-slate-600" : "border-transparent"
                                    }`}
                                onClick={() => handleTabChange("tab3")}
                            >
                                Tab 3
                            </button>
                        </div>
                        {activeTab === "tab1" && (
                            <div>
                                <Accordion topics={previewDetails} />
                            </div>
                        )}

                        {activeTab === "tab2" && (
                            <div className="h-full w-full flex p-8 mb-2">
                                <div className="rounded w-full">
                                    <h1 className="text-xl">Course description</h1>
                                    <p className="my-7 leading-6">Lorem ipsum dolor sit amet consectetur adipisicing elit. Eos cupiditate deleniti vel corporis hic explicabo eius numquam, dolorem quis doloribus aliquam quos atque ducimus repellat totam eaque. Est quo sint iusto ea unde sapiente, consequatur tempore minima voluptatibus ratione nesciunt, odio impedit. Atque iusto ea similique blanditiis laudantium ipsa in!</p>
                                    <h3 className="font-bold font-sans">What you will learn</h3>
                                    <div className="grid grid-cols-2 gap-4  my-4">
                                        {previewDetailsExtra.topicsCoverage &&
                                            previewDetailsExtra.topicsCoverage.map((topic, index) => (
                                                <div key={index} className="grid grid-cols-4 my-2">
                                                    <div className="col-span-1">
                                                        <BsCheck />
                                                    </div>
                                                    <div className="col-span-1">
                                                        <p className="overflow-hidden text-sm leading-7">{topic}</p>
                                                    </div>
                                                </div>
                                            ))}
                                    </div>
                                </div>
                            </div>
                        )}

                        {activeTab === "tab3" && (
                            <div>
                                <table className="w-full table-auto">
                                    <thead>
                                        <tr>
                                            <th>Header 7</th>
                                            <th>Header 8</th>
                                            <th>Header 9</th>
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                            </div>
                        )}
                    </div>
                </div>

                <div className=" w-1/4 ml-7">
                    <div className="w-full h-96 rounded-md flex justify-center items-center border border-collapse">
                        <div className="w-full overflow-hidden">
                            <YouTube videoId={previewDetails.introductionVideoUrl} opts={opts} />
                            <h1 className="text-lg font-bold ml-8 mt-4 mb-2">${previewDetails.price}</h1>
                            <div className="flex justify-center items-center">
                                <button
                                    onClick={(event) => { event.preventDefault(); navigate(navigateURL) }}
                                    type="button"
                                    className="w-10/12 py-3 px-4 gap-2 rounded-md border border-transparent font-semibold text-indigo-500 hover:bg-indigo-100 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition-all text-sm dark:focus:ring-offset-gray-800"
                                >
                                    Join the course
                                </button>
                            </div>
                        </div>
                    </div>

                    <div className="bg-pink-900 w-full h-80 my-16 rounded-md px-4">
                        <section className="bg-slate-100 py-8">
                            <h2>What's included</h2>
                        </section>
                        <section>
                            <div className="flex items-center divide-y">
                                <span className="mr-2"><AiOutlineFilePdf /></span>
                                {previewDetails && Array(previewDetails).length} lectures and exercises
                            </div>
                            <div className="flex items-center divide-y">
                                <span className="mr-2"><AiOutlinePlayCircle /></span>
                                Over 24 hours of footage
                            </div>
                            <div className="flex items-center divide-y">
                                <span className="mr-2"><GrCertificate /></span>
                                Certificate
                            </div>
                            <div className="flex items-center divide-y">
                                <span className="mr-2"><BsYoutube /></span>
                                Watch online
                            </div>
                            <div className="flex items-center divide-y">
                                <span className="mr-2"><BsClock /></span>
                                Lifetime access
                            </div>
                        </section>
                    </div>
                    <div className="bg-pink-900 w-full h-80 rounded-md">

                    </div>
                </div>
            </div>
        </>
    );


};

export const CourseOverView = () => {
    return (
        <div>
            <HeaderView></HeaderView>
            <Main></Main>
            <div className="bg-bgGray-0 min-h-screen"></div>
        </div>
    );
};
