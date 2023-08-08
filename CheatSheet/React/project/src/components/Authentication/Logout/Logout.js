import { useUserDetails } from "../../../stores/useUserDetails";


export const Logout=()=>{
    const logout=useUserDetails((state)=>state.logout);
    logout();
}