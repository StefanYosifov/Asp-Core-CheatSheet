
import { Navigate, Outlet, useLocation } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import { getUserData } from "../../api/util";

const RequireAuth = () => {
    const { auth } = useAuth();
    const location = useLocation();
    const user=getUserData();
    return (
        user
            ? <Outlet />
            : <Navigate to="/login" state={{from: location}} replace />
    )
}

export default RequireAuth;