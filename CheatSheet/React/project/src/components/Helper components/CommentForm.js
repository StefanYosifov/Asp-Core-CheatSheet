import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { CgClose } from "react-icons/cg"
import useCommentsStore from '../../stores/useCommentsStore';
import useCommentStore from '../../stores/useCommentStore';


const MINLENGHT=10;

export const CommentForm = () => {
  const { id } = useParams();

  const comment = useCommentStore((state) => state.comment);
  const setComment = useCommentStore((state) => state.setComment);
  const submit = useCommentsStore((state) => state.submitAComment);
  const clear=useCommentStore((state)=>state.clearComment);

  useEffect(() => {
    console.log(comment);
  }, [comment])

  const handleSubmit = (e) => {
    e.preventDefault();
    submit(comment, id);
  };

  return (
    <form onSubmit={handleSubmit} className='flex justify-center my-12'>
      <div className="h-80 px-7 w-[700px] rounded-[12px] bg-white p-4 shadow-md border">
        <p className="text-xl font-semibold text-blue-900 cursor-pointer transition-all hover:text-black">
          Add Comment
        </p>
        <textarea className="h-40 px-3 text-sm py-1 mt-5 outline-none border-gray-300 w-full resize-none border rounded-lg placeholder:text-sm"
          placeholder="Add your comments here"
          onChange={(e) => setComment(e.currentTarget.value)} value={comment}>
        </textarea>

        <div className="flex justify-between mt-2">
          <p className="text-sm text-blue-900 ">{MINLENGHT-comment.length<=0?<p>You can post now</p>:<p>Your comments must have at least {MINLENGHT-comment.length} more characters</p>}</p>
          <div className="flex">
            <div className='self-center'>
            <CgClose onClick={clear}></CgClose>
            </div>
            <button className="h-12 w-28 bg-blue-400 text-sm text-white rounded-lg transition-all cursor-pointer hover:bg-blue-600"
              disabled={MINLENGHT-comment.length>=0}>
              Submit comment
            </button>
          </div>
        </div>
      </div>
    </form>
  );
}

export default CommentForm;