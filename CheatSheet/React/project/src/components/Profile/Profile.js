import { useEffect } from "react";
import { useState } from "react";
import { getProfileData, getUserId } from "../../api/Requests/profile";
import { useParams } from "react-router-dom";
import { ProfileEdit } from "./ProfileEdit";
import { ProfileResouces } from "./ProfileResources";
import { ProfileContent } from "./ProfileContent";


export const Profile = () => {
  const [profileData, setProfileData] = useState();
  const [activeItem, setActiveItem] = useState("profile");
  const [currentUserId, setCurrentUserId] = useState();
  const { id } = useParams();
  console.log(id);
  console.log(currentUserId);
  useEffect(() => {
    getProfileData(id).then((res) => { setProfileData(() => res) });
  }, [])

  useEffect(() => {
    getUserId().then((res) => setCurrentUserId(() => res.data));
  }, [])

const ACTIVE_ELEMENTS={
    PROFILE:"profile",
    POSTS:"posts",
    EDIT:"edit",
}

  const renderContent = () => {
    switch (activeItem) {
      case ACTIVE_ELEMENTS.PROFILE:
        return <ProfileContent profileData={profileData} />;
      case ACTIVE_ELEMENTS.POSTS:
        return <ProfileResouces />;
      case ACTIVE_ELEMENTS.EDIT:
        return <ProfileEdit profileData={profileData.user} />;
      default:
        return <ProfileContent profileData={profileData} />;
    }
  };

  console.log(id);

  return (
    <>
      {profileData != undefined ? (
        <div className="bg-gradient-to-b from-gray-500 to-gray-700 flex justify-center">
          <div className="bg-slate-100 h-full my-48 w-3/4 rounded">
            <section className="min-w-full items-start">
              <nav className="px-4 py-2">
                <ul className="flex flex-row justify-between">
                  <li
                    className={`text-lg font-semibold cursor-pointer ${activeItem === "profile" && "text-red-600"
                      }`}
                    onClick={() => setActiveItem("profile")}
                  >
                    My profile
                  </li>
                  <li
                    className={`text-lg font-semibold cursor-pointer ${activeItem === "posts" && "text-red-600"
                      }`}
                    onClick={() => setActiveItem("posts")}
                  >
                    My posts
                  </li>
                  {
                    (currentUserId === id) && (
                      <li
                        className={`text-lg font-semibold cursor-pointer ${activeItem === "edit" && "text-red-600"
                          }`}
                        onClick={() => setActiveItem("edit")}
                      >
                        Edit my profile
                      </li>
                    )
                  }
                </ul>
              </nav>
              <div className="p-6 text-gray-800 text-lg">
                {renderContent()}
              </div>
            </section>
          </div>
        </div>
      ) : <div
        className="inline-block h-12 w-12 animate-spin rounded-full border-4 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
        role="status">
        <span
          className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]"
        >Loading...</span
        >
      </div>}

      <div className="flex justify-center">
        <div className="container bg-red-700">
          <div className="h-96">
            <section className="bg-pinkUI-0 h-48">

            </section>
            <section className="h-48 bg-white">

            </section>
          </div>
          <div className="min-h-screen bg-blue-400 w-full flex flex-row">
            <div className="w-1/4 h-full bg-slate-800 rounded">
              <h1>Section</h1>
              <section className="mx-4 text-sm">
                <ul className="divide-y divide-gray-400">
                  <li className="p-2 hover:bg-slate-100 rounded"
                  onClick={()=>setActiveItem(ACTIVE_ELEMENTS.PROFILE)}>My profile</li>
                  <li className="p-2 hover:bg-slate-100 rounded"
                  onClick={()=>setActiveItem(ACTIVE_ELEMENTS.POSTS)}>My posts</li>
                  <li className="p-2 hover:bg-slate-100 rounded"
                  onClick={()=>setActiveItem(ACTIVE_ELEMENTS.EDIT)}>Edit profile</li>
                </ul>
              </section>
            </div>
            <div className="w-4/6 rounded">
               {renderContent()}
            </div>
          </div>
        </div>
      </div>
    </>
  )
};




export default Profile;