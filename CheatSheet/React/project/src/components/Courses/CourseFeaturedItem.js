import { Link } from "react-router-dom";
import { URLS } from "../../constants/URLConstants";


export const CourseFeaturedItem = ({ course }) => {

    const redirectURL=course.hasPaid===true?`${URLS.COURSES_ID}${course.id}/${decodeURI(course.title)}`:`${URLS.COURSES_OVERVIEW}${course.id}`;
    return (
        <div className="mx-auto m-2 w-80 transform overflow-hidden rounded-lg bg-white dark:bg-slate-800 shadow-md duration-300 hover:scale-105 hover:shadow-lg">
            <img className="h-64 w-full object-cover object-center" src={course.imageUrl} alt="Course Thumbnail" />
            <section className="h-full bg-slate-800 text-slate-100 font-sans flex flex-col justify-between">
                <Link
                to={redirectURL}>
                    <div className="p-4 dark:text-white text-gray-900 overflow-hidden hover:cursor-pointer hover:text-orange-300">
                        <p className="mb-2 text-lg font-medium overflow-hidden">{course.title}</p>
                        <div className="flex justify-between mt-4 overflow-hidden">
                            <span className="text-sm">{course.startDate}</span>
                            <span className="text-sm">{course.weeksDuration} Weeks</span>
                        </div>
                    </div>
                </Link>
            </section>
        </div>
    );
};
