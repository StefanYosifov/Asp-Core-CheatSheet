import create from "zustand";
import { persist } from "zustand/middleware";
import { login, register } from "../api/Requests/authentication";
import { clearUserData, clearUserToken } from "../api/util";
import { toast } from "react-toastify";
import { AuthenticationConstants, AuthenticationMessage } from "../constants/AuthenticationConstants";

export const useUserDetails = create(persist(
    (set, get) => ({
        user: null,
        isAuthenticated: false,
        login: async (userName, password) => {
            try {
                const response = await login(userName, password);
                const data = response.data;
                if (response.status === 200) {
                    set({ user: data });
                    set({ isAuthenticated: true });
                }
                return response;
            } catch (error) {
                toast.error(error);
            }
        },
        register: async (userName, email, password) => {
            debugger;
            if( userName.length <AuthenticationConstants.USERNAME_MIN_LENGTH){
                return toast.error(AuthenticationMessage.USERNAME_TOO_SHORT)
            }
            if(new RegExp(AuthenticationConstants.EMAIL_REGEX).test(email)===false){
                return toast.error(AuthenticationMessage.EMAIL_INVALID);
            }
            if(password.length<AuthenticationConstants.PASSWORD_MIN_LENGTH){
                return toast.error(AuthenticationMessage.PASSWORD_TOO_SHORT);
            }
            const data = { userName, email, password };
            try {
                const response = await register(data);
                if (response.status === 200) {
                    set({ user: data });
                    set({ isAuthenticated: true });
                    return response;
                }
            } catch (error) {
                console.log(error);
            }
        },
        logout: () => {
            set({ user: null });
            set({ isAuthenticated: false });
            clearUserData();
            clearUserToken();
        }
    }),
    {
        name: "user-storage",
        getStorage: () => localStorage,
    }
))


