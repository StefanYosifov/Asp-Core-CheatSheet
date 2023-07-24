import React, { useEffect, useState } from "react";
import { FaCalendarCheck } from "react-icons/fa";
import { getAllTopics } from "../../api/Requests/topics";
import { Link, useLocation, useParams } from "react-router-dom";
import { TiWarningOutline, TiSocialYoutube } from "react-icons/ti";
import { Issue } from "../Issue/Issue";

export const CoursePage = () => {
  const [expandedItem, setExpandedItem] = useState(null);
  const [showIssueForm, setShowIssueForm] = useState(false);
  const [topics, setTopics] = useState([]);
  const { id } = useParams();
  const location = useLocation();
  const data = location.state?.course;


  console.log(location);

  useEffect(() => {
    getAllTopics(id).then((res) => {
      setTopics(res.data);
    });
  }, []);

  const handleItemClick = (index) => {
    if (expandedItem === index) {
      setExpandedItem(null);
    } else {
      setExpandedItem(index);
    }
  };

  const handleShowIssueForm = (e) => {
    e.preventDefault();
    setShowIssueForm((res)=>res=!showIssueForm); 
  };

  
  console.log(topics);
  return (
    <div className="w-full h-full bg-slate-100">
      <h1 className="text-center mt-24">Welcome to </h1>
      <section className="h-screen bg-slate-100 justify-center flex">
        <div className="w-5/6 rounded bg-slate-200 my-16 shadow-2xl p-4">
          <p className="text-left ml-5 text-lg">Themes</p>
          {topics != null ? (
            <>
              <ul>
                <li>
                  <article>
                    <ul className="grid grid-cols-2 gap-2 mr-1 p-1">
                      {topics.map((item, index) => (
                        <li
                          key={index}
                          className={`border rounded-lg p-4 ${
                            expandedItem === index ? "bg-slate-300" : ""
                          }`}
                          onClick={() => handleItemClick(index)}
                        >
                          <div className="flex items-center justify-between cursor-pointer p-2 bg-slate-300">
                            {showIssueForm && <Issue showIssue={true}topicId={item.id} />}
                            <span>{index+1}. {item.name}</span>
                            <span>{expandedItem === index ? "-" : "+"}</span>
                          </div>
                          {expandedItem === index && (
                            <div className="">
                              <div className="flex items-center">
                                <TiSocialYoutube className="mr-2" />
                                <Link
                                  to={`/course/trainings/videos/${item.videoId}/${item.videoName}`}
                                >
                                  <span>Video for {item.name}</span>
                                </Link>
                              </div>
                              <div className="flex items-center" onClick={handleShowIssueForm}>
                                <TiWarningOutline className="mr-2" />
                                <span>Report an issue</span>
                              </div>
                            </div>
                          )}
                        </li>
                      ))}
                    </ul>
                  </article>
                </li>
              </ul>
            </>
          ) : (
            <p>No courses</p>
          )}
        </div>
      </section>
    </div>
  );
};