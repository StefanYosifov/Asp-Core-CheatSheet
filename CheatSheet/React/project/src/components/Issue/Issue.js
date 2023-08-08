import { useEffect, useState } from "react";
import { getIssueCategories, postIssue } from "../../api/Requests/issues";
import useIssueStore from "../../stores/useIssueStore";

export const Issue = ({ showIssue, topicId }) => {


    const { isOpen, issue } = useIssueStore();
    const setIsOpen = useIssueStore((state) => state.setIsOpen);
    const setIssueLocation = useIssueStore((state) => state.setLocation);
    const sendIssue = useIssueStore((state) => state.sendIssue);
    const updateIssueProperty = useIssueStore((state) => state.updateIssueProperty);

    useEffect(() => {
        setIssueLocation();
        issue.topicId = topicId;
    }, []);


    return (
        <>
            {isOpen && issue && Array.isArray(issue.location) &&
                <>
                    <div id="popup-modal" tabIndex="-1" className="fixed top-0 left-0 right-2 z-50 p-4 overflow-x-hidden overflow-y-auto md:inset-0 h-[calc(100%-1rem)] max-h-full">
                        <div className="relative w-full max-w-md max-h-full">
                            <div className="relative bg-white rounded-lg shadow dark:bg-gray-700">
                                <button type="button" className="absolute top-3 right-2.5 text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ml-auto inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white" data-modal-hide="popup-modal"
                                    onClick={() => setIsOpen()}>
                                    <svg className="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                                        <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                                    </svg>
                                    <span
                                        onClick={() => setIsOpen()}
                                        className="sr-only"
                                    >Close modal
                                    </span>
                                </button>
                                <form onSubmit={(event) => { event.preventDefault(); sendIssue({ issue }) }}>
                                    <section className="flex justify-center mt-12 pt-6">
                                    <h3 className="text-xl font-semibold text-bgWhiteUI-0  mb-4">
                                        Issue report
                                    </h3>
                                    </section>
                                    <div className="mb-4">
                                        <label className="block text-sm text-gray-700 dark:text-white" htmlFor="title">
                                            Title
                                        </label>
                                        <input
                                            type="text"
                                            name="title"
                                            value={issue.title}
                                            onChange={(event) => updateIssueProperty(event.target.name, event.target.value)}
                                            className="w-full border border-gray-300 dark:border-gray-700 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        />
                                    </div>
                                    <div className="mb-4">
                                        <label className="block text-sm text-gray-700 dark:text-white" htmlFor="location">
                                            Location
                                        </label>
                                        <select name="IssueCategoryId" onChange={(event) => { updateIssueProperty(event.target.name, event.target.value) }}>
                                            {issue.location.map((loc) => (
                                                <option key={loc.id} value={loc.id}>
                                                    {loc.locationIssue}
                                                </option>
                                            ))}
                                        </select>
                                    </div>
                                    <div className="mb-4">
                                        <label className="block text-sm text-gray-700 dark:text-white" htmlFor="description">
                                            Description
                                        </label>
                                        <textarea
                                            name="description"
                                            value={issue.description}
                                            onChange={(event) => updateIssueProperty(event.target.name, event.target.value)}
                                            className="w-full border border-gray-300 dark:border-gray-700 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        ></textarea>
                                    </div>
                                    <div className="p-6 text-center">
                                        <h3 className="mb-5 text-lg text-pinkUI-0 font-semibold">
                                            Do you wanna submit the issue?
                                        </h3>
                                        <button data-modal-hide="popup-modal" type="button" 
                                        className="text-white bg-pinkUI-0 focus:ring-4 focus:outline-none focus:ring-bgBlackUI-0 hover:border hover: font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center mr-2"
                                            onClick={(event) => { event.preventDefault(); sendIssue(issue) }}
                                        >
                                            Submit
                                        </button>
                                        <button data-modal-hide="popup-modal" type="button"
                                            onClick={()=>setIsOpen()}
                                            className="text-pinkUI-0 bg-bgGreyishBlack-0 focus:ring-4 focus:outline-none focus:bg-pinkUI-0 rounded-lg border border-pinkUI-0 text-sm font-medium px-5 py-2.5 focus:z-10">
                                            No, cancel
                                        </button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </>
            }
        </>
    );
};
