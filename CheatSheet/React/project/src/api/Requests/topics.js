import { get } from "./requests"




export const getAllTopics=(id)=>{
    return get(`course/topic/all/${id}`)
}