import { clearUserData, clearUserToken } from "../../../api/util"


export const Logout=()=>{
    clearUserData();
    clearUserToken();
}