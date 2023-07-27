import { get } from "./requests"

export const getUserId=()=>{
    return get(`profile/myUser`);
}