import { useLocation, useParams } from "react-router-dom";
import { useEffect } from "react";
import useDetailsStore from "../../../stores/useDetailsStore";
import { FaTimes } from "react-icons/fa";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";





export const Edit = () => {
    const { id } = useParams();
    const location = useLocation();

    const isLoading = useDetailsStore((state) => state.isLoading);
    const resource = useDetailsStore((state) => state.editData);
    const getResource = useDetailsStore((state) => state.getResourceEditData);
    const addCategory = useDetailsStore((state) => state.addCategory);
    const removeCategory = useDetailsStore((state) => state.removeCategory);
    const editResource = useDetailsStore((state) => state.setEditedResource);
    const modifyInputFields = useDetailsStore((state) => state.setEditData);


    useEffect(() => {
        getResource(id);
    }, []);

    const editorConfiguration = {
        toolbar: ['bold', 'italic']
    };

    return (
        <>
            {!isLoading && resource && resource.allAvailableCategories && (
                <div className="flex flex-col justify-center w-10/12 pl-64 my-12">
                    <div className="border divide-y text-bgBlackUI-0 p-1 shadow-sm">

                        <label htmlFor="title" className="block text-sm font-medium mb-2 ">
                            Title
                        </label>
                        <input
                            type="text"
                            id="title-input"
                            name="title"
                            className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm"
                            placeholder="Title"
                            value={resource.title}
                            onChange={(e) => modifyInputFields({ [e.target.name]: e.target.value })}
                        />
                    </div>

                    <div className="border divide-y my-6 shadow-sm p-2">

                        <label htmlFor="image-input" className="block text-sm font-medium mb-2 ">
                            Image URL
                        </label>
                        <input
                            type="text"
                            id="image-input"
                            name="imageUrl"
                            className="py-3 px-4 block w-full border-gray-200 rounded-md text-sm"
                            placeholder="Image URL"
                            value={resource.imageUrl}
                            onChange={(e) => modifyInputFields({ [e.target.name]: e.target.value })}
                        />
                    </div>

                    <div className="divide-y border shadow-sm p-2">

                        <label htmlFor="content-input" className="block text-sm font-medium mb-2">
                            Content
                        </label>
                        <CKEditor
                            editor={ClassicEditor}
                            id="content"
                            data={resource.content}
                            config={editorConfiguration}
                            onChange={(_, editor) => {
                                const newContent = editor.getData();
                                modifyInputFields({ content: newContent });
                            }}
                        />
                    </div>
                    <div className="my-4">
                        <label className="block mb-2 text-lg font-medium">
                            Select an option
                        </label>
                        <div>
                            <div>
                                {resource.chosenCategories.map((ctg) => (
                                    <span
                                        onClick={(event) => {
                                            event.preventDefault();
                                            removeCategory(ctg.name);
                                        }}
                                        key={ctg.name}
                                        className="mr-2">
                                        {ctg.name}
                                        <button>
                                            <FaTimes />
                                        </button>
                                    </span>
                                ))}
                            </div>
                        </div>
                        <select
                            className="mt-4 block w-64 p-2 border rounded"
                            onChange={(event) => {console.log(event.target.validationMessage);addCategory(event.target.value)}}
                        >
                            {resource.allAvailableCategories.map((ctg) => (
                                <option
                                    key={ctg.id}
                                    className={`${resource.chosenCategories.some((chosenCtg) => chosenCtg.name === ctg.name)
                                        ? 'text-pinkUI-0 font-semibold'
                                        : 'font-bold'
                                        }`}                                >
                                    {ctg.name}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="bg-pinkUI-0 w-20 rounded text-center p-1">
                        <button type="button"
                            onClick={() => editResource(id, resource)}
                            className="rounded">
                            Change
                        </button>
                    </div>
                </div>
            )}
        </>
    )
}

