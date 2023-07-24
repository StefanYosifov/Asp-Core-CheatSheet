
export const getUserData=()=>{
    return (localStorage.getItem('Authorization'));
}

export const setUserData=(data)=>{
    const token='Bearer '+data;
    return localStorage.setItem('Authorization',token);
}

export const setUserStorage=(key,data)=>{
    return localStorage.setItem(key,data);
}

export const clearUserData= ()=>{
    return  localStorage.removeItem('Authorization');
}

export const clearUserToken=()=>{
    return localStorage.removeItem(`user-storage`);
}
