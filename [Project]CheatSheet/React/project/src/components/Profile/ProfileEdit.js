import { useState } from "react";
import { updateProfile } from "../../api/Requests/profile";

export const ProfileEdit = ({ profileData }) => {
    const [formData, setFormData] = useState({
        profilePictureUrl: profileData.user.profilePictureUrl,
        ProfileDescription: profileData.user.userProfileDescription,
        ProfileBackground: profileData.user.userProfileBackground,
        userJob: profileData.user.userJob,
        userEducation: profileData.user.userEducation,
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
            <div className="mx-auto max-w-3xl">
                <div className="mt-5">
                    <div className="rounded-md shadow-sm bg-white">
                        <form onSubmit={handleSubmit}>
                            <div className="px-4 py-5 sm:p-6">
                                <div className="grid grid-cols-6 gap-6">
                                    <div className="col-span-6 sm:col-span-4">
                                        <label htmlFor="username" className="block text-sm font-medium leading-5 text-gray-700">
                                            Username
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <input
                                                id="username"
                                                className="form-input block w-full sm:text-sm sm:leading-5"
                                                disabled={true}
                                                defaultValue={profileData.user.userName}
                                            />
                                        </div>
                                    </div>

                                    <div className="col-span-6 sm:col-span-4">
                                        <label htmlFor="profilePictureUrl" className="block text-sm font-medium leading-5 text-gray-700">
                                            Profile Picture URL
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <input
                                                id="profilePictureUrl"
                                                className="form-input block w-full transition duration-150 ease-in-out sm:text-sm sm:leading-5"
                                                name="profilePictureUrl"
                                                value={formData.profilePictureUrl}
                                                onChange={handleInputChange}
                                            />
                                        </div>
                                    </div>

                                    <div className="col-span-6 sm:col-span-4">
                                        <label htmlFor="profileDescription" className="block text-sm font-medium leading-5 text-gray-700">
                                            Profile Description
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <textarea
                                                id="profileDescription"
                                                className="form-textarea block w-full transition duration-150 ease-in-out sm:text-sm sm:leading-5"
                                                name="profileDescription"
                                                value={formData.profileDescription || ''}
                                                onChange={handleInputChange}
                                            ></textarea>
                                        </div>
                                    </div>

                                    <div className="col-span-6">
                                        <label htmlFor="profileBackground" className="block text-sm font-medium leading-5 text-gray-700">
                                            Background URL
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <input
                                                id="profileBackground"
                                                className="form-input block w-full transition duration-150 ease-in-out sm:text-sm sm:leading-5"
                                                name="profileBackground"
                                                value={formData.profileBackground || ''}
                                                onChange={handleInputChange}
                                            />
                                        </div>
                                    </div>

                                    <div className="col-span-6 sm:col-span-6 lg:col-span-2">
                                        <label htmlFor="userJob" className="block text-sm font-medium leading-5 text-gray-700">
                                            Job
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <input
                                                id="userJob"
                                                className="form-input block w-full transition duration-150 ease-in-out sm:text-sm sm:leading-5"
                                                name="userJob"
                                                value={formData.userJob || ''}
                                                onChange={handleInputChange}
                                            />
                                        </div>
                                    </div>
                                    <div className="col-span-6 sm:col-span-6 lg:col-span-2">
                                        <label htmlFor="userEducation" className="block text-sm font-medium leading-5 text-gray-700">
                                            Education
                                        </label>
                                        <div className="mt-1 rounded-md shadow-sm">
                                            <input
                                                id="userEducation"
                                                className="form-input block w-full transition duration-150 ease-in-out sm:text-sm sm:leading-5"
                                                name="userEducation"
                                                value={formData.userEducation || ''}
                                                onChange={handleInputChange}
                                            />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <button
                                type="submit"
                                className="inline-flex items-center ml-4 px-4 py-2 bg-red-500 border border-transparent rounded-md font-semibold text-xs text-white uppercase tracking-widest hover:bg-blue-500 active:bg-blue-700 focus:outline-none focus:border-blue-900 focus:shadow-outline-gray disabled:opacity-50 transition ease-in-out duration-150"
                            >
                                Update Information
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </>
    )
}