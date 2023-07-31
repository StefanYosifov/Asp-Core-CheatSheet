import { useEffect, useRef } from "react";
import useAdminStore from "../../../stores/useAdminStore";
import { DropDown } from "../../Helper components/DropDown";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import SearchBar from "../../Helper components/SearchBar";
import { useSetQueryParams } from "../../../common/useSetQueryParams";

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


    useEffect(() => {
        setCategories();
        setDropDownListOfCourses(location.search)
    }, [location]);

    const queryData = ({
        search: search,
        courseFilters: selectedFilter,
        categoryName: selectedCategory,
    });

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


    const dropdownRef = useRef(null);

    useEffect(() => {
        const handleEvent = (event) => {
            if (dropdownRef.current && dropdownRef.current.contains(event.target)) {
                console.log(event.target.value);
            }
        };
        document.addEventListener('change', handleEvent);
        return () => {
            document.removeEventListener('change', handleEvent);
        };
    }, []);

    console.log(categories);
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
                        <div onClick={(event) => console.log(event.target)}>
                            <DropDown categories={filters} selectedCategory={selectedFilter} setState={setSelectedFilter} />
                        </div>
                        <button onClick={() => setQueryParameters(queryData)}>CLICK MEEEE</button>
                    </>}
            </div >
            <div>
                {courseNameDropDownList &&
                    <>
                        <DropDown ref={dropdownRef} categories={courseNameDropDownList} selectedCategory={selectedCourseName} setState={setSelectedCourseName} />
                    </>}
            </div>
        </>
    )
}