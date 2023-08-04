import { useEffect } from "react";
import useCreateCourseModalStore from "../../../stores/useCreateCourseModalStore";
import { BsInfoCircle } from "react-icons/bs"
import { FaTimes } from "react-icons/fa";

export const CreateCourseModal = () => {
    const course = useCreateCourseModalStore((state) => state.course);
    const setIsCreateModalOpen = useCreateCourseModalStore((state) => state.setIsCreateModalOpen);
    const updateData = useCreateCourseModalStore((state) => state.updateData);
    const saveData = useCreateCourseModalStore((state) => state.saveData);
    const getCourseCategories = useCreateCourseModalStore((state) => state.getCourseCategories);
    const categories = useCreateCourseModalStore((state) => state.categories);
    const setCoursesCategories = useCreateCourseModalStore((state) => state.setCoursesCategories);
    const removeCategory = useCreateCourseModalStore((state) => state.removeCategory);

    useEffect(() => {
        getCourseCategories();
    }, []);


    console.log(categories);
    console.log(categories);
    console.log(categories);
    console.log(categories);
    console.log(categories);
    console.log(course.courseCategories);


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
                                    name="courseName"
                                    value={course.courseName}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="px-4 py-2 bg-bgWhiteUI-0 border border-pinkUI-0  rounded focus:ring-2 focus:ring-bgGray-0 focus:border-bgGray-0 outline-none" />
                            </div>

                            <div className="flex flex-col mb-2">
                                <label className="mb-1" >Course description</label>
                                <input type="text"
                                    name="courseDescription"
                                    value={course.courseDescription}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />

                            </div>
                            <div className="flex flex-col">

                                <label className="mb-1" >Course price</label>
                                <input type="text"
                                    name="coursePrice"
                                    value={course.coursePrice}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-2 border border-pinkUI-0" />


                            </div>
                            <div className="flex flex-col">
                                <label className="mb-1" >Course ImageUrl</label>
                                <input type=""
                                    name="courseImageUrl"
                                    value={course.courseImageUrl}
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
                                    name="courseCoverage"
                                    value={course.courseCoverage}
                                    onChange={(e) => updateData({ [e.target.name]: e.target.value })}
                                    className="p-4 border border-pinkUI-0" />
                            </div>
                        </div>

                        <div className="ml-4 text-bgBlackUI-0 font-normal">
                            {course.courseCategories.map((ctg, index) =>
                                <span
                                    onClick={(event) => {
                                        event.preventDefault();
                                        removeCategory(ctg);
                                    }}
                                    key={index}
                                    className="mr-2 text-pinkUI-0 font-bold">
                                    {ctg}
                                    <button>
                                        <FaTimes className="text-red-500"/>
                                    </button>
                                </span>)}

                            <select
                                className="mt-4 block w-64 p-2 border rounded"
                                onChange={(event) => setCoursesCategories(event.target.value)}
                            >
                                {categories && course.courseCategories &&
                                    categories.map((ctg, index) => (
                                        <option
                                            key={index}
                                            className={`${course.courseCategories.includes(ctg)
                                                    ? 'font-bold text-pinkUI-0 border-pinkUI-0 border-l border-l-pinkUI-0'
                                                    : 'font-semibold text-bgBlackUI-0'
                                                }`}
                                        >
                                            {ctg}
                                        </option>
                                    ))}
                            </select>
                        </div>

                        <div className="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
                            <button type="button"
                                className="inline-flex w-full justify-center rounded-md bg-pinkUI-0 px-3 py-2 text-sm font-semibold text-bgWhiteUI-0 shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto"
                                onClick={() => saveData(course)}
                            >Deactivate
                            </button>
                            <button type="button"
                                className="mt-3 inline-flex w-full justify-center rounded-md bg-bgWhiteUI-0 px-3 py-2 text-sm font-semibold text-bgBlackUI-0 shadow-sm ring-1 ring-inset ring-pinkUI-0  sm:mt-0 sm:w-auto"
                                onClick={() => setIsCreateModalOpen()}>Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

