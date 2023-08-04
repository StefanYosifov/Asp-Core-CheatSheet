import { useEffect } from "react";
import useResourceListStore from "../../../stores/useResourceListStore";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { Pagination } from "../../Helper components/Pagination";
import ResourceItem from "./ResourceItem";
import { DropDown } from "../../Helper components/DropDown";
import SearchBar from "../../Helper components/SearchBar";
import useDropDownStore from "../../../stores/useDropDownStore";
import { URLS } from "../../../constants/URLConstants";
import { MainPageHero } from "../Static/MainPageHero";


const URL_CHANGE = {
    SEARCH: "search",
    CATEGORY: "category",
    SORT: "sort",
}

const NONE = "None";

export const ResourceList2 = () => {
    const { id } = useParams();
    const location = useLocation();
    const navigate = useNavigate()

    const resources = useResourceListStore((state) => state.data);
    const isLoading = useResourceListStore((state) => state.isLoading)
    const resourcesCouint = useResourceListStore((state) => state.pageCount)
    const setResources = useResourceListStore((state) => state.setResourceList);

    const setCategories = useDropDownStore((state) => state.setCategories);

    const categories = useDropDownStore((state) => state.categories);
    const selectedCategory = useDropDownStore((state) => state.selectedCategory);
    const setSelectedCategory = useDropDownStore((state) => state.onChangeCategory);

    const sorting = useDropDownStore((state) => state.sorting);
    const selectedSort = useDropDownStore((state) => state.selectedSort);
    const setSelectedSort = useDropDownStore((state) => state.onChangeSort);

    const inputSearch = useDropDownStore((state) => state.inputSearch);
    const setInputSearch = useDropDownStore((state) => state.onInputChange);


    const changeURL = () => {
        const queryParams = new URLSearchParams(location.search);
        if (inputSearch.length > 0) {
            queryParams.set(URL_CHANGE.SEARCH, inputSearch);
        } else {
            queryParams.delete(URL_CHANGE.SEARCH);
        }
        if (selectedCategory.length > 0 && selectedCategory !== NONE) {
            queryParams.set(URL_CHANGE.CATEGORY, selectedCategory);
        } else {
            queryParams.delete(URL_CHANGE.CATEGORY);
        }
        if (selectedSort.length > 0 && selectedSort !== NONE) {
            queryParams.set(URL_CHANGE.SORT, selectedSort);
        } else {
            queryParams.delete(URL_CHANGE.SORT);
        }
        navigate(`${location.pathname}?${queryParams.toString()}`);
    }


    useEffect(() => {
        setResources(id, location.search);
        setCategories();
    }, [location])


    return (
        <>

            {!isLoading && resources && setSelectedCategory &&
                <>
                    <MainPageHero />
                    <Pagination
                        currentPage={Number(id)}
                        totalPages={Number(resourcesCouint)}
                        onPageChange={(pageNumber) => navigate(`${URLS.RESOURCES}${pageNumber}`)}
                    />

                    <div className="flex flex-col w-full p-10">
                        <div className="flex justify-self-center items-start">
                            <div>
                                <SearchBar
                                    input={inputSearch}
                                    setInput={setInputSearch} />
                            </div>
                            <DropDown
                                categories={categories}
                                selectedCategory={selectedCategory}
                                setState={setSelectedCategory} />
                            <DropDown categories={sorting}
                                selectedCategory={selectedSort}
                                setState={setSelectedSort} />
                            <button type="button" className="inline-block rounded bg-primary px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-norma bg-blue-600 m-2"
                                onClick={changeURL}
                            >
                                Apply filters
                            </button>
                        </div>
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8 m-10">
                        <ResourceItem />
                    </div>

                    <section className="mb-4">
                        <Pagination
                            currentPage={Number(id)}
                            totalPages={Number(resourcesCouint)}
                            onPageChange={(pageNumber) => navigate(`${URLS.RESOURCES}${pageNumber}`)}
                        />
                    </section>
                </>
            }

        </>
    )
}