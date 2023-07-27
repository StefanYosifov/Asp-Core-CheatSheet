import { useEffect, useState } from "react"
import { getMyResource } from "../../api/Requests/resources";
import { ProfileResourcesElements } from "./ProfileResourcesElements";


export const ProfileResouces = () => {

    const [resources, setResources] = useState([]);

    useEffect(() => {
        getMyResource().then((res) => setResources(() => res.data));
    }, []);


    console.log(resources);
    return (
        <table className="w-11/12 text-sm text-left text-gray-500 bg-slate-200 mx-auto">
            <thead className="text-xs  uppercase  text-gray-500 bg-slate-200">
                <tr>
                    <th scope="col" className="px-6 py-3">
                        Name
                    </th>
                    <th scope="col" className="px-6 py-3">
                        Status
                    </th>
                    <th scope="col" className="px-6 py-3">
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
            {Array.from(resources).map(resource =>  <ProfileResourcesElements key={resource.id} resources={resource} />)}
            </tbody>
        </table>
    );
}