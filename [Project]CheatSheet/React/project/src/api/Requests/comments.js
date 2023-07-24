import { del, get, patch, post } from "./requests";


export const getComments=(id)=>{
    return get(`comment/get/${id}`);
  }

export const sendAComment=(comment)=>{
    const data={
      "resourceId":comment.id,
      "Content":comment.comment,
    }
    return post(`comment/send`,data);
  }

export const editComment=(id,comment)=>{
  return patch(`comment/edit/${id}`,{"content":comment});
}

export const deleteComment = (id) => {
  console.log(id);
  return del(`comment/delete/${id}`);
}