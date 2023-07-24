import { get, post } from "./requests"

export const getAllCourses = (page,query) => {
    return get(`course/all/${page}${query}`);
}

export const getMyCourses=(page,toggle)=>{
    console.log(toggle);
    return get(`course/my/${page}?toggle=${toggle}`);
}

export const getCoursePaymentDetails = (id) => {
    return get(`course/payment/${id}`);
}

export const getCoursesCategories = () => {
    return get(`course/languages`);
}

export const getFeaturedCourses=()=>{
    return get(`course/upcomingFeatured`);
}

export const joinCoursePayment = (id) => {
    return post(`course/payment/${id}`);
}

export const getCoursePreviewDetails=(id)=>{
    return get(`course/preview/${id}`);
}

export const getCoursePreviewDetailsExtra=(id)=>{
    return get(`course/preview/extra/${id}`);
}

