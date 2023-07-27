export const CategoryItem = ({ categories, updateState = null, selectedCategories }) => {
    return (
        <>
            {
                categories.map((category, index) =>
                    updateState === null ? (
                        <span
                            key={index}
                            className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2"
                        >
                            {category}
                        </span>
                    ) : (

                        <button
                            onClick={(event) => {
                                event.preventDefault();
                                updateState && updateState(selectedCategories,category);
                            }}
                            className="text-white font-semibold rounded-full shadow-md text-center"
                            key={index}>
                            <span className="bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2">
                                {category}
                            </span>
                        </button>
                    )
                )
            }
        </>
    )
}
