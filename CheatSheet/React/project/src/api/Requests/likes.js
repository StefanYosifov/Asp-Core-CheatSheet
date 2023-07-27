import { get, post, postWithoutNotification } from "./requests";

export const getLikes = (resourceId) => {
  return get(`like/resource/${resourceId}`, { resourceId })
    .then((response) => response.data);
}


export const likeResource=(resourceId)=>{
   return post(`like/resource/like/${resourceId}`,{resourceId});
}

export const dislikeResource=(resourceId)=>{
   return post(`like/resource/remove/${resourceId}`,{resourceId});
}

export const likeComment=(commentId)=>{
   return postWithoutNotification('like/comment/like',{commentId})
}

export const dislikeComment=(commentId)=>{
   return postWithoutNotification('like/comment/remove',{commentId})
}