import { useEffect, useState } from "react";
import { addResource } from "../../../api/Requests/resources";
import { getCategories } from "../../../api/Requests/categories";
import { useNavigate } from "react-router-dom";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";


export const ResourceAdd = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        "title": "",
        "imageUrl": "",
        "content": "",
        "categoryIds": []
    });


    const [categories, setCategories] = useState([]);
    const [categoryDictionary, setCategoryDictionary] = useState({});

    useEffect(() => {
        getCategories()
            .then((response) => {
                const categoriesData = response.data.categories;
                setCategories(categoriesData);
                const dictionary = {};
                categoriesData.forEach((category) => {
                    dictionary[category.id] = category.name;
                });
                setCategoryDictionary(dictionary);
            });
    }, []);

    const handleCategoryChange = (event) => {
        const { value } = event.target;
        const isChecked = event.target.checked;

        setFormData(prevState => {
            if (isChecked) {
                return {
                    ...prevState,
                    categoryIds: [...prevState.categoryIds, Number(value)],
                };
            } else {
                return {
                    ...prevState,
                    categoryIds: prevState.categoryIds.filter(categoryId => categoryId !== Number(value)),
                };
            }
        });
    };



    const onChange = (event, editor) => {
        if (editor == undefined || editor == null) {

            const { name, value } = event.target;

            setFormData(prevState => ({
                ...prevState,
                [name]: value
            }));
        }
        else {
            const data = editor.getData();
            setFormData((prevState) => ({
                ...prevState,
                content: data,
            }));
        }

        console.log(formData);
    };


    const onSubmit = (event) => {
        console.log(formData);
        event.preventDefault();
        addResource(formData);
        navigate('/resources/1')
    }
    return (
        <>
            <div className=" w-full flex flex-col min-h-screen justify-center items-center">
                <div className="bg-bgWhiteUI-0 w-10/12 h-full border rounded-md shadow-lg flex justify-center py-14">
                    <form onSubmit={onSubmit} className="max-w-md">
                        <div className="mb-4">
                            <label htmlFor="title" className="block text-xl text-bgBlackUI-0 tracking-wide font-semibold my-2">
                                Title
                            </label>
                            <input
                                id="title"
                                name="title"
                                type="text"
                                className="shadow appearance-none border rounded w-full py-2 px-3 text-bgBlackUI-0 leading-tight focus:outline-none focus:shadow-outline"
                                required
                                minLength="3"
                                maxLength="50"
                                onChange={onChange}
                            />
                        </div>
                        <div className="mb-4">
                            <label htmlFor="imageUrl" className="block text-xl text-bgBlackUI-0 tracking-wide font-semibold my-2">
                                Image URL
                            </label>
                            <input
                                id="imageUrl"
                                name="imageUrl"
                                type="text"
                                className="shadow appearance-none border rounded w-full py-2 px-3 text-bgBlackUI-0 leading-tight focus:outline-none focus:shadow-outline"
                                onChange={onChange}
                                required
                            />
                        </div>
                        <div className="mb-4">
                            <label htmlFor="content" className="block text-xl text-bgBlackUI-0 tracking-wide font-semibold my-2">
                                Content
                            </label>
                            <CKEditor
                                editor={ClassicEditor}
                                id="content"
                                data="<p>Write content here!</p>"
                                onChange={(_, editor) => onChange(_, editor)}
                            />
                        </div>
                        <div className="my-4">
                            <span className="block text-bgBlackUI-0 tracking-wide font-semibold font-serif mb-2">Categories:</span>
                            <div className="grid grid-cols-2 gap-4">
                                {categories.map(category => (
                                    <div key={category.id} className="flex items-center">
                                        <input
                                            type="checkbox"
                                            name="categoryResources"
                                            value={category.id}
                                            checked={formData.categoryIds.includes(category.id)}
                                            onChange={handleCategoryChange}
                                            className="mr-2"
                                        />
                                        <label className="text-base text-bgBlackUI-0">{categoryDictionary[category.id]}</label>
                                    </div>
                                ))}
                            </div>
                        </div>
                        <div className="flex items-center justify-between">
                            <button
                                type="submit"
                                className="bg-pinkUI-0 text-bgWhiteUI-0 tracking-wide font-semibold font-serif py-2 px-5 mt-2 rounded focus:outline-none focus:shadow-outline"
                            >
                                Save
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}

export default ResourceAdd;