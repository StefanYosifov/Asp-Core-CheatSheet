
import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useUserDetails } from "../../stores/useUserDetails";

const RequireAuth = () => {
    const location = useLocation();
    const user=useUserDetails((state)=>state.user);
    console.log(user);
    console.log(user);
    console.log(user);
    console.log(user);
    
    return (
        user
            ? <Outlet />
            : <Navigate to="/login" state={{from: location}} replace />
    )
}

export default RequireAuth;