import { get, patch } from "./requests"



export const getAdminCourses=(search)=>{
    return get(`admin/resources${search}`);
}

export const getAdminTopicsByCourseName=(courseId)=>{
    return get(`admin/resource/${courseId}`)
}

export const getTopicSecondaryDetailsByTopicId=(topicId)=>{
    return get(`admin/resource/secondary/${topicId}`);
}

export const updateTopicSecondaryDetails=(topicId,updatedData)=>{
    return patch(`admin/resource/secondary/edit/${topicId}`,updatedData);
}