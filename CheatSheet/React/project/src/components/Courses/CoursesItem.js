import { FaCalendar, FaGrav } from "react-icons/fa";
import { Link, Location,useLocation,useNavigate } from "react-router-dom";


export const CoursesItem = ({ course }) => {
  const navigate = useNavigate();
  const location=useLocation();

  const navigateToSpecificCourse = (event) => {
    event.preventDefault();
    navigate(`/course/${course.id}`);
  }

  return (
    <div className="w-full">
      <div className="flex flex-wrap -mx-4">
        <div className="w-full sm:w-1/2 p-4">
          <div className="c-card  bg-white shadow-md hover:shadow-xl rounded-lg overflow-hidden h-full flex flex-col">
            <div className="relative pb-48 overflow-hidden">
              <img className="absolute inset-0 h-full w-full object-cover" src={course.imageUrl} alt="courseImage" />
            </div>
            <div className="p-4 flex flex-col justify-between">
              <div>
                <span className="px-2 py-1 leading-none bg-orange-200 text-orange-800 rounded-full font-semibold uppercase tracking-wide text-xs">{course.category}</span>
                <h2 className="mt-2 mb-2 font-bold">{course.title}</h2>
                <p className="text-sm overflow-hidden">{course.description}</p>
              </div>
              {/* <div className="mt-3 flex items-center">
                <span className="font-bold text-xl">{course.price}</span>&nbsp;
                <span className="text-sm font-semibold">€</span>
              </div> */}
            </div>
            <div className="p-4 border-t border-b text-xs text-gray-700">
              {/* <span className="flex items-center mb-1">
                <FaCalendar></FaCalendar><span className="ml-1">{course.startDate}</span>
              </span>
              <span className="flex items-center mb-1">
                <FaCalendar></FaCalendar><span className="ml-1">{course.endDate}</span>
              </span> */}
              <span className="flex items-center">
                {course.hasPaid === true ? (
                  <span className="flex items-center">
                    <Link to={{
                      pathname: `/course/trainings/${course.id}/${encodeURIComponent(
                        course.title
                      )}`,
                      state: { course }
                    }}>
                      Go to course!
                    </Link>
                  </span>
                )
                  :
                  <Link to={`/course/join/${course.id}`}>
                    <button>Join Course</button>
                  </Link>}
              </span>
            </div>
          </div>
        </div>
      </div>
    </div >

  )
}