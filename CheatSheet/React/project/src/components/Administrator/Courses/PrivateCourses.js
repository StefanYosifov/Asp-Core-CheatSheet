import { useEffect, useRef, useState } from "react";
import useAdminStore from "../../../stores/useAdminStore";
import { DropDown } from "../../Helper components/DropDown";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import SearchBar from "../../Helper components/SearchBar";
import { useSetQueryParams } from "../../../common/useSetQueryParams";
import { Modal } from "../Helper components/Modal";
import useModalStore from "../../../stores/useModalStore";
import useCreateCourseModalStore from "../../../stores/useCreateCourseModalStore";
import { CreateCourseModal } from "../Helper components/CreateCourseModal";

export const PrivateCourses = () => {
    const { id } = useParams;
    const location = useLocation();
    const navigate = useNavigate();

    const categories = useAdminStore((state) => state.categories);
    const setDropDownListOfCourses = useAdminStore((state) => state.setDropDownListOfCourses);

    const courseNameDropDownList = useAdminStore((state) => state.courseNameDropDownList);
    const selectedCourseName = useAdminStore((state) => state.selectedCourseName);
    const setSelectedCourseName = useAdminStore((state) => state.setSelectedCourseName);

    const selectedCategory = useAdminStore((state) => state.selectedCategory);
    const setSelectedCategory = useAdminStore((state) => state.setSelectedCategory);
    const setCategories = useAdminStore((state) => state.setCategories);

    const filters = useAdminStore((state) => state.filters);
    const selectedFilter = useAdminStore((state) => state.selectedFilter);
    const setSelectedFilter = useAdminStore((state) => state.setSelectedFilter);

    const search = useAdminStore((state) => state.searchInput);
    const setSearch = useAdminStore((state) => state.setSearchInput);

    const topics = useAdminStore((state) => state.topics);
    const setTopics = useAdminStore((state) => state.setTopics);

    useEffect(() => {
        setCategories();
        setDropDownListOfCourses(location.search)
    }, [location]);

    const queryData = ({
        search: search,
        courseFilters: selectedFilter,
        categoryName: selectedCategory,
    });

    useEffect(() => {
        setTopics(selectedCourseName, courseNameDropDownList);
    }, [selectedCourseName])


    const setQueryParameters = (query) => {
        try {
            if (typeof query !== "object" || query === null) {
                throw new Error("Input 'query' must be a non-null object.");
            }
            const queryParams = new URLSearchParams(location.search);

            Object.entries(query).forEach((currObj) => {
                const [key, value] = currObj;
                if (value || value === "None") {
                    if (Array.isArray(value)) {
                        const properlySplitValue = value.map(item => decodeURI(item)).join(',');
                        queryParams.set(key, properlySplitValue);
                    }
                    else {
                        queryParams.set(key, value);
                    }
                }
                else {
                    queryParams.delete(key);
                }
            })
            navigate(`${location.pathname}?${queryParams.toString()}`);
        } catch (error) {
            console.log(`CAUGHT ERROR ${error}`);
        }
    }

    const Table = ({ topics }) => {
        const isModalOpen = useModalStore((state) => state.isModalOpen);
        const setModalIsOpen = useModalStore((state) => state.setModalIsOpen);

        const isCreateModalOpen=useCreateCourseModalStore((state)=>state.isCreateModalOpen);
        const setIsCreateModalOpen=useCreateCourseModalStore((state)=>state.setIsCreateModalOpen);

        console.log(isCreateModalOpen);

        return (
            <section className="container px-4 mx-auto">
                <div className="sm:flex sm:items-center sm:justify-between">
                    <h2 className="text-lg font-medium text-gray-800 dark:text-white">Files uploaded</h2>

                    <div className="flex items-center mt-4 gap-x-3">
                        <button className="w-1/2 px-5 py-2 text-sm text-gray-800 transition-colors duration-200 bg-white border rounded-lg sm:w-auto dark:hover:bg-gray-800 dark:bg-gray-900 hover:bg-gray-100 dark:text-white dark:border-gray-700">
                            Create a course
                        </button>

                        <button 
                        onClick={()=>{console.log(`CLICKING`);setIsCreateModalOpen()}}
                        className="flex items-center justify-center w-1/2 px-5 py-2 text-sm tracking-wide text-white transition-colors duration-200 bg-blue-500 rounded-lg sm:w-auto gap-x-2 hover:bg-blue-600 dark:hover:bg-blue-500 dark:bg-blue-600">
                            <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <g clip-path="url(#clip0_3098_154395)">
                                    <path d="M13.3333 13.3332L9.99997 9.9999M9.99997 9.9999L6.66663 13.3332M9.99997 9.9999V17.4999M16.9916 15.3249C17.8044 14.8818 18.4465 14.1806 18.8165 13.3321C19.1866 12.4835 19.2635 11.5359 19.0351 10.6388C18.8068 9.7417 18.2862 8.94616 17.5555 8.37778C16.8248 7.80939 15.9257 7.50052 15 7.4999H13.95C13.6977 6.52427 13.2276 5.61852 12.5749 4.85073C11.9222 4.08295 11.104 3.47311 10.1817 3.06708C9.25943 2.66104 8.25709 2.46937 7.25006 2.50647C6.24304 2.54358 5.25752 2.80849 4.36761 3.28129C3.47771 3.7541 2.70656 4.42249 2.11215 5.23622C1.51774 6.04996 1.11554 6.98785 0.935783 7.9794C0.756025 8.97095 0.803388 9.99035 1.07431 10.961C1.34523 11.9316 1.83267 12.8281 2.49997 13.5832" stroke="currentColor" stroke-width="1.67" stroke-linecap="round" stroke-linejoin="round" />
                                </g>
                                <defs>
                                    <clipPath id="clip0_3098_154395">
                                        <rect width="20" height="20" fill="white" />
                                    </clipPath>
                                </defs>
                            </svg>

                            <span>Upload</span>
                        </button>
                    </div>
                </div>

                <div className="flex flex-col mt-6">
                    <div className="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                        <div className="inline-block min-w-full py-2 align-middle md:px-6 lg:px-8">
                            <div className="overflow-hidden border border-gray-200 dark:border-gray-700 md:rounded-lg">
                                <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
                                    <thead className="bg-gray-50 dark:bg-gray-800">
                                        <tr>
                                            <th scope="col" className="py-3.5 px-4 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                <div className="flex items-center gap-x-3">
                                                    <span>Topic Id</span>
                                                </div>
                                            </th>

                                            <th scope="col" className="px-12 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Topic name
                                            </th>

                                            <th scope="col" className="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Video URL
                                            </th>

                                            <th scope="col" className="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Video name
                                            </th>
                                            <th scope="col" className="relative py-3.5 px-4">
                                                <span className="sr-only">Edit</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody className="bg-white divide-y divide-gray-200 dark:divide-gray-700 dark:bg-gray-900">
                                        {topics && topics.map((topic) => (
                                            <tr key={topic.topicId}>
                                                <td className="px-4 py-4 text-sm font-medium text-gray-700 whitespace-nowrap">
                                                    <div className="inline-flex items-center gap-x-3">
                                                        <div className="flex items-center gap-x-2">
                                                            <div>
                                                                <h2 className="font-normal text-gray-800 dark:text-white">{topic.topicId}</h2>
                                                                <p className="text-xs font-normal text-gray-500 dark:text-gray-400">{topic.topicName}</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td className="px-12 py-4 text-sm font-normal text-gray-700 whitespace-nowrap">
                                                    {topic.topicName}
                                                </td>
                                                <td className="px-4 py-4 text-sm text-pinkUI-0 whitespace-nowrap">{topic.videoName}</td>
                                                <td className="px-4 py-4 text-sm text-gray-500 dark:text-gray-300 whitespace-nowrap">{topic.videoUrl}</td>
                                                <td className="px-4 py-4 text-sm whitespace-nowrap">
                                                    <button className="px-1 py-1 text-gray-500 transition-colors duration-200 rounded-lg dark:text-gray-300 hover:bg-gray-100"
                                                        onClick={() => setModalIsOpen()}>
                                                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M12 6.75a.75.75 0 110-1.5.75.75 0 010 1.5zM12 12.75a.75.75 0 110-1.5.75.75 0 010 1.5zM12 18.75a.75.75 0 110-1.5.75.75 0 010 1.5z" />
                                                        </svg>
                                                    </button>
                                                </td>
                                                {isModalOpen && <Modal topicId={topic.topicId} />}
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                                        {isCreateModalOpen && <CreateCourseModal/>}
                            </div>
                        </div>
                    </div>
                </div>

            </section>
        )
    }


    useEffect(() => {

    }, [selectedCourseName]);

    return (
        <>
            <div className="flex flex-row pl-8">
                {categories &&
                    <>
                        <SearchBar input={search} setInput={setSearch} />
                        <DropDown categories={categories} selectedCategory={selectedCategory} setState={setSelectedCategory} />
                        <div>
                            <DropDown categories={filters} selectedCategory={selectedFilter} setState={setSelectedFilter} />
                        </div>
                        <button className="flex items-center rounded bg-pinkUI-0 h-10" onClick={() => setQueryParameters(queryData)}>
                            <svg className="w-5 h-5 mx-2 fill-current" xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 512 512" space="preserve">
                                <g>
                                    <g>
                                        <path d="M407,0H105C47.103,0,0,47.103,0,105v302c0,57.897,47.103,105,105,105h302c57.897,0,105-47.103,105-105V105C512,47.103,464.897,0,407,0z M482,407c0,41.355-33.645,75-75,75H105c-41.355,0-75-33.645-75-75V105c0-41.355,33.645-75,75-75h302c41.355,0,75,33.645,75,75V407z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M305.646,123.531c-1.729-6.45-5.865-11.842-11.648-15.18c-11.936-6.892-27.256-2.789-34.15,9.151L256,124.166l-3.848-6.665c-6.893-11.937-22.212-16.042-34.15-9.151h-0.001c-11.938,6.893-16.042,22.212-9.15,34.151l18.281,31.664L159.678,291H110.5c-13.785,0-25,11.215-25,25c0,13.785,11.215,25,25,25h189.86l-28.868-50h-54.079l85.735-148.498C306.487,136.719,307.375,129.981,305.646,123.531z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M401.5,291h-49.178l-55.907-96.834l-28.867,50l86.804,150.348c3.339,5.784,8.729,9.921,15.181,11.65c2.154,0.577,4.339,0.863,6.511,0.863c4.332,0,8.608-1.136,12.461-3.361c11.938-6.893,16.042-22.213,9.149-34.15L381.189,341H401.5c13.785,0,25-11.215,25-25C426.5,302.215,415.285,291,401.5,291z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M119.264,361l-4.917,8.516c-6.892,11.938-2.787,27.258,9.151,34.15c3.927,2.267,8.219,3.345,12.458,3.344c8.646,0,17.067-4.484,21.693-12.495L176.999,361H119.264z"></path>
                                    </g>
                                </g>
                            </svg>
                            <span className="mx-2">
                                Click to search
                            </span>
                        </button>
                    </>}
            </div >
            <div>
                {courseNameDropDownList &&
                    <>
                        {selectedCourseName}
                        <DropDown categories={courseNameDropDownList} selectedCategory={selectedCourseName} setState={setSelectedCourseName} />
                    </>}

                <Table topics={topics} />
            </div>
        </>
    )
}