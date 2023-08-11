export const CategoryItem = ({ categories, updateState = null, selectedCategories }) => {
    return (
        <>
            {
                categories.map((category, index) =>
                    updateState === null ? (
                        <span
                            key={index}
                            className="inline-block bg-bgWhiteUI-0 text-center rounded-full px-3 py-1 text-sm font-semibold text-bgBlackUI-0 mr-2"
                        >
                            {category}
                        </span>
                    ) : (
                        <button
                            onClick={(event) => {
                                event.preventDefault();
                                updateState && updateState(selectedCategories,category);
                            }}
                            className="font-semibold  text-center mr-1 mb-2 w-18"
                            key={index}>
                            <span className="bg-bgWhiteUI-0 px-3 py-1 rounded-2xl text-sm font-semibold text-bgBlackUI-0 mr-2 border border-pinkUI-0 ml-2">
                                {category}
                            </span>
                        </button>
                    )
                )
            }
        </>
    )
}
