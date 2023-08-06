import { useEffect, useRef } from "react";
import useModalStore from "../../../stores/useModalStore"

export const Modal = ({ topicId }) => {
    const setModalIsOpen = useModalStore((state) => state.setModalIsOpen);
    const topicData = useModalStore((state) => state.data);

    const data = useModalStore((state) => state.data);
    const setData = useModalStore((state) => state.setData);
    const updateData = useModalStore((state) => state.updateData);
    const sendUpdateRequest = useModalStore((state) => state.sendUpdateRequest);
    const prevTopicIdRef = useRef();

    console.log(topicId);

    useEffect(() => {
        if (topicId && topicId !== prevTopicIdRef.current) {
            setData(topicId);
            prevTopicIdRef.current = topicId;
        }
    }, [topicId]);

    return (
        <div className="relative flex justify-center">
            <button className="px-6 py-2 mx-auto tracking-wide text-white capitalize transition-colors duration-300 transform bg-blue-600 rounded-md hover:bg-blue-500 focus:outline-none focus:ring focus:ring-blue-300 focus:ring-opacity-80">
                Open Modal
            </button>

            <div x-show="isOpen"
                className="fixed inset-0 z-10 overflow-y-auto"
                aria-labelledby="modal-title" role="dialog" aria-modal="true"
            >
                <div className="flex items-end justify-center min-h-screen px-4 pt-4 pb-20 text-center sm:block sm:p-0">
                    <span className="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>

                    <div class="relative inline-block p-4 overflow-hidden text-left align-middle transition-all transform bg-black shadow-xl sm:max-w-2xl rounded-xl sm:my-8 sm:w-full sm:p-6">
                        <div class="flex items-center justify-center mx-auto">
                            <img class="h-64 rounded-lg" src="https://images.unsplash.com/photo-1488190211105-8b0e65b80b4e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80" alt="" />
                        </div>

                        <div className="mt-5 text-center">
                            <h3 className="text-lg font-medium text-gray-800 dark:text-white" id="modal-title">
                                Blog post published
                            </h3>

                            <p className="mt-2 text-gray-500 dark:text-gray-400">
                                This blog post has been published. Team members will be
                                able to edit this post.
                            </p>
                        </div>

                        <div className="flex items-center justify-between w-full mt-5 gap-x-2">
                            <section className="max-w-6xl p-6 mx-auto bg-white rounded-md shadow-md dark:bg-gray-800">
                                <h2 className="text-lg font-semibold text-gray-700 capitalize dark:text-white">Account settings</h2>

                                {data &&
                                    <form 
                                    onSubmit={() => sendUpdateRequest(topicId, data)}>
                                        <>
                                            <div className="grid grid-cols-1 gap-6 mt-4 sm:grid-cols-2">
                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="topicName">
                                                        Topic Name
                                                    </label>
                                                    <input
                                                        id="topicName"
                                                        name="topicName"
                                                        type="text"
                                                        className="block w-full px-4 py-2 mt-2 text-bgGreyishBlack-0 bg-bgWhiteUI-0 border border-gray-200 rounded-md focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.topicName}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>

                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="topicContent">
                                                        Topic Content
                                                    </label>
                                                    <input
                                                        id="topicContent"
                                                        name="topicContent"
                                                        type="text"
                                                        className="block w-full px-4 py-2 mt-2 text-gray-700 bg-white border border-gray-200 rounded-md dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.topicContent}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>
                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="startTime">
                                                        startTime
                                                    </label>
                                                    <div>
                                                        <label className="text-bgWhiteUI-0">{data.startTime}</label>
                                                    </div>
                                                    <input
                                                        id="startTime"
                                                        name="startTime"
                                                        type="date"
                                                        className="block w-full px-4 py-2 mt-2 text-gray-700 bg-white border border-gray-200 rounded-md dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.startTime}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>

                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="endTime">
                                                        End Time
                                                    </label>
                                                    <div>
                                                        <label className="text-bgWhiteUI-0">{data.endTime}</label>
                                                    </div>
                                                    <input
                                                        id="endTime"
                                                        name="endTime"
                                                        type="date"
                                                        className="block w-full px-4 py-2 mt-2 text-gray-700 bg-white border border-gray-200 rounded-md dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.endTime}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>

                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="videoName">
                                                        Video Name
                                                    </label>
                                                    <input
                                                        id="videoName"
                                                        name="videoName"
                                                        type="text"
                                                        className="block w-full px-4 py-2 mt-2 text-gray-700 bg-white border border-gray-200 rounded-md dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.videoName}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>

                                                <div>
                                                    <label className="text-gray-700 dark:text-gray-200" htmlFor="videoUrl">
                                                        Video URL
                                                    </label>
                                                    <input
                                                        id="videoUrl"
                                                        name="videoUrl"
                                                        type="text"
                                                        className="block w-full px-4 py-2 mt-2 text-gray-700 bg-white border border-gray-200 rounded-md dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 focus:border-blue-400 focus:ring-blue-300 focus:ring-opacity-40 dark:focus:border-blue-300 focus:outline-none focus:ring"
                                                        value={data.videoUrl}
                                                        onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                                    />
                                                </div>
                                            </div>
                                            <div className="flex justify-end mt-6">
                                                <button className="px-8 py-2.5 leading-5 text-white transition-colors duration-300 transform bg-gray-700 rounded-md hover:bg-gray-600 focus:outline-none focus:bg-gray-600">Save</button>
                                            </div>
                                        </>
                                    </form>}
                            </section>


                        </div>

                        <div className="mt-4 sm:flex sm:items-center sm:justify-between sm:mt-6 sm:-mx-2">
                            <button className="px-4 sm:mx-2 w-full py-2.5 text-sm font-medium dark:text-gray-200 dark:border-gray-700 dark:hover:bg-gray-800 tracking-wide text-gray-700 capitalize transition-colors duration-300 transform border border-gray-200 rounded-md hover:bg-gray-100 focus:outline-none focus:ring focus:ring-gray-300 focus:ring-opacity-40"
                                onClick={() => setModalIsOpen()}>
                                Cancel
                            </button>

                            <button className="px-4 sm:mx-2 w-full py-2.5 mt-3 sm:mt-0 text-sm font-medium tracking-wide text-white capitalize transition-colors duration-300 transform bg-blue-600 rounded-md hover:bg-blue-500 focus:outline-none focus:ring focus:ring-blue-300 focus:ring-opacity-40">
                                Confirm
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}