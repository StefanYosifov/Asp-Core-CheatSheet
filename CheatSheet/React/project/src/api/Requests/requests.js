import { getUserData, setUserData } from "../util"
import axios from "axios";
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

const baseUrl='https://localhost:7273';


const headers={
    'Authorization' : getUserData(),
    'Content-type' : 'application/json'
};

export const get=(endPoint)=>{
  return axios.get(`${baseUrl}/${endPoint}`, { headers });
}

export const postWithoutNotification=(endPoint,data)=>{
  return axios.post(`${baseUrl}/${endPoint}`, data, { headers });
}

export const post = (endPoint, data) => {
  console.log(data);
  return axios.post(`${baseUrl}/${endPoint}`, data, { headers }).then((res)=>{
    if(res.status>=200 && res.status<=204){
      toast.success(res.data);
    }
  }).catch((error) => {
    toast.error(error.response.data);
  });
};

export const patch=(endPoint,data)=>{
  console.log(data);
  return axios.patch(`${baseUrl}/${endPoint}`,data,{headers});
}

export const del = (endPoint) => {
  return axios.delete(`${baseUrl}/${endPoint}`, { headers });
}
