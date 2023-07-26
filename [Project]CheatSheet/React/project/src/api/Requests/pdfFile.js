import { get } from "./requests"



export const getPdfFile=(id)=>{
    return get(`aws/${id}`);
}