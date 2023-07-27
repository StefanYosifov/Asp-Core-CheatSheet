import { get,post } from "./requests";



export const getVideoId=(videoId)=>{
    return get(`videos/id/${videoId}`);
}