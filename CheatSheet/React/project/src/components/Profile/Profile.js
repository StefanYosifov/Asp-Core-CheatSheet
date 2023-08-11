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

  const ACTIVE_ELEMENTS = {
    PROFILE: "profile",
    POSTS: "posts",
    EDIT: "edit",
  }

  const renderContent = () => {
    switch (activeItem) {
      case ACTIVE_ELEMENTS.PROFILE:
        return <ProfileContent profileData={profileData} />;
      case ACTIVE_ELEMENTS.POSTS:
        return <ProfileResouces />;
      case ACTIVE_ELEMENTS.EDIT:
        return <ProfileEdit profileData={profileData.profileUser} />;
      default:
        return <ProfileContent profileData={profileData} />;
    }
  };

  console.log(id);

  return (
    <>
      {profileData != undefined ? (
        <div className="flex justify-center">
          <div className="container">
            <div className="min-h-screen w-full flex flex-row my-12">
              <div className="w-1/4 h-full bg-bgBlackUI-0 rounded text-bgWhiteUI-0 font-semibold border border-pinkUI-0">
                <h1 className="p-4 border-b-pinkUI-0">Section</h1>
                <section className="mx-4 text-sm">
                  <ul className="divide-y divide-pinkUI-0">
                    <li className="p-2 mb-1 hover:cursor-pointer"
                      onClick={() => setActiveItem(ACTIVE_ELEMENTS.PROFILE)}>My profile</li>
                    <li className="p-2 mb-1 hover:cursor-pointer"
                      onClick={() => setActiveItem(ACTIVE_ELEMENTS.POSTS)}>My posts</li>
                    <li className="p-2 mb-1 hover:cursor-pointer"
                      onClick={() => setActiveItem(ACTIVE_ELEMENTS.EDIT)}>Edit profile</li>
                  </ul>
                </section>
              </div>
              <div className="w-4/6 rounded border border-pinkUI-0 ml-4 shadow-lg">
                {renderContent()}
              </div>
            </div>
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


    </>
  )
};




export default Profile;