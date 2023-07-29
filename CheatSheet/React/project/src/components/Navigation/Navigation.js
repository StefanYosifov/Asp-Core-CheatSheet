import { NavLink, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { getUserId } from '../../api/Requests/profile';
import { validateToken } from '../../api/Requests/validateJWTtoken';
import { useUserDetails } from '../../stores/useUserDetails';
import { URLS } from '../../constants/URLConstants';

export const Navigation = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const [userId, setUserId] = useState(undefined);
  const userIsAuthenticated = useUserDetails((state) => state.isAuthenticated);
  const userData = useUserDetails((state) => state.user);
  const navigate = useNavigate();

  const isAuthenticated = validateToken();
  console.log(isAuthenticated);

  useEffect(() => {
    getUserId().then(res => setUserId(res.data));
  }, [userId]);

  const handleMenuClick = () => {
    setMenuOpen(!menuOpen);
  };

  console.log(userData);
  console.log(userIsAuthenticated);
  return (
    <nav className="bg-gradient-to-r from-bgBlackUI-0 to to-black border-b  border-bg">
      <ul className="flex justify-start text-lg items-center py-4 px-6 m-0">
        <div className="text-lg font-bold md:py-0 py-4">
          Logo
        </div>
        {userIsAuthenticated === false ? (
          <>
            <li>
              <NavLink to="/login" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
                Login
              </NavLink>
            </li>
            <li>
              <NavLink to="/register" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
                Register
              </NavLink>
            </li>
          </>
        ) : (
          <>
            <ul className="md:px-2 ml-auto md:flex md:space-x-2 absolute md:relative top-full left-0 right-0 text-slate-100">
              {userData.roles.includes("Administrator") &&
                <NavLink to={URLS.PRIVATE} className="flex md:inline-flex p-4 items-center hover:bg-gray-500">
                  <span>Administrator</span>
                </NavLink>
              }
              <li>
                <NavLink to="/home" className="flex md:inline-flex p-4 items-center hover:bg-gray-500">
                  <span>Home</span>
                </NavLink>
              </li>
              <li>
              </li>
              <li className="relative group">
                <div className="flex justify-between md:inline-flex p-4 items-center hover:bg-gray-500 space-x-2">
                  <span>Resources</span>
                  <svg xmlns="http://www.w3.org/2000/svg" className="w-4 h-4 fill-current pt-1" viewBox="0 0 24 24">
                    <path d="M0 7.33l2.829-2.83 9.175 9.339 9.167-9.339 2.829 2.83-11.996 12.17z" />
                  </svg>
                </div>
                <ul className="absolute top-full right-0 hidden md:block w-48 bg-slate-700 shadow-lg rounded-b opacity-0 transform -translate-y-10 group-hover:opacity-100 group-hover:translate-y-0 transition duration-300">
                  <li>
                    <NavLink to="resources/1" className="flex px-4 py-3 hover:bg-gray-500">
                      All
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="resource/add" className="flex px-4 py-3 hover:bg-gray-500">
                      Add
                    </NavLink>
                  </li>
                </ul>
              </li>
              <li className="relative group">
                <div className="flex justify-between md:inline-flex p-4 items-center hover:bg-gray-500 space-x-2">
                  <span>Courses</span>
                  <svg xmlns="http://www.w3.org/2000/svg" className="w-4 h-4 fill-current pt-1" viewBox="0 0 24 24">
                    <path d="M0 7.33l2.829-2.83 9.175 9.339 9.167-9.339 2.829 2.83-11.996 12.17z" />
                  </svg>
                </div>
                <ul className="absolute top-full right-0 hidden md:block w-48 bg-slate-700 shadow-lg rounded-b opacity-0 transform -translate-y-10 group-hover:opacity-100 group-hover:translate-y-0 transition duration-300">
                  <li>
                    <NavLink to="course/all/1" className="flex px-4 py-3 hover:bg-gray-500">
                      All
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="course/mine/1" className="flex px-4 py-3 hover:bg-gray-500">
                      Mine
                    </NavLink>
                  </li>
                </ul>
              </li>
              <li>
                <NavLink to="about" className="flex md:inline-flex p-4 items-center hover:bg-gray-500">
                  <span>About us</span>
                </NavLink>
              </li>
            </ul>
            <li className="relative">
              <button className="text-white px-2 py-1 rounded-lg hover:bg-red-700 focus:outline-none mr-2" onClick={handleMenuClick}>
                Profile <i className="fas fa-caret-down ml-2"></i>
              </button>
              {menuOpen && userId !== undefined && (
                <ul className="absolute right-0 mt-2 py-2 w-40 bg-white rounded-lg shadow-xl">
                  <li>
                    <NavLink to={`/profile/${userId}`} className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      My Profile
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="/settings" className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      Settings
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="/logout" className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      Logout
                    </NavLink>
                  </li>
                </ul>
              )}
            </li>
          </>
        )}
      </ul>
    </nav>
  );
}
