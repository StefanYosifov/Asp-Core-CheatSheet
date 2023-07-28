import { useLocation, useParams } from "react-router-dom"
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
        toolbar: [ 'bold', 'italic']
    };

    console.log(resource);
    return (
        <>
            {!isLoading && resource && resource.allAvailableCategories && (
                <div className="flex flex-col justify-center w-10/12">
                    <div className="border divide-y">

                    <label htmlFor="title" className="block text-sm font-medium mb-2 text-slate-700">
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

                    <label htmlFor="image-input" className="block text-sm font-medium mb-2 text-slate-700">
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
                    <label htmlFor="content-input" className="block text-sm font-medium mb-2 text-slate-700">
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
                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-400">
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
                                >
                                    {ctg.name}
                                    <button>
                                        <FaTimes />
                                    </button>
                                </span>
                            ))}
                        </div>
                        <select
                            className="mt-4 block w-64 p-2 border border-gray-300 rounded"
                            onChange={(event) => addCategory(event.target.value)}
                        >
                            {resource.allAvailableCategories.map((ctg) => (
                                <option key={ctg.name}>{ctg.name}</option>
                            ))}
                        </select>
                    </div>

                    <div className="bg-red-400">
                        <button type="button" onClick={() => editResource(id, resource)}>
                            Change
                        </button>
                    </div>
                </div>
            )}
        </>
    )
}

