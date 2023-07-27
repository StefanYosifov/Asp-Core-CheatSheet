import { useLocation, useParams } from "react-router-dom"
import { useEffect } from "react";
import useDetailsStore from "../../../stores/useDetailsStore";
import { FaTimes } from "react-icons/fa";



export const Edit = () => {
    const { id } = useParams();
    const location = useLocation();

    const isLoading = useDetailsStore((state) => state.isLoading);
    const resource = useDetailsStore((state) => state.editData);
    const getResource = useDetailsStore((state) => state.getResourceEditData);
    const addCategory = useDetailsStore((state) => state.addCategory);
    const removeCategory = useDetailsStore((state) => state.removeCategory);

    useEffect(() => {
        getResource(id);
    }, []);


    const RenderCategories = (categories) => {

    }


    console.log(resource);
    return (
        <>
            {!isLoading && resource && resource.allAvaialbleCategories &&
                <>
                    <label htmlFor="input-label" className="block text-sm font-medium mb-2 dark:text-white">Email</label>
                    <input type="email" id="input-label" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm " placeholder="you@site.com" />

                    <label htmlFor="input-label" className="block text-sm font-medium mb-2 dark:text-white">Email</label>
                    <input type="email" id="input-label" className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm " placeholder="you@site.com" />


                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-400">Select an option</label>
                    <div>
                        <div>
                            {resource.chosenCategories.map((ctg) => (
                                <span
                                    onClick={(event) => { event.preventDefault(); removeCategory(ctg.name) }}
                                    key={ctg.name}>
                                    {ctg.name}
                                    <button>
                                        <FaTimes />
                                    </button>
                                </span>
                            ))}
                        </div>
                        <select className="mt-4 block w-64 p-2 border border-gray-300 rounded"
                            onChange={(event) => addCategory(event.target.value)}>
                            {resource.allAvaialbleCategories.map((ctg) =>
                                <option key={ctg.name}>{ctg.name}</option>
                            )}
                        </select>
                    </div>
                </>
            }
        </>
    )
}

