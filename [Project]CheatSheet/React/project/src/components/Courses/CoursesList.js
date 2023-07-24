import { useEffect, useState } from "react";
import { getAllCourses } from "../../api/Requests/courses";
import { CoursesItem } from "./CoursesItem";
import { useLocation, useNavigate, useParams, useSearchParams } from "react-router-dom";


export const CoursesList = () => {
    const [courses, setCourses] = useState([]);
    const [searchParams]=useSearchParams();
    const {id}=useParams();

    const location = useLocation();
    const navigate=useNavigate();

    console.log(searchParams);
    console.log(searchParams);

  
    useEffect(() => {
      console.log(`Change`);


      getAllCourses(id).then((res) => setCourses(res.data));
    }, [location]);
  
    const handleApplyFilter = (selectedLanguage, selectedPrice) => {
      getAllCourses(id, selectedLanguage, selectedPrice)
        .then((res) => setCourses(res.data))
        .catch((error) => {
      
        });
  
      const queryParams = new URLSearchParams();
      if (selectedLanguage !== "") {
        queryParams.append("language", selectedLanguage);
      }
      if (selectedPrice !== "") {
        queryParams.append("price", selectedPrice);
      }

      navigate(`${location.pathname}?${queryParams.toString()}`);
    };



    return (
      <div className="container mx-auto">
      
      </div>
    );
  };