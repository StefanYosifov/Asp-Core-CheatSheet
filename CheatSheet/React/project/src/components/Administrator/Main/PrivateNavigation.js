import { useState } from "react";
import { PrivateCourses } from "../Courses/PrivateCourses";


export const PrivateNavigation = () => {
    const [activeItem, setActiveItem] = useState("courses");

    const RenderContent = () => {
        switch (activeItem) {
          case ACTIVE_ELEMENTS.Course:
         return <PrivateCourses />
          default:
            return <PrivateCourses />
        }
      }; 

      const ACTIVE_ELEMENTS = {
        Resource: "resources",
        Course: "courses",
        Issues: "issues",
    }

    return (
        <>
            return (
            <div>
                <div className="grid grid-cols-3 gap-5">
                    <button
                        className="text-white p-4 rounded bg-pinkUI-0 shadow-md flex items-center justify-center"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            className="h-6 w-6 mr-2"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                            />
                        </svg>
                        Home
                    </button>
                    <button
                        className="p-4 rounded bg-bgWhiteUI-0 text-bg-pinkUI-0shadow-md flex items-center justify-center"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            className="h-6 w-6 mr-2"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z"
                            />
                        </svg>
                        Profile
                    </button>
                    <button
                        className="p-4 rounded bg-bgWhiteUI-0 text-bg-pinkUI-0 shadow-md flex items-center justify-center"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            className="h-6 w-6 mr-2"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M17 8h2a2 2 0 012 2v6a2 2 0 01-2 2h-2v4l-4-4H9a1.994 1.994 0 01-1.414-.586m0 0L11 14h4a2 2 0 002-2V6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2v4l.586-.586z"
                            />
                        </svg>
                        Profile
                    </button>
                </div>
                <div
                    className="shadow-xl border border-gray-100 font-light p-8 rounded text-gray-500 bg-bgWhiteUI-0 mt-6"
                >
                    Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt
                    tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor,
                    williamsburg carles vegan helvetica. Reprehenderit butcher retro keffiyeh
                    dreamcatcher synth.
                </div>
            </div>
            )
                <RenderContent/>
        </>
    )
}