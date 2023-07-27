import { get, post } from "./requests"



export const getIssueCategories=()=>{
    return get(`issue/categories`);
}

export const postIssue=(issue)=>{
    console.log(issue);
    return post(`issue/add`,issue);
}