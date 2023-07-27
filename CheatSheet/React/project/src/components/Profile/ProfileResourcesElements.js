import { NavLink, useNavigate } from "react-router-dom";


export const ProfileResourcesElements = ({ resources }) => {
    const navigate = useNavigate();
    const handleClick = () => navigate(`/details/${resources.id}`);

    console.log();
    return (
        <>
            <tr className=" border-b  text-gray-700 bg-slate-200 ">
                <th scope="row" className="flex items-center px-6 py-4 text-gray-900 whitespace-nowrap dark:text-white">
                    <img className="w-10 h-10 rounded-full" src={resources.imageUrl} alt="Resource image" />
                    <div className="pl-3">
                        <div className="text-base text-gray-700">{resources.userName}</div>
                    </div>
                </th>
                <td className="px-6 py-4">
                    {resources.title}
                </td>
                <td className="px-6 py-4">
                    <div className="flex items-end">
                        <button className="bg-blue-500 text-slate-100 p-2 rounded-sm"
                        onClick={handleClick}>
                             Go to resource
                        </button>
                    </div>
                </td>
            </tr>
        </>
    )
}
