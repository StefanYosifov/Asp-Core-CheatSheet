import { Link, useNavigate, useParams } from "react-router-dom";
import { useEffect } from "react";
import { FaThumbsUp, FaComment } from 'react-icons/fa';
import { URLS } from "../../../constants/URLConstants";
import { CommentSection } from "../../Helper components/CommentSection";
import CommentForm from "../../Helper components/CommentForm";
import useCommentsStore from "../../../stores/useCommentsStore";
import { useUserDetails } from "../../../stores/useUserDetails";
import useDetailsStore from "../../../stores/useDetailsStore";
const parse = require('html-react-parser');



export const Details2 = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const isLoading = useDetailsStore((state) => state.isLoading);
  const details = useDetailsStore((state) => state.data);
  const getDetails = useDetailsStore((state) => state.getResource);
  const likeResource = useDetailsStore((state) => state.likeResource);
  const dislikeResource = useDetailsStore((store) => store.dislikeResource);
  const deleteDetails = useDetailsStore((state) => state.deleteResource);
  const changeVisibility = useDetailsStore((state) => state.changeVisibility);

  const comments = useCommentsStore((state) => state.data);
  const getComments = useCommentsStore((state) => state.getAllComments);

  const user = useUserDetails((state) => state.user);

  useEffect(() => {
    getDetails(id);
    getComments(id);
    console.log(details);
  }, []);

  const handleDeleteResource = () => {
    deleteDetails(id);
    navigate(`${URLS.RESOURCES}/1`, {
      replace: true,
      exact: true,
    });
  }

  

  console.log(details);

  function showResource() {
    const visibilityValue = details.isPublic === true ? true : false;
    return (
      <div className="w-10/12 pt-12">
        <div className="flex flex-col items-center bg-slate-100 text-center p-4 rounded-lg shadow-lg">
          <img
            src={details.imageUrl}
            alt="Image"
            className="w-6/12 rounded-lg shadow-md mb-4"
          />
          <div>

            {details.userId === user.userId &&
              <>
                <input
                  className="mr-2 mt-[0.3rem] h-3.5 w-8 appearance-none rounded-[0.4375rem] bg-neutral-300 before:pointer-events-none before:absolute before:h-3.5 before:w-3.5 before:rounded-full before:bg-transparent before:content-[''] after:absolute after:z-[2] after:-mt-[0.1875rem] after:h-5 after:w-5 after:rounded-full after:border-none after:bg-neutral-100 after:shadow-[0_0px_3px_0_rgb(0_0_0_/_7%),_0_2px_2px_0_rgb(0_0_0_/_4%)] after:transition-[background-color_0.2s,transform_0.2s] after:content-[''] checked:bg-primary checked:after:absolute checked:after:z-[2] checked:after:-mt-[3px] checked:after:ml-[1.0625rem] checked:after:h-5 checked:after:w-5 checked:after:rounded-full checked:after:border-none checked:after:bg-primary checked:after:shadow-[0_3px_1px_-2px_rgba(0,0,0,0.2),_0_2px_2px_0_rgba(0,0,0,0.14),_0_1px_5px_0_rgba(0,0,0,0.12)] checked:after:transition-[background-color_0.2s,transform_0.2s] checked:after:content-[''] hover:cursor-pointer focus:outline-none focus:ring-0 focus:before:scale-100 focus:before:opacity-[0.12] focus:before:shadow-[3px_-1px_0px_13px_rgba(0,0,0,0.6)] focus:before:transition-[box-shadow_0.2s,transform_0.2s] focus:after:absolute focus:after:z-[1] focus:after:block focus:after:h-5 focus:after:w-5 focus:after:rounded-full focus:after:content-[''] checked:focus:border-primary checked:focus:bg-primary checked:focus:before:ml-[1.0625rem] checked:focus:before:scale-100 checked:focus:before:shadow-[3px_-1px_0px_13px_#3b71ca] checked:focus:before:transition-[box-shadow_0.2s,transform_0.2s] dark:bg-neutral-600 dark:after:bg-neutral-400 dark:checked:bg-primary dark:checked:after:bg-primary dark:focus:before:shadow-[3px_-1px_0px_13px_rgba(255,255,255,0.4)] dark:checked:focus:before:shadow-[3px_-1px_0px_13px_#3b71ca]"
                  type="checkbox"
                  role="switch"
                  checked={visibilityValue}
                  onChange={() => changeVisibility(id)} />
                <label
                  className="inline-block pl-[0.15rem] hover:cursor-pointer"
                  htmlFor="flexSwitchChecked"
                >Change visibility</label>
              </>
            }
          </div>
          <div className="flex items-center text-xs mb-4">
            <div className="flex items-center mr-4">
              <div className="rounded-full p-2 mr-2 bg-blue-500">
                <FaThumbsUp size={20} className="text-white" />
              </div>
              <span className="text-gray-700">{details.likes} Likes</span>
            </div>
            <div className="flex items-center">
              <div className="rounded-full p-2 mr-2 bg-blue-500">
                <FaComment size={20} className="text-white" />
              </div>
              <span className="text-gray-700">{comments.length} Comments</span>
            </div>
          </div>
          <div className="flex justify-center mb-4">
            <ul className="flex flex-wrap justify-center gap-2">
              {details &&
                details.categoryNames &&
                details.categoryNames.map((categoryName) => (
                  <li
                    key={categoryName}
                    className="px-3 py-1 text-gray-700 bg-gray-300 rounded-full"
                  >
                    {categoryName}
                  </li>
                ))}
            </ul>
          </div>
          <div className="max-w-2xl mb-4 dark:text-primary-50">
            <h2 className="text-2xl font-bold mb-2">{details.title}</h2>
            <div >
            {parse(String(details.content).toString())}
            </div>
          </div>
          <div className="flex justify-between w-full">
            {details.hasLiked == false ?
              <button
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2"
                onClick={(_) => likeResource(id)}
              >
                Like
              </button>
              : <button
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2"
                onClick={(_) => dislikeResource(id)}
              >
                DISLIKE
              </button>}
            <div>
              {details.userId === user.userId ? (
                <>
                  <Link to={`${URLS.RESOURCES_EDIT}/${id}`}>
                    <button
                      className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded mr-2"
                    >
                      Edit
                    </button>
                  </Link>
                  <button
                    className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded"
                    onClick={handleDeleteResource}
                  >
                    Delete
                  </button>
                </>
              ) : ""}
            </div>
          </div>
        </div>
      </div>
    )
  }

  return (
    <>
      <div className=" flex flex-col justify-between items-center">
        {showResource()}
        <CommentForm />
        <CommentSection />
      </div>
    </>
  )
}
