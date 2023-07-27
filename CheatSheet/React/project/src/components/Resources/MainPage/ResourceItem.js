import { Link, useFetcher, useNavigate } from "react-router-dom";
import { CategoryItem } from "../../Helper components/CategoryItem";
import { FaHeart } from 'react-icons/fa';
import { useEffect } from "react";
import { URLS } from "../../../constants/URLConstants";
import useResourceListStore from "../../../stores/useResourceListStore";
const parse = require('html-react-parser');



export const ResourceItem = () => {
  const navigate = useNavigate();

  const resources = useResourceListStore((state) => state.data);
  const isLoading = useResourceListStore((state) => state.isLoading)

  console.log(resources);
  console.log(isLoading);

  useEffect(() => {
    console.log('resources have mounted:', resources);
  }, [resources]);

  function navigationHandle(event) {
    event.preventDefault();
    navigate(`${URLS.RESOURCES_DETAILS}${resources.id}`)
  }

  return (
    <>
      {!isLoading && resources && 
        <>
          {(resources.map((resource) =>
            <div key={resource.id} className="max-w-lg my-4 bg-white rounded-lg shadow-md hover:shadow-2xl flex flex-col h-full">
              <div className="flex justify-between items-center bg-gray-700 py-2">
                <span className="text-sm font-light text-gray-50 px-4">Date: {resource.dateTime}</span>
                <div className="flex items-end">
                  <span className="text-sm font-light text-gray-50 mr-8 overflow-hidden" >Total likes: {resource.totalLikes}</span>
                </div>
              </div>
              <div className="relative h-64 sm:h-80 border-b border-gray-100">
                <img className="w-full h-full object-cover" src={resource.imageUrl} alt="resourceImage" />
              </div>
              <div className="p-4">
                <h1 className="text-3xl text-gray-700 font-bold hover:text-gray-700 my-2 overflow-hidden">{resource.title}</h1>
                <div className="text-gray-700 text-base max-h-36 overflow-hidden">{(resource.content.length > 100
                  ? parse(String(resource.content).substring(0, 100) + "...")
                  : parse(resource.content))}</div>
              </div>
                <Link to={`${URLS.RESOURCES_DETAILS}${resource.id}`} className="text-blue-600 hover:underline mt-4 cursor-pointer p-4">
                  Read more
                </Link>
              <div className="flex items-center justify-between p-4 mt-auto">
                <div className="flex items-center">
                  <FaHeart size={32} color="red" className="mr-2" />
                  <CategoryItem categories={resource.categoryNames}/>
                </div>
                <div className="flex items-center">
                  <img className="mx-4 w-10 h-10 object-cover rounded-full hidden sm:block" src={resource.userProfileImage} alt="avatar" />
                  <h1 className="text-gray-700 font-bold">{resource.userName}</h1>
                </div>
              </div>
            </div>
          ))}
        </>}
    </>

  )
}

export default ResourceItem;