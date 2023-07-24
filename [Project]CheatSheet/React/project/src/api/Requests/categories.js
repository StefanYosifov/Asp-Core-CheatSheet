import { get } from "./requests";

export const getCategories=()=>{
    return get(`category/get`);
}