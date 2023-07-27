import { useEffect,useState } from "react";

export const useFetch=(method)=>{
    const [data,setData]=useState([]);

    useEffect(()=>{
        method.then((res)=>{
            if(res.status===200){
                setData(()=>res.data);
            }
        })
    },[])
    return [data,setData];
}