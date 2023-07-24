import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom";
import { getDetails } from "../../api/Requests/details";
import { getComments, sendAComment } from '../../api/Requests/comments'
import { Comments } from '../Helper components/Comments'
import CommentForm from "../Helper components/CommentForm";
import { FaThumbsUp, FaComment } from 'react-icons/fa';
import { dislikeResource, getLikes, likeResource } from "../../api/Requests/likes";
import { deleteResource } from "../../api/Requests/resources";
import { getUserId } from "../../api/Requests/utilRequests";
const parse = require('html-react-parser');



export const Detail = () => {
  const [details, setDetails] = useState([]);
  const [comment, setComments] = useState([]);
  const [likes, setLikes] = useState();
  const [hasLiked, setHasLiked] = useState(false);
  const [userId, setUserId] = useState();
  const { id } = useParams();
  let navigate = useNavigate();

  useEffect(() => {
    Promise.all([getDetails(id), getUserId(), getComments(id), getLikes(id)])
      .then(([detailsRes, userIdRes, commentsRes, likesRes]) => {
        console.log(detailsRes.data);
        setDetails(() => detailsRes.data);
        setHasLiked(() => detailsRes.data.hasLiked);
        setUserId(() => userIdRes.data);
        setComments(() => commentsRes.data);
        setLikes(likesRes);
      })
      .catch((error) => console.error(error));
  }, []);

  const handleDeleteResource = () => {
    deleteResource(id)
      .then((res) => {
        console.log(res);
        if (res.status === 200) {
          navigate('/resources/1');
        }
      })
  }

  const handleSubmitComment = (comment) => {
    sendAComment({ comment, id });
  };

  const handleLike = (event) => {
    console.log(likes);
    console.log(details);
    event.preventDefault();
    if (hasLiked) {
      dislikeResource(id).then((res)=>console.log(res));
      setLikes((oldLikes) => oldLikes - 1);
    } else {
      likeResource(id).then((res)=>console.log(res));
      setLikes((oldLikes) => oldLikes + 1);
    }
    setHasLiked((state) => !state);
  };


console.log(userId);

  return (
    <>
      {userId && details && comment && (
        <div className="bg-red-400 min-h-screen flex flex-col justify-between">
          <div className="w-10/12 mx-auto pt-12">
            <div className="flex flex-col items-center bg-gray-200 text-center p-4 rounded-lg shadow-lg">
              <img
                src={details.imageUrl}
                alt="Image"
                className="w-6/12 rounded-lg shadow-md mb-4"
              />
              <div className="flex items-center text-xs mb-4">
                <div className="flex items-center mr-4">
                  <div className="rounded-full p-2 mr-2 bg-blue-500">
                    <FaThumbsUp size={20} className="text-white" />
                  </div>
                  <span className="text-gray-700">{likes} Likes</span>
                </div>
                <div className="flex items-center">
                  <div className="rounded-full p-2 mr-2 bg-blue-500">
                    <FaComment size={20} className="text-white" />
                  </div>
                  <span className="text-gray-700">{comment.length} Comments</span>
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
              <div className="max-w-2xl mb-4">
                <h2 className="text-2xl font-bold mb-2">{details.title}</h2>
                {parse(details.content)}
              </div>
              <div className="flex justify-between w-full">
                <button
                  className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2"
                  onClick={handleLike}
                >
                  Like
                </button>
                <div>
                  {details.userId === userId ? <>
                    <button
                      className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded mr-2"
                    >
                      Edit
                    </button>
                    <button
                      className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded"
                      onClick={handleDeleteResource}
                    >
                      Delete
                    </button>
                  </>
                    : ""}
                </div>
              </div>
            </div>
          </div>
          <div className="mt-4 w-10/12 mx-auto">
            <h3 className="text-lg font-bold mb-2">Add a Comment</h3>
            <CommentForm />
          </div>
          <div className="bg-gray-200 py-4 w-10/12 mx-auto rounded-lg shadow-lg">
            <div className="w-full">
              <h3 className="text-lg font-bold mb-2">Comments</h3>
              <ul className="list-disc">
                {comment &&
                  comment.map((comment) => (
                    <Comments key={comment.id} commentModels={comment} userId={userId} />
                  ))}
              </ul>
            </div>
          </div>
        </div>
      )}
    </>
  )
};

export default Detail;
