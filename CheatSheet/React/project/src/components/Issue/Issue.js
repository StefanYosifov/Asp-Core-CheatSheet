import { useEffect, useState } from "react";
import { getIssueCategories, postIssue } from "../../api/Requests/issues";

export const Issue = ({ showIssue, topicId }) => {

    const [showState, setShowState] = useState(showIssue);
    const [title, setTitle] = useState('');
    const [location, setLocation] = useState(1);
    const [locationDb, setLocationDb] = useState([]);
    const [description, setDescription] = useState('');

    useEffect(() => {
        getIssueCategories().then((res) => setLocationDb(res.data));
    }, []);

    const clickCloseButton = (e) => {
        e.preventDefault();
        setShowState(!showState);
    };

    const submitForm = (e) => {
        e.preventDefault();
        postIssue({ Title: title, IssueCategoryId: location, Description: description, TopicId: topicId })
        setShowState((state) => state = false);
        setTitle((state) => state = '');
        setDescription((state) => state = '');
    }

    return (
        <>
            {showState && locationDb &&
                <>
                    <div id="popup-modal" tabIndex="-1" className="fixed top-0 left-0 right-2 z-50 p-4 overflow-x-hidden overflow-y-auto md:inset-0 h-[calc(100%-1rem)] max-h-full">
                        <div className="relative w-full max-w-md max-h-full">
                            <div className="relative bg-white rounded-lg shadow dark:bg-gray-700">
                                <button type="button" className="absolute top-3 right-2.5 text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ml-auto inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white" data-modal-hide="popup-modal" onClick={clickCloseButton}>
                                    <svg className="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                                        <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                                    </svg>
                                    <span className="sr-only">Close modal</span>
                                </button>
                                <form onSubmit={submitForm}>
                                    <h3 className="text-xl font-semibold text-gray-900 dark:text-white mb-4">
                                        Issue report
                                    </h3>
                                    <div className="mb-4">
                                        <label className="block text-sm text-gray-700 dark:text-white" htmlFor="title">
                                            Title
                                        </label>
                                        <input
                                            type="text"
                                            name="title"
                                            value={title}
                                            onChange={(e) => setTitle(e.target.value)}
                                            className="w-full border border-gray-300 dark:border-gray-700 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        />
                                    </div>
                                    <div className="mb-4">
                                        <label className="block text-sm text-gray-700 dark:text-white" htmlFor="location">
                                            Location
                                        </label>
                                        <select onChange={(e) => setLocation(e.target.value)}>
                                            {locationDb.map((loc) => (
                                                <option key={loc.id} value={loc.id}>
                                                    {loc.locationIssue}
                                                    {console.log(loc)}
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
                                            value={description}
                                            onChange={(e) => setDescription(e.target.value)}
                                            className="w-full border border-gray-300 dark:border-gray-700 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        ></textarea>
                                    </div>
                                    <div className="p-6 text-center">
                                        <svg className="mx-auto mb-4 text-gray-400 w-12 h-12 dark:text-gray-200" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                                            <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M10 11V6m0 0 6 6m0-6H4a9 9 0 0 0 0 18h12a9 9 0 0 0 0-18h-6z" />
                                        </svg>
                                        <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">Are you sure you want to delete this product?</h3>
                                        <button data-modal-hide="popup-modal" type="button" className="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 dark:focus:ring-red-800 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center mr-2"
                                            onClick={submitForm}
                                        >
                                            Submit
                                        </button>
                                        <button data-modal-hide="popup-modal" type="button" className="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10 dark:bg-gray-700 dark:text-gray-300 dark:border-gray-500 dark:hover:text-white dark:hover:bg-gray-600 dark:focus:ring-gray-600">No, cancel</button>
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
