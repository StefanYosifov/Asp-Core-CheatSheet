import { createContext, useState, useEffect, useRef } from "react"


export const UserContext = createContext(null);

export const UserDataProvider = ({ children }) => {
    const [userDetails, setUserDetails] = useState(null);
  
    return (
        <>
            <UserContext.Provider value={[userDetails, setUserDetails]}>
                {children}
            </UserContext.Provider>
        </>
    );
};