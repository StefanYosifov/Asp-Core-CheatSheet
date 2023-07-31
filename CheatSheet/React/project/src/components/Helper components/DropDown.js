export const DropDown = ({ categories, selectedCategory, setState }) => {

    console.log(categories);

    return (
        <div className="w-72 m-2">
            {categories &&
                <select
                    className="inline-flex hover:bg-gray-50inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
                    label="Select Version"
                    animate={{
                        mount: { y: 0 },
                        unmount: { y: 25 },
                    }}
                    value={selectedCategory}
                    onChange={(event) => { setState(event.target.value) }}
                >
                    {Object.values(categories).map((ctg, index) => {
                        if (typeof ctg === "string") {
                            return (
                                <option
                                    key={index}
                                    value={ctg}
                                >
                                    {ctg}
                                </option>
                            );
                        } else {
                            return (
                                <option
                                    key={ctg.id}
                                    value={ctg.name}
                                >
                                    {ctg.name}
                                </option>
                            );
                        }
                    })}

                </select>
            }
        </div>
    )
}
