import { useEffect, useRef, useState } from "react";
import useAdminStore from "../../../stores/useAdminStore";
import { DropDown } from "../../Helper components/DropDown";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import SearchBar from "../../Helper components/SearchBar";
import { useSetQueryParams } from "../../../common/useSetQueryParams";
import { Modal } from "../Helper components/Modal";
import useModalStore from "../../../stores/useModalStore";

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
        const isModalOpen=useModalStore((state)=>state.isModalOpen);
        const setModalIsOpen=useModalStore((state)=>state.setModalIsOpen);

        return (
            <section class="container px-4 mx-auto">
                <div class="sm:flex sm:items-center sm:justify-between">
                    <h2 class="text-lg font-medium text-gray-800 dark:text-white">Files uploaded</h2>

                    <div class="flex items-center mt-4 gap-x-3">
                        <button class="w-1/2 px-5 py-2 text-sm text-gray-800 transition-colors duration-200 bg-white border rounded-lg sm:w-auto dark:hover:bg-gray-800 dark:bg-gray-900 hover:bg-gray-100 dark:text-white dark:border-gray-700">
                            Download all
                        </button>

                        <button class="flex items-center justify-center w-1/2 px-5 py-2 text-sm tracking-wide text-white transition-colors duration-200 bg-blue-500 rounded-lg sm:w-auto gap-x-2 hover:bg-blue-600 dark:hover:bg-blue-500 dark:bg-blue-600">
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

                <div class="flex flex-col mt-6">
                    <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                        <div class="inline-block min-w-full py-2 align-middle md:px-6 lg:px-8">
                            <div class="overflow-hidden border border-gray-200 dark:border-gray-700 md:rounded-lg">
                                <table class="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
                                    <thead class="bg-gray-50 dark:bg-gray-800">
                                        <tr>
                                            <th scope="col" class="py-3.5 px-4 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                <div class="flex items-center gap-x-3">
                                                    <span>Topic Id</span>
                                                </div>
                                            </th>

                                            <th scope="col" class="px-12 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Topic name
                                            </th>

                                            <th scope="col" class="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Video URL
                                            </th>

                                            <th scope="col" class="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-gray-500 dark:text-gray-400">
                                                Video name
                                            </th>
                                            <th scope="col" class="relative py-3.5 px-4">
                                                <span class="sr-only">Edit</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody class="bg-white divide-y divide-gray-200 dark:divide-gray-700 dark:bg-gray-900">
                                        {topics && topics.map((topic) => (
                                            <tr key={topic.topicId}>
                                                <td class="px-4 py-4 text-sm font-medium text-gray-700 whitespace-nowrap">
                                                    <div class="inline-flex items-center gap-x-3">
                                                        <div class="flex items-center gap-x-2">
                                                            <div>
                                                                <h2 class="font-normal text-gray-800 dark:text-white">{topic.topicId}</h2>
                                                                <p class="text-xs font-normal text-gray-500 dark:text-gray-400">{topic.topicName}</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="px-12 py-4 text-sm font-normal text-gray-700 whitespace-nowrap">
                                                    {topic.topicName}
                                                </td>
                                                <td class="px-4 py-4 text-sm text-pinkUI-0 whitespace-nowrap">{topic.videoName}</td>
                                                <td class="px-4 py-4 text-sm text-gray-500 dark:text-gray-300 whitespace-nowrap">{topic.videoUrl}</td>
                                                <td class="px-4 py-4 text-sm text-gray-500 dark:text-gray-300 whitespace-nowrap"></td>
                                                <td class="px-4 py-4 text-sm whitespace-nowrap">
                                                    <button class="px-1 py-1 text-gray-500 transition-colors duration-200 rounded-lg dark:text-gray-300 hover:bg-gray-100"
                                                    onClick={()=>setModalIsOpen()}>
                                                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M12 6.75a.75.75 0 110-1.5.75.75 0 010 1.5zM12 12.75a.75.75 0 110-1.5.75.75 0 010 1.5zM12 18.75a.75.75 0 110-1.5.75.75 0 010 1.5z" />
                                                        </svg>
                                                    </button>
                                                </td>
                                                {isModalOpen && <Modal topicId={topic.topicId}/>}
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="flex items-center justify-between mt-6">
                    <a href="#" class="flex items-center px-5 py-2 text-sm text-gray-700 capitalize transition-colors duration-200 bg-white border rounded-md gap-x-2 hover:bg-gray-100 dark:bg-gray-900 dark:text-gray-200 dark:border-gray-700 dark:hover:bg-gray-800">
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-5 h-5 rtl:-scale-x-100">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M6.75 15.75L3 12m0 0l3.75-3.75M3 12h18" />
                        </svg>

                        <span>
                            previous
                        </span>
                    </a>

                    <div class="items-center hidden md:flex gap-x-3">
                        <a href="#" class="px-2 py-1 text-sm text-blue-500 rounded-md dark:bg-gray-800 bg-blue-100/60">1</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">2</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">3</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">...</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">12</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">13</a>
                        <a href="#" class="px-2 py-1 text-sm text-gray-500 rounded-md dark:hover:bg-gray-800 dark:text-gray-300 hover:bg-gray-100">14</a>
                    </div>

                    <a href="#" class="flex items-center px-5 py-2 text-sm text-gray-700 capitalize transition-colors duration-200 bg-white border rounded-md gap-x-2 hover:bg-gray-100 dark:bg-gray-900 dark:text-gray-200 dark:border-gray-700 dark:hover:bg-gray-800">
                        <span>
                            Next
                        </span>

                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-5 h-5 rtl:-scale-x-100">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M17.25 8.25L21 12m0 0l-3.75 3.75M21 12H3" />
                        </svg>
                    </a>
                </div>
            </section>
        )
    }


    useEffect(() => {

    }, [selectedCourseName]);

    return (
        <>
            <h1>AAAAAAAAAAAAA</h1>
            <div className="flex flex-row pl-8">
                {categories &&
                    <>
                        <SearchBar input={search} setInput={setSearch} />
                        <p>ASD{selectedCategory}----{selectedFilter}</p>
                        <DropDown categories={categories} selectedCategory={selectedCategory} setState={setSelectedCategory} />
                        <h1>AAA</h1>
                        <div>
                            <DropDown categories={filters} selectedCategory={selectedFilter} setState={setSelectedFilter} />
                        </div>
                        <button onClick={() => setQueryParameters(queryData)}>CLICK MEEEE</button>
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