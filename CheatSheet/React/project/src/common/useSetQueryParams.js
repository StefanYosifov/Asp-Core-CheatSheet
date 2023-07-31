import { useEffect } from "react";

export const useSetQueryParams = (query, navigate, location) => {
    const queryParams = new URLSearchParams(location.search);
    console.log(query);
    useEffect(() => {
        Object.entries(query).forEach((currObj) => {
            const [key, value] = currObj;
            console.log(key);
            console.log(value);
            if (value.length > 0 || value === "None") {
                if (Array.isArray(value)) {
                    const properlySplitValue = value.map(item => decodeURI(item)).join(',');
                    queryParams.set(key, properlySplitValue);
                }
                else {
                    queryParams.set(key, value);
                }
            }
            else {
                queryParams.delete(key);
            }
        })
        navigate(`${location.pathname}?${queryParams.toString()}`);
    },[])

}