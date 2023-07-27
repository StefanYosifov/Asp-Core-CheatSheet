import { useEffect, useState } from "react";
import { BsCheck, BsClock, BsGraphUp, BsPeople, BsYoutube } from "react-icons/bs";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import YouTube from 'react-youtube';
import useCourseStore from "../../stores/useCourseStore";
import { Accordion } from "../Helper components/Accordion";
import { URLS } from "../../constants/URLConstants";
import { AiOutlineFilePdf, AiOutlinePlayCircle } from "react-icons/ai";
import { GrCertificate } from "react-icons/gr";


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

    const navigateURL = `${URLS.COURSES_JOIN}${id}`;

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
                                Contents
                            </button>
                            <button
                                className={`flex-1 px-4 py-2 border-b-2 ${activeTab === "tab2" ? "border-slate-600" : "border-transparent"
                                    }`}
                                onClick={() => handleTabChange("tab2")}
                            >
                                Description
                            </button>
                            <button
                                className={`flex-1 px-4 py-2 border-b-2 ${activeTab === "tab3" ? "border-slate-600" : "border-transparent"
                                    }`}
                                onClick={() => handleTabChange("tab3")}
                            >
                                FAQ
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
                            <div className="px-8">
                                <article className="my-5">
                                    <h1 className="font-sans font-bold mb-1 text-lg">Course - Frequently Asked Questions</h1>
                                    <p className="text-gray-700">How this course help me to design layout?
                                        My name is Jason Woo and I work as human duct tape at Gatsby, that means that I do a lot of different things. Everything from dev roll to writing content to writing code. And I used to work as an architect at IBM. I live in Portland, Oregon.
                                    </p>
                                </article>
                                <article className="my-5">
                                    <h1 className="font-sans font-bold mb-1 text-lg">What is important of this course?</h1>
                                    <p className="text-gray-700">
                                        We'll dive into GraphQL, the fundamentals of GraphQL. We're only gonna use the pieces of it that we need to build in Gatsby. We're not gonna be doing a deep dive into what GraphQL is or the language specifics. We're also gonna get into MDX. MDX is a way to write React components in your markdown.
                                    </p>
                                </article>
                                <article className="my-5">
                                    <h1 className="font-sans font-bold mb-1 text-lg">Why Take This Course?</h1>
                                    <p className="text-gray-700">We'll dive into GraphQL, the fundamentals of GraphQL. We're only gonna use the pieces of it that we need to build in Gatsby. We're not gonna be doing a deep dive into what GraphQL is or the language specifics. We're also gonna get into MDX. MDX is a way to write React components in your markdown.</p>
                                </article>
                                <article className="my-5">
                                    <h1 className="font-sans font-bold mb-1 text-lg">Is able to create application after this course?</h1>
                                    <p className="text-gray-700">
                                        We'll dive into GraphQL, the fundamentals of GraphQL. We're only gonna use the pieces of it that we need to build in Gatsby. We're not gonna be doing a deep dive into what GraphQL is or the language specifics. We're also gonna get into MDX. MDX is a way to write React components in your markdown.

                                        We'll dive into GraphQL, the fundamentals of GraphQL. We're only gonna use the pieces of it that we need to build in Gatsby. We're not gonna be doing a deep dive into what GraphQL is or the language specifics. We're also gonna get into MDX. MDX is a way to write React components in your markdown.
                                    </p>
                                </article>
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
                    <div className="w-full h-96 rounded-md justify-center items-center border border-collapse shadow-md mt-10">
                        <section className="py-8 px-4">
                            <h1 className="font-bold text-xl">What's included</h1>
                        </section>
                        <section className="px-4">
                            <div className="flex items-center">
                                <span className="mr-2"><AiOutlineFilePdf /></span>
                                <span>{previewDetails && Array(previewDetails).length} lectures and exercises</span>
                            </div>
                            <hr className="my-2" />
                            <div className="flex items-center">
                                <span className="mr-2"><AiOutlinePlayCircle /></span>
                                <span>Over 24 hours of footage</span>
                            </div>
                            <hr className="my-2" />
                            <div className="flex items-center">
                                <span className="mr-2"><GrCertificate /></span>
                                <span>Certificate</span>
                            </div>
                            <hr className="my-2" />
                            <div className="flex items-center">
                                <span className="mr-2"><BsYoutube /></span>
                                <span>Watch online</span>
                            </div>
                            <hr className="my-2" />
                            <div className="flex items-center">
                                <span className="mr-2"><BsClock /></span>
                                <span>Lifetime access</span>
                            </div>
                        </section>

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
