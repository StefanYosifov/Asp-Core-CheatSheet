import { Link } from 'react-router-dom'

export const CourseMyItem = ({ course }) => {

    return (
        <>
            <div className="w-full">
                <div className="flex flex-wrap -mx-4">
                    <div className="w-full sm:w-1/2 p-4">
                        <div className="flex text-xs w-full text-gray-700 justify-end">
                            <span className=" px-2 py-1 rounded-3xl bottom-6">Until: {course.endDate}</span>
                        </div>
                        <div className="c-card bg-white shadow-md hover:shadow-xl rounded-lg overflow-hidden h-full flex flex-col">
                            <div className="relative pb-48 overflow-hidden">
                                <img className="absolute inset-0 h-full w-full object-cover" src={course.imageUrl} alt="courseImage" />
                            </div>
                            <div className="p-4 flex flex-col justify-between h-full">
                                <div>
                                    <span className="px-2 py-1 leading-none bg-orange-200 text-orange-800 rounded-full font-semibold uppercase tracking-wide text-xs">{course.category}</span>
                                    <h2 className="mt-2 mb-2 font-bold">{course.title}</h2>
                                    <p className="text-sm overflow-hidden">{course.description}</p>
                                </div>
                            </div>
                            <div className="p-4 border-t border-b text-xs text-gray-700">
                                <span className="flex items-center">
                                    {course.hasPaid === true ? (
                                        <span className="flex items-center">
                                            <Link to={{
                                                pathname: `/course/trainings/${course.id}/${encodeURIComponent(course.title)}`,
                                                state:'mystate' 
                                            }}>
                                                Go to course!
                                            </Link>
                                        </span>
                                    ) : <p>Loading</p>}
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
};