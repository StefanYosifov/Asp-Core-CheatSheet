import { get } from "./requests"



export const getAdminCourses=(search)=>{
    return get(`admin/resources${search}`);
}