import useCreateCourseModalStore from "../../../stores/useCreateCourseModalStore";
import {BsInfoCircle} from "react-icons/bs"

export const CreateCourseModal = () => {
    const course = useCreateCourseModalStore((state) => state.course);
    const setIsCreateModalOpen = useCreateCourseModalStore((state) => state.setIsCreateModalOpen);
    const updateData = useCreateCourseModalStore((state) => state.updateData);
    const saveData = useCreateCourseModalStore((state)=>state.saveData);

    return (
        <div className="relative z-10" aria-labelledby="modal-title" role="dialog" aria-modal="true">
            <div className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"></div>

            <div className="fixed inset-0 z-10 overflow-y-auto">
                <div className="flex min-h-screen items-end justify-center p-4 text-center sm:items-center sm:p-0">
                    <div className="relative transform overflow-hidden rounded-lg bg-bgWhiteUI-0 text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-6xl">
                        <div className="bg-bgWhiteUI-0 px-4 pb-4 pt-5 sm:p-6 sm:pb-4 font-semibold">
                            <div className="flex flex-col mb-2">
                                <label className="mb-1">Course title</label>
                                <input type="text"
                                    name="title"
                                    value={course.title}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="px-4 py-2 bg-bgWhiteUI-0 border border-pinkUI-0  rounded focus:ring-2 focus:ring-bgGray-0 focus:border-bgGray-0 outline-none" />
                            </div>

                            <div className="flex flex-col mb-2">
                                <label className="mb-1" >Course description</label>
                                <input type="text"
                                    name="description"
                                    value={course.description}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />

                            </div>
                            <div className="flex flex-col">

                                <label className="mb-1" >Course price</label>
                                <input type="text"
                                    name="price"
                                    value={course.price}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />


                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Course ImageUrl</label>
                                <input type=""
                                    name="imageUrl"
                                    value={course.imageUrl}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />

                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Course StartDate</label>
                                <input type="datetime-local"
                                    name="startDate"
                                    value={course.startDate}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />


                            </div>
                            <div className="flex flex-col">

                                <label className="mb-1" >Course EndDate</label>
                                <input type="datetime-local"
                                    name="endDate"
                                    value={course.endDate}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />


                            </div>
                            <div className="flex flex-col">

                                <label className="mb-1" >Course Summary</label>
                                <input type="text"
                                    name="summary"
                                    value={course.summary}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />

                            </div>
                            <div className="flex flex-col">
                                <label >Course Coverage </label>
                                <label className="text-sm mb-1 text-red-500">Make sure to split each new point of coverage by wtih this symbol <strong>&</strong></label>
                                <textarea type="text"
                                    name="coverage"
                                    value={course.coverage}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-4 border border-pinkUI-0" />
                            </div>

                        </div>
                        <div className="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
                            <button type="button" 
                            className="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto"
                            onClick={()=>saveData(course)}
                            >Deactivate
                            </button>
                            <button type="button"
                                className="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
                                onClick={() => setIsCreateModalOpen()}>Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

