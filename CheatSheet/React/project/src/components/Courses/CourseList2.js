import { useEffect } from "react";
import useCourseStore from "../../stores/useCourseStore"
import { CourseFeaturedItem } from "./CourseFeaturedItem";
import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import { Link, useLocation, useNavigate, useParams } from "react-router-dom";
import { CategoryItem } from "../Helper components/CategoryItem";
import SearchBar from "../Helper components/SearchBar";
import { RadioButtonList } from "../Helper components/RadioButtonList";
import { URLS } from "../../constants/URLConstants";
import { AiOutlinePlayCircle } from "react-icons/ai"
import { CgSearch } from "react-icons/cg"
import { Pagination } from "../Helper components/Pagination";


const FeaturedCourses = () => {
    const isLoading = useCourseStore((state) => state.isFeaturedLoading);
    const featuredCourses = useCourseStore((state) => state.featuredCourses);
    const setFeaturedCourses = useCourseStore((state) => state.setFeaturedCourses);

    useEffect(() => {
        setFeaturedCourses();
    }, []);

    return (
        <div>
            <div>
                {isLoading ? (
                    <p>Loading...</p>
                ) : featuredCourses === null ? (
                    <p>No featured courses available.</p>
                ) : (
                    <>
                        <div className="my-48">
                            <h1 className="text-3xl ml-44 mb-2">Featured Courses</h1>
                            <Carousel
                                swipeable={false}
                                draggable={false}
                                responsive={responsive}
                                infinite={true}
                                customTransition="all .5"
                                transitionDuration={500}
                                containerClass="carousel-container"
                                removeArrowOnDeviceType={["tablet", "mobile"]}
                                dotListClass="custom-dot-list-style"
                                additionalTransfrom={0}
                                autoPlaySpeed={3000}
                                centerMode={false}
                                focusOnSelect={false}
                                minimumTouchDrag={80}
                                pauseOnHover
                                renderArrowsWhenDisabled={false}
                                renderButtonGroupOutside={false}
                                renderDotsOutside={false}>
                                {featuredCourses.map((course) => (
                                    <CourseFeaturedItem course={course} />
                                ))}
                            </Carousel>
                        </div>
                    </>
                )}
            </div>
        </div>
    );
}

const ALLCourses = () => {
    const { id } = useParams();
    const location = useLocation();
    const navigate = useNavigate();

    const totalPages = useCourseStore((state) => state.totalPages);

    const courses = useCourseStore((state) => state.courses);
    const setCourses = useCourseStore((state) => state.setCourses);

    const inputSearch = useCourseStore((state) => state.searchInput);
    const setInputSearch = useCourseStore((state) => state.setSearchInput);

    const categories = useCourseStore((state) => state.categories);
    const selectedCategories = useCourseStore((state) => state.selectedCategories);
    const setSelectedCategories = useCourseStore((state) => state.setSelectedCategories);
    const setFilteringData = useCourseStore((state) => state.setFilteringData);

    const selectedSort = useCourseStore((state) => state.selectedSort);
    const sortings = useCourseStore((state) => state.sortings);
    const setSelectedSort = useCourseStore((state) => state.setSelectedSort);


    const queryParameters = ({
        search: inputSearch,
        sort: selectedSort,
        categories: selectedCategories,
    });
    const setQueryParameters = (query) => {
        const queryParams = new URLSearchParams(location.search);

        Object.entries(query).forEach((currObj) => {
            const [key, value] = currObj;
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

    useEffect(() => {
        setFilteringData();
        setCourses(id, location.search);
    }, [location]);


    return (
        <div className="mx-28 bg-slate-50 p-1 my-8 shadow-sm">
            <section>
            <button onClick={(event) => { event.preventDefault(); setQueryParameters(queryParameters) }}>
            <CgSearch/> Search
            </button>
            </section>
            <div className="flex">
                <article className="w-1/5 bg-slate-100 h-screen">
                    <section className="p">
                        <form>
                            <div>
                                <SearchBar
                                    input={inputSearch}
                                    setInput={setInputSearch} />
                            </div>
                            <div>
                                <RadioButtonList radioButton={sortings} setRadioButton={setSelectedSort} selectedButton={selectedSort} />
                            </div>
                            {categories != null &&
                                <div>
                                    <CategoryItem categories={categories} updateState={setSelectedCategories} selectedCategories={selectedCategories} />
                                </div>}
                        </form>
                    </section>
                </article>
                <article className="w-4/5 ">
                    <div className="p-8 w-full flex flex-col">
                        {courses.map((course) =>
                            <div className="flex-row flex my-2 divide-y divide-y-reverse " key={course.id}>
                                <section className="w-1/4">
                                    <div className="m-2 w-64 transform overflow-hidden rounded-lg bg-white dark:bg-slate-800 shadow-md duration-300 hover:shadow-lg">
                                        <img className="h-full w-full object-scale-down object-center max-h-40" src={course.imageUrl} alt="Course Thumbnail" />
                                        <section className="bg-slate-800 text-slate-100 font-sans flex flex-col justify-between">
                                            <Link
                                                to={course.hasPaid === true ? `${URLS.COURSES_ID}${course.id}/${decodeURI(course.title)}` : `${URLS.COURSES_OVERVIEW}${course.id}`}>
                                                <div className="p-4 dark:text-white text-gray-900 overflow-hidden hover:cursor-pointer">
                                                    <p className="mb-2 text-lg font-medium overflow-hidden">{course.title}</p>
                                                    <div className="flex justify-between mt-4 overflow-hidden">
                                                        <h1 className="text-2xl tracking-wide font-sans font-semibold  hover:text-orange-400">Watch course</h1>
                                                    </div>
                                                </div>
                                            </Link>
                                        </section>
                                    </div>
                                </section>
                                <section className="w-full px-16 py-2">
                                    <h1 className="text-2xl tracking-wide font-sans font-semibold">{course.title}</h1>
                                    <div className="flex items-center mt-2">
                                        <AiOutlinePlayCircle className="mr-2" />
                                        <span className="text-sm">{course.startDate}</span>
                                    </div>
                                    <p className="mt-4 text-lg font-sans tracking-wide overflow-hidden">{course.description}</p>
                                </section>
                            </div>
                        )}
                    </div>
                    <Pagination
                        currentPage={Number(id)}
                        totalPages={Number(totalPages)}
                        onPageChange={(pageNumber) => navigate(`${URLS.COURSES}${pageNumber}`)}
                    />
                </article>
            </div>
        </div>
    )
}

const responsive = {
    desktop: {
        breakpoint: { max: 3000, min: 1024 },
        items: 4,
    },
    tablet: {
        breakpoint: { max: 1024, min: 464 },
        items: 2,
    },
    mobile: {
        breakpoint: { max: 464, min: 0 },
        items: 1,
    }
}
export const CourseList2 = () => {
    return (
        <>
            <FeaturedCourses></FeaturedCourses>
            <ALLCourses></ALLCourses>
        </>
    )
}