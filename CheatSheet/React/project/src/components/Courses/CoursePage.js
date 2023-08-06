import React, { useEffect, useState } from "react";
import { getAllTopics } from "../../api/Requests/topics";
import { Link, useLocation, useParams } from "react-router-dom";
import { TiWarningOutline, TiSocialYoutube } from "react-icons/ti";
import { Issue } from "../Issue/Issue";
import { URLS } from "../../constants/URLConstants";
import useIssueStore from "../../stores/useIssueStore";

export const CoursePage = () => {
  const [expandedItem, setExpandedItem] = useState(null);
  const [topics, setTopics] = useState([]);
  const { id } = useParams();
  const location = useLocation();

  const isOpen = useIssueStore((state) => state.isOpen);
  const setIsOpen = useIssueStore((state) => state.setIsOpen);

  console.log(isOpen);
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


  console.log(topics);
  return (
    <div className="w-full h-full bg-bgWhiteUI-0 border">
      <h1 className="text-center mt-24 text-xl ">Welcome to </h1>
      <section className="h-screen bg-bgWhiteUI-0 justify-center flex">
        <div className="w-5/6 rounded bg-slate-200 my-16 shadow-2xl p-4">
          <p className="text-left ml-5 text-lg">Themes</p>
          {topics != null ? (
            <>
              <ul>
                <li>
                  <article>
                    <ul className="grid grid-cols-2 gap-2 mr-1 p-1">
                      {topics.map((item, index) => (
                        <>
                         {isOpen && <Issue showIssue={true}topicId={item.id} />}
                          <li
                            key={index}
                            className={`border rounded-lg p-4 ${expandedItem === index ? "bg-indigo-400" : ""
                              }`}
                            onClick={() => handleItemClick(index)}
                          >
                            <div className="flex items-center justify-between cursor-pointer p-2 bg-indigo-400">
                              <span>{index + 1}. {item.name}</span>
                              <span>{expandedItem === index ? "-" : "+"}</span>
                            </div>

                            {expandedItem === index && (
                              <div>
                                <div className="flex items-center mb-2">
                                  <TiSocialYoutube className="mr-2" />
                                  <Link
                                    to={`${URLS.COURSES_LESSON}${item.id}/${item.name}`}
                                  >
                                    <span className="hover:text-pinkUI-0 hover:cursor-pointer hover:font-semibold hover:border-b hover:border-b-pinkUI-0">Video for {item.name}</span>
                                  </Link>
                                </div>
                                <div className="flex items-cente" onClick={() => setIsOpen()}>
                                  <TiWarningOutline className="mr-2" />
                                  <span className="hover:text-pinkUI-0 hover:cursor-pointer hover:font-semibold hover:border-b hover:border-b-pinkUI-0 ">Report an issue</span>
                                </div>
                              </div>
                            )}
                          </li>
                        </>
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