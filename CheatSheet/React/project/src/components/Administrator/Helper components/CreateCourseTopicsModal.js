import useCreateTopicsModalStore from "../../../stores/useCreateTopicsModalStore";


export const CreateCourseTopicsModal = ({selectedCourse}) => {


    const topics=useCreateTopicsModalStore((state)=>state.topics);
    const updateData=useCreateTopicsModalStore((state)=>state.updateData);
    const setIsTopicModalOpen=useCreateTopicsModalStore((state)=>state.setIsTopicModalOpen);
    const sendData=useCreateTopicsModalStore((state)=>state.sendData);


    return (
        <div className="relative z-10" aria-labelledby="modal-title" role="dialog" aria-modal="true">
            <div className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"></div>

            <div className="fixed inset-0 z-10 overflow-y-auto">
                <div className="flex min-h-screen items-end justify-center p-4 text-center sm:items-center sm:p-0">
                    <div className="relative transform overflow-hidden rounded-lg bg-bgWhiteUI-0 text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-6xl">
                        <div className="bg-bgWhiteUI-0 px-4 pb-4 pt-5 sm:p-6 sm:pb-4 font-semibold">
                            <div className="flex flex-col mb-2">
                                <label className="mb-1">Video Name</label>
                                <input type="text"
                                    name="videoName"
                                    value={topics.videoName}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="px-4 py-2 bg-bgWhiteUI-0 border border-pinkUI-0  rounded focus:ring-2 focus:ring-bgGray-0 focus:border-bgGray-0 outline-none" />
                            </div>
                            <div className="flex flex-col mb-2">
                                <label className="mb-1" >Video URL</label>
                                <input type="text"
                                    name="videoUrl"
                                    value={topics.videoUrl}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />

                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Topic Name</label>
                                <input type="text"
                                    name="topicName"
                                    value={topics.topicName}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />
                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Topic Content</label>
                                <input type=""
                                    name="topicContent"
                                    value={topics.topicContent}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />
                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Topic StartDate</label>
                                <input type="datetime-local"
                                    name="topicStartDate"
                                    value={topics.topicStartDate}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />
                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Topic EndDate</label>
                                <input type="datetime-local"
                                    name="topicEndDate"
                                    value={topics.topicEndDate}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />


                            </div>
                        </div>
                        <div className="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
                            <button type="button" 
                            className="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto"
                            onClick={()=>sendData(selectedCourse,topics)}
                            >Create
                            </button>
                            <button type="button"
                                className="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
                                onClick={() => setIsTopicModalOpen()}>Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

