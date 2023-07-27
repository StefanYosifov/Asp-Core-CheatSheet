import { useState, useEffect } from 'react';
import { dislikeComment, likeComment } from "../../api/Requests/likes";
import { deleteComment, editComment } from "../../api/Requests/comments"
import { PostRequestWithRedirection } from '../../common/Request';
import { SuccessfulAlert } from './SuccessfulAlert';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


export const Comments = ({ commentModels, userId }) => {
  const [numLikes, setNumLikes] = useState(commentModels.commentLikes.length);
  const [hasLiked, setHasLiked] = useState(commentModels.hasLiked);
  const [isEditing, setIsEditing] = useState(false);
  const [editedComment, setEditedComment] = useState(commentModels.content);
  const [saveClicked, setSaveClicked] = useState(false);

  console.log(commentModels);

  useEffect(() => {
    if (saveClicked) {

    }
  }, [saveClicked]);

  const handleSaveClick = (event) => {
    event.preventDefault();
    const commentId = commentModels.id;
    editComment(commentId, editedComment)
      .then((response) => {
        if (response.status === 404 || response.status === 200) {
          toast.success(response.data);
          setIsEditing(false);
          setSaveClicked(true);
        }
      }).catch((error) => {
        toast.error(error.response.data);
      });
  };

  console.log(userId);
  console.log(commentModels);

  function handleLikeClick(event) {
    event.preventDefault();
    const commentId = commentModels.id;
    console.log(hasLiked);
    if (hasLiked) {
      dislikeComment(commentId)
        .then((response) => {
          if (response.status === 200) {
            toast.success(response.data);
            setNumLikes((oldLikes) => (oldLikes - 1));
          }
        }).catch((error) => {
          toast.error(error.response.data);
        })
    } else {
      likeComment(commentId)
        .then((response) => {
          if (response.status === 200) {
            toast.success(response.data);
            setNumLikes((oldLikes) => (oldLikes + 1));
          }
        }
        ).catch((error) => {
          toast.error(error.response.data);
        })
    }
    setHasLiked(state => !state);
  }



  const handleDeleteClick = () => {
    const commentId = commentModels.id;
    deleteComment(commentId)
      .then((response) => {
        console.log(response);
        if (response.status === 200) {
          console.log('Comment deleted successfully');
        }
      });
  };

  const handleEditClick = (event) => {
    event.preventDefault();
    setIsEditing(true);
  };

  const handleCancelClick = (event) => {
    event.preventDefault();
    setIsEditing(false);
    setEditedComment(commentModels.content);
  };

  const handleInputChange = (event) => {
    event.preventDefault();
    setEditedComment(event.target.value);
  };

  return (
    (
      <div className="p-4 mt-4 rounded-lg bg-gray-100 w-full">
        <div className="flex items-center mb-2">
          <img className="w-12 h-12 object-cover rounded-full border border-gray-300" src={commentModels.userProfileImage} alt={commentModels.userName} />
          <div className="ml-4">
            <h5 className="text-lg text-gray-800">{commentModels.userName}</h5>
            <p className="text-sm text-gray-600">{commentModels.createdAt}</p>
          </div>
        </div>
        {isEditing ? (
          <>
            <textarea className="text-gray-800 break-words ml-4 mb-2" value={editedComment} onChange={handleInputChange} />
            <div className="flex justify-end">
              <button className="text-gray-600 hover:text-gray-800 mr-2" onClick={handleCancelClick}>Cancel</button>
              <button className="text-gray-600 hover:text-gray-800" onClick={handleSaveClick}>Save</button>
            </div>
          </>
        ) : (

          <>
            <p className="text-gray-800 break-words ml-4">{commentModels.content}</p>
            <div className="flex justify-end mt-2">
              {userId === commentModels.userId ? <>
                <button className="text-gray-600 hover:text-gray-800" onClick={handleEditClick}>Edit</button>
                <button className="text-gray-600 hover:text-gray-800 ml-2" onClick={handleDeleteClick}>Delete</button>
              </> : console.log(`${userId} ${commentModels.userId}`)}
              <button className="text-gray-600 hover:text-gray-800 ml-2" onClick={handleLikeClick}>
                <span className="ml-1">{numLikes}</span>
              </button>
            </div>
          </>
        )}
      </div>
    )
  )
};

