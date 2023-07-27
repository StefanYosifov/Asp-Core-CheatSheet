import {get,post} from '../Requests/requests'

export const getDetails=(id)=>{
    return get(`resource/details/${id}`);
}

