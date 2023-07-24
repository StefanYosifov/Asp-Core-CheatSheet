

export const ProfileContent = ({profileData}) => {
    console.log(profileData);
    return(
    <section className="relative py-16 bg-blueGray-200">
        <div className="flex flex-wrap justify-center">
            <div className="w-full lg:w-3/12 px-4 lg:order-2 flex justify-center">
            </div>
            <div className="w-full lg:w-4/12 px-4 lg:order-3 lg:text-right lg:self-center">
                <div className="py-6 px-3 mt-32 sm:mt-0">
                    <button className="bg-blue-400 active:bg-blue-600 uppercase text-slate-100 font-bold hover:shadow-md shadow text-xs px-4 py-2 rounded outline-none focus:outline-none sm:mr-2 mb-1 ease-linear transition-all duration-150" type="button">
                        Message
                    </button>
                </div>
            </div>
            <div className="w-full lg:w-4/12 px-4 lg:order-1">
                <div className="flex justify-center py-4 lg:pt-4 pt-8">
                    <div className="mr-4 p-3 text-center">
                        <span className="text-xl font-bold block uppercase tracking-wide text-blueGray-600">{profileData.postCount}</span><span className="text-sm text-blueGray-400">Posts</span>
                    </div>
                    <div className="mr-4 p-3 text-center">
                        <span className="text-xl font-bold block uppercase tracking-wide text-blueGray-600">{profileData.resourceLikes}</span><span className="text-sm text-blueGray-400">Resource Likes</span>
                    </div>
                    <div className="lg:mr-4 p-3 text-center">
                        <span className="text-xl font-bold block uppercase tracking-wide text-blueGray-600">{profileData.commentLikes}</span><span className="text-sm text-blueGray-400">Comments Likes</span>
                    </div>
                </div>
            </div>
        </div>
        <div className="text-center mt-12">
            <img src={profileData.user.profilePictureUrl} className="rounded-full mx-auto max-w-2xl max-h-64" />
            <h3 className="text-4xl font-semibold leading-normal mb-2 text-blueGray-700">
                {profileData.user.userName}
            </h3>
            <div className="text-sm leading-normal mt-0 mb-2 text-blueGray-400 font-bold uppercase">
                <i className="fas fa-map-marker-alt mr-2 text-lg text-blueGray-400"></i>
                {profileData.user.useProfileDescription}
            </div>
            <div className="mb-2 text-blueGray-600 mt-10">
                <i className="fas fa-briefcase mr-2 text-lg text-blueGray-400"></i>{profileData.user.userJob}
            </div>
            <div className="mb-2 text-blueGray-600">
                <i className="fas fa-university mr-2 text-lg text-blueGray-400"></i>{profileData.user.userEducation}
            </div>
        </div>
        <div className="mt-10 py-10 border-t border-blueGray-200 text-center">
            <div className="flex flex-wrap justify-center">
                <div className="w-full lg:w-9/12 px-4">
                    <p className="mb-4 text-lg leading-relaxed text-blueGray-700">
                    {profileData.user.useProfileDescription}
                    </p>
                    <a href="#pablo" className="font-normal text-pink-500">Show more</a>
                </div>
            </div>
        </div>
    </section>
        )
}