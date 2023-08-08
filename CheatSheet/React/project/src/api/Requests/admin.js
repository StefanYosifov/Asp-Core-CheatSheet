import { get, patch, post } from "./requests";



export const getAdminCourses=(search)=>{
    return get(`admin/resources${search}`);
}

export const getAdminTopicsByCourseName=(courseId)=>{
    return get(`admin/resource/${courseId}`)
}

export const getTopicSecondaryDetailsByTopicId=(topicId)=>{
    return get(`admin/resource/secondary/${topicId}`);
}

export const getIssues=(query)=>{
    return get(`admin/issues?${query}`);
}

export const updateTopicSecondaryDetails=(topicId,updatedData)=>{
    return patch(`admin/resource/secondary/edit/${topicId}`,updatedData);
}

export const createdCourse=(createdCourse)=>{
    createdCourse.startDate=String(createdCourse.startDate).replace("T"," ");
    createdCourse.endDate=String(createdCourse.endDate).replace("T"," ");
    return post(`admin/course/create`,createdCourse);
}

export const createdTopic=(courseName,topicData)=>{
    topicData.topicStartDate=String(topicData.topicStartDate).replace("T"," ");
    topicData.topicEndDate=String(topicData.topicEndDate).replace("T"," ");    
    return post(`admin/topic/create/${courseName}`,topicData);
}