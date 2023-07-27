import { useEffect, useState } from "react";
import { getMyCourses } from "../../api/Requests/courses";
import { useSearchParams, useNavigate, useParams } from 'react-router-dom';
import { CourseMyItem } from "./CourseMyItem";

export const CourseMy = () => {
  const { id } = useParams();
  const [courses, setCourses] = useState([]);
  const [isChecked, setIsChecked] = useState(true);
  const [searchParams, setSearchParams] = useSearchParams();
  const navigate = useNavigate();

  useEffect(() => {
    const checkedQueryParam = searchParams.get('toggle');
    console.log(checkedQueryParam);
    getMyCourses(id, checkedQueryParam).then((res) => setCourses(res.data));
  }, [id, searchParams]);

  useEffect(() => {
    const isCheckedQueryParam = searchParams.get('toggle') === 'true';
    setIsChecked(isCheckedQueryParam);
  }, [searchParams]);

  const handleToggle = () => {
    const newIsChecked = !isChecked;
    setIsChecked(newIsChecked);
    searchParams.set('toggle', String(newIsChecked));
    navigate(`?${searchParams.toString()}`, { replace: true });
  };

  console.log(courses);

  return (
    <>
      <div className="flex">
        <input
          type="checkbox"
          id="choose-me"
          className="peer hidden"
          checked={isChecked}
          onChange={handleToggle}
        />
        <label
          htmlFor="choose-me"
          className="select-none cursor-pointer rounded-lg border-2 border-gray-200 py-3 px-6 font-bold text-gray-200 transition-colors duration-200 ease-in-out peer-checked:bg-gray-200 peer-checked:text-gray-900 peer-checked:border-gray-200"
        >
          Toggle archived courses
        </label>
      </div>
      {courses.length > 0 ? (
        <div className="flex justify-center h-screen">
          <div className="container grid grid-cols-3 gap-4 m-16">
            {courses.map((course, index) => (
              <div className="aspect-w-1" key={index}>
                <CourseMyItem course={course} />
              </div>
            ))}
          </div>
        </div>
      ) : (
        <p>Awaiting</p>
      )}
    </>
  );
};
