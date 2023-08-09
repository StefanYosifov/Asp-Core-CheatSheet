import { useState } from "react";
import { updateProfile } from "../../api/Requests/profile";

export const ProfileEdit = ({ profileData }) => {

    {console.log(profileData) }

    const [formData, setFormData] = useState({
        profilePictureUrl: profileData.profilePictureUrl,
        ProfileDescription: profileData.userProfileDescription,
        ProfileBackground: profileData.userProfileBackground,
        userJob: profileData.userJob,
        userEducation: profileData.userEducation,
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({
            ...prevFormData,
            [name]: value,
        }));
    };


    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(formData);
        updateProfile(formData).then((res) => console.log(res.data));
    };

    return (
        <>
            <div className="mx-auto border shadow-md">
                <div className="mt-5">
                    <form onSubmit={handleSubmit}>
                        <div className="container p-4 divide-y-0">
                            <div>
                                <h1 className="text-xl">Profile details</h1>
                                <p>You have full control to manage your own account setting.</p>
                            </div>
                            <div className="flex my-4 w-full">
                                <img
                                    className="rounded-full w-16 h-16 object-cover"
                                    src="https://static01.nyt.com/images/2022/11/29/science/00tb-cats1/merlin_194921559_c9e53b04-169a-4144-bd76-9ec2d987c35c-superJumbo.jpg?quality=75&auto=webp" />
                                <div className="flex-row ml-4 items-end">
                                    <h3>Your avatar</h3>
                                    <p>If you wish to change the profile picture, make sure to include a valid link</p>
                                </div>
                            </div>
                            <div className="mt-4">
                                <h1>Personal details</h1>
                                <h3>Edit your personal information</h3>
                                <div className="grid grid-cols-2 gap-4">
                                    <div>
                                        <label for="input-label" className="block text-sm font-medium mb-2 text-bgWhiteUI-0">
                                            Username
                                        </label>
                                        <input type="text" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm " placeholder="Here's your username"
                                            id="username"
                                            disabled={true}
                                            defaultValue={profileData.userName} />
                                    </div>
                                    <div className="">
                                        <label for="input-label" className="block text-sm font-medium mb-2 tracking-wide">
                                            Profile picture
                                        </label>
                                        <input type="text" className="py-3 px-4 w-full border-gray-200 rounded-md text-sm focus:border-pinkUI-0 focus:ring-pinkUI-0 dark:border-pinkUI-0 dark:text-gray-700" placeholder="This is placeholder"
                                            id="profilePictureUrl"
                                            name="profilePictureUrl"
                                            value={formData.profilePictureUrl || ''}
                                            onChange={handleInputChange} />
                                    </div>
                                    <div>
                                        <label for="input-label" className="block text-sm font-medium mb-2 tracking-wide">
                                            Profile description
                                        </label>
                                        <input type="text" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 dark:border-gray-700 dark:text-gray-400" placeholder="This is placeholder"
                                            id="profileDescription"
                                            name="profileDescription"
                                            value={formData.profileDescription || ''}
                                            onChange={handleInputChange} />
                                    </div>  <div>
                                        <label for="input-label" className="block text-sm font-medium mb-2 tracking-wide">
                                            Background Url
                                        </label>
                                        <input type="text" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 dark:border-gray-700 dark:text-gray-400" placeholder="This is placeholder"
                                            id="profileBackground"
                                            name="profileBackground"
                                            value={formData.profileBackground || ''}
                                            onChange={handleInputChange} />
                                    </div>  <div>
                                        <label for="input-label" className="block text-sm font-medium mb-2 tracking-wide">
                                            Job
                                        </label>
                                        <input type="text" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 dark:border-gray-700 dark:text-gray-400" placeholder="This is placeholder"
                                            id="userJob"
                                            name="userJob"
                                            value={formData.userJob || ''}
                                            onChange={handleInputChange} />
                                    </div>
                                    <div>
                                        <label for="input-label" className="block text-sm font-medium mb-2 tracking-wide">
                                            Education
                                        </label>
                                        <input type="text" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 dark:border-gray-700 dark:text-gray-400" placeholder="This is placeholder"
                                            id="userEducation"
                                            name="userEducation"
                                            value={formData.userEducation || ''}
                                            onChange={handleInputChange} />
                                    </div>
                                </div>
                            </div>
                            <button
                                type="submit"
                                className="inline-flex items-center mt-6 px-4 py-2 bg-red-500 border border-transparent rounded-md font-semibold text-xs text-white uppercase tracking-widest hover:bg-blue-500 active:bg-blue-700 focus:outline-none focus:border-blue-900 focus:shadow-outline-gray disabled:opacity-50 transition ease-in-out duration-150"
                            >
                                Update Information
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}