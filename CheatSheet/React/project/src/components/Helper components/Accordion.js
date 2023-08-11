import { useState } from "react";
import { BsYoutube } from "react-icons/bs";

export const Accordion = ({ topics }) => {
    const [isActive, setIsActive] = useState(false);

    const topicData = topics.topics;
    { console.log(topicData) }

    return (
        <>
            {topicData && topicData.map((data) => (
                <div key={data.id} className="divide-x divide-y">
                    <div key={data.id} className="w-full bg-bgWhiteUI-0 cursor-pointer flex justify-between" onClick={() => setIsActive(!isActive)}>
                        <div className="px-4 py-4 text-lg">{data.name}</div>
                        <span className="px-4 py-2">{isActive ? '-' : '+'}</span>
                    </div>
                    <div>
                        {isActive && (
                            <div className="accordion-content px-4 py-2">
                                <p className="text-sm py-4">{data.content}</p>
                                {data.resources && data.resources.map((resource) => (
                                    <div key={resource.id} className="flex items-center py-1">
                                        <BsYoutube className="mr-2" />
                                        <span>{resource}</span>
                                    </div>

                                ))}
                            </div>
                        )}
                    </div>
                </div >
            ))}
        </>
    );
};