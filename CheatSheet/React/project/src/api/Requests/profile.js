import {get,patch,post} from '../Requests/requests'

const path='profile/';

export const getProfileData=(userId)=>{
    return get(`${path}${userId}`).then((res)=>res.data);
}

export const getUserId=()=>{
    return get(`${path}myUser`)
}

export const updateProfile=(profileData)=>{
    return patch(`${path}update`,profileData);
}