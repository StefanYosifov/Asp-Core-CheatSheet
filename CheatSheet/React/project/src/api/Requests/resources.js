import {del, get,patch,post} from '../Requests/requests'

export const getTotalPages=()=>{
   return get('resource/pages').then(res=>res.data);
}

export const getResourceLikes=()=>{
    return get(`like/resource/all`);
}

export const getPublicResources=(id,search)=>{
    console.log(search);
    return get(`resource/${id}/${search}`);
}

export const getMyResource=()=>{
    return get(`resource/my`);
}

export const getResourceToEdit=(id)=>{
    return get(`resource/get/edit/${id}`);
}

export const addResource=(formData)=>{
    const data={
        "Title":formData.title.toString(),
        "Content":formData.content.toString(),
        "imageUrl":formData.imageUrl.toString(),
        "categoryIds":formData.categoryIds
      }
  
       return post(`resource/add`,JSON.stringify(data))
       .then(res=>console.log(res));
}

export const deleteResource=(id)=>{
    return del(`resource/delete/${id}`,id);
}

export const editResource=(id,resource)=>{
    const data={
        title:resource.title,
        imageUrl:resource.imageUrl,
        content:resource.content,
        categoryIds:resource.chosenCategories.map(x=>x.id)
    };
     return patch(`resource/patch/edit/${id}`,data);
}

export const changeVisibility=(id)=>{
    return patch(`resource/visibility/${id}`,id);
}