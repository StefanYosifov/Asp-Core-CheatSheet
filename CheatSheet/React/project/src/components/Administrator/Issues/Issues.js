import { useEffect, useState } from "react";
import useAdminIssueStore from "../../../stores/useAdminIssueStore";
import { useLocation, useNavigate } from "react-router-dom";
import { Pagination } from "../../Helper components/Pagination";
import { DropDown } from "../../Helper components/DropDown";



export const Issues = () => {
    const navigate=useNavigate();
    const location = useLocation();

    const [page, setPage] = useState(1);
    const [selectedCourseName, setSelectedCourseName] = useState('');
    const [selectedSort, setSelectedSort] = useState('');

    const { isLoading, issues, search, filteringCategories } = useAdminIssueStore();
    const setIssues = useAdminIssueStore((state) => state.setIssues);
    const setFilteringCategories = useAdminIssueStore((state) => state.setFilteringCategories);
    const resolveIssue=useAdminIssueStore((state)=>state.resolveIssue);

    
    console.log(issues);


    useEffect(() => {
        setIssues(queryData);
        setFilteringCategories();
    }, [page,location]);

    const queryData = ({
        search: search,
        pageNumber: page,
        selectedCourseName: selectedCourseName,
        Sorting: selectedSort,
    });


    const setQueryParameters = (query) => {
        const queryParams = new URLSearchParams(location.search);

        Object.entries(query).forEach((currObj) => {
            const [key, value] = currObj;
            console.log(key);
            if (value.length > 0 || value === "None") {
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
    }


    const Table = () => {
        return (
            <section className="container px-4 mx-auto">
                <div className="flex flex-col mt-6">
                    <div className="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                        <div className="inline-block min-w-full py-2 align-middle md:px-6 lg:px-8">
                            <div className="overflow-hidden border border-gray-200 dark:border-gray-700 md:rounded-lg">
                                <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
                                    <thead className="bg-gray-50 dark:bg-gray-800">
                                        <tr>
                                            <th scope="col" className="py-3.5 px-4 text-sm font-normal text-left rtl:text-right text-bgBlackUI-0 dark:text-gray-400">
                                                <div className="flex items-center gap-x-3">
                                                    <span>Title</span>
                                                </div>
                                            </th>

                                            <th scope="col" className="px-12 py-3.5 text-sm font-normal text-left rtl:text-right text-bgBlackUI-0 dark:text-gray-400">
                                                <button className="flex items-center gap-x-2">
                                                    <span>Topic Name</span>

                                                    <svg className="h-3" viewBox="0 0 10 11" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                        <path d="M2.13347 0.0999756H2.98516L5.01902 4.79058H3.86226L3.45549 3.79907H1.63772L1.24366 4.79058H0.0996094L2.13347 0.0999756ZM2.54025 1.46012L1.96822 2.92196H3.11227L2.54025 1.46012Z" fill="currentColor" stroke="currentColor" stroke-width="0.1" />
                                                        <path d="M0.722656 9.60832L3.09974 6.78633H0.811638V5.87109H4.35819V6.78633L2.01925 9.60832H4.43446V10.5617H0.722656V9.60832Z" fill="currentColor" stroke="currentColor" stroke-width="0.1" />
                                                        <path d="M8.45558 7.25664V7.40664H8.60558H9.66065C9.72481 7.40664 9.74667 7.42274 9.75141 7.42691C9.75148 7.42808 9.75146 7.42993 9.75116 7.43262C9.75001 7.44265 9.74458 7.46304 9.72525 7.49314C9.72522 7.4932 9.72518 7.49326 9.72514 7.49332L7.86959 10.3529L7.86924 10.3534C7.83227 10.4109 7.79863 10.418 7.78568 10.418C7.77272 10.418 7.73908 10.4109 7.70211 10.3534L7.70177 10.3529L5.84621 7.49332C5.84617 7.49325 5.84612 7.49318 5.84608 7.49311C5.82677 7.46302 5.82135 7.44264 5.8202 7.43262C5.81989 7.42993 5.81987 7.42808 5.81994 7.42691C5.82469 7.42274 5.84655 7.40664 5.91071 7.40664H6.96578H7.11578V7.25664V0.633865C7.11578 0.42434 7.29014 0.249976 7.49967 0.249976H8.07169C8.28121 0.249976 8.45558 0.42434 8.45558 0.633865V7.25664Z" fill="currentColor" stroke="currentColor" stroke-width="0.3" />
                                                    </svg>
                                                </button>
                                            </th>

                                            <th scope="col" className="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-bgBlackUI-0 dark:text-gray-400">
                                                <button className="flex items-center gap-x-2">
                                                    <span>Location Issue</span>

                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" className="w-4 h-4">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M9.879 7.519c1.171-1.025 3.071-1.025 4.242 0 1.172 1.025 1.172 2.687 0 3.712-.203.179-.43.326-.67.442-.745.361-1.45.999-1.45 1.827v.75M21 12a9 9 0 11-18 0 9 9 0 0118 0zm-9 5.25h.008v.008H12v-.008z" />
                                                    </svg>
                                                </button>
                                            </th>

                                            <th scope="col" className="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-bgBlackUI-0 dark:text-gray-400">Description</th>

                                            <th scope="col" className="px-4 py-3.5 text-sm font-normal text-left rtl:text-right text-bgBlackUI-0 dark:text-gray-400">UserName</th>

                                            <th scope="col" className="relative py-3.5 px-4">
                                                <span className="sr-only">Edit</span>
                                            </th>
                                        </tr>
                                    </thead>

                                </table>
                                <tbody className="bg-white divide-y divide-gray-200 dark:divide-gray-700 dark:bg-gray-900">
                                    {issues && issues.issues && issues.issues.map((issue) => (
                                        <>
                                            <tr key={issue.id}>
                                                <td className="px-4 py-4 text-sm font-medium text-gray-700 whitespace-nowrap">
                                                    <div className="inline-flex items-center gap-x-3">
                                                        <div className="flex items-center gap-x-2">
                                                            <span>{issue.title}</span>
                                                            <div>
                                                                <h2 className="font-medium text-gray-800 dark:text-white">{issue.topicName}</h2>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td className="px-12 py-4 text-sm font-medium text-gray-700 whitespace-nowrap">
                                                    <div className="inline-flex items-center px-3 py-1 rounded-full gap-x-2 bg-emerald-100/60 dark:bg-gray-800">
                                                        <h2 className="text-sm font-normal text-emerald-500">{issue.locationIssue}</h2>
                                                    </div>
                                                </td>
                                                <td className="px-4 py-4 text-sm text-bgBlackUI-0 dark:text-gray-300 whitespace-nowrap">{issue.description}</td>
                                                <td className="px-4 py-4 text-sm text-bgBlackUI-0 dark:text-gray-300 whitespace-nowrap">{issue.userName}</td>
                                                <td className="px-4 py-4 text-sm whitespace-nowrap">
                                                </td>
                                                <td className="px-4 py-4 text-sm whitespace-nowrap">
                                                    <div className="flex items-center gap-x-6">
                                                        <button 
                                                        onClick={(event)=>{event.preventDefault();resolveIssue(issue.id)}}
                                                        className="text-bgBlackUI-0 transition-colors duration-200 dark:hover:text-red-500 dark:text-gray-300 hover:text-red-500 focus:outline-none">
                                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" className="w-5 h-5">
                                                                <path stroke-linecap="round" stroke-linejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
                                                            </svg>
                                                        </button>
                                                    </div>
                                                </td>
                                            </tr>
                                        </>
                                    ))}
                                </tbody>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        )
    }

    return (
        <div>
            {isLoading === false && issues.totalPages && filteringCategories.courses && filteringCategories.issueSorting ? (
                <div>
                    <section>
                        {issues &&
                        <Pagination currentPage={page} totalPages={issues.totalPages} onPageChange={setPage} />
                        }
                        <p>{selectedCourseName}</p>
                        <select
                            onChange={(e) => setSelectedCourseName(e.target.value)}>
                            <option>Choose course</option>
                            {filteringCategories.courses.map((course) => (
                                <option key={course.title} value={course.title}>
                                    {course.title}
                                </option>
                            ))}
                        </select>
                        <DropDown categories={filteringCategories.issueSorting} selectedCategory={selectedSort} setState={setSelectedSort} />
                        <button onClick={(event) => { event.preventDefault(); setQueryParameters(queryData) }}>Search</button>
                        <Table />
                    </section>
                </div>
            ) : (
                <p>Still is loading</p>
            )}
        </div>

    )
}