import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useUserDetails } from '../../../stores/useUserDetails';
import { URLS } from '../../../constants/URLConstants';
import logo from '../../../for the project.jpg';


function RegisterPage() {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        userName: "",
        password: "",
        email: "",
        repeatPass: ""
    });

    const register = useUserDetails((state) => state.register);

    const handleSubmit = (event) => {
        event.preventDefault();
        const response = register(formData.userName, formData.email, formData.password);
        if (response.status === 200) {
            navigate(URLS.HOME);
        }
    };


    const handleChange = (event) => {
        const { name, value } = event.target;

        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };
    return (
        <section className="bg-bgGreyishBlack-0 h-full flex justify-center items-center">
            <div class="w-full max-w-sm overflow-hidden bg-bgWhiteUI-0 rounded-lg shadow-md my-24">
                <div class="px-6 py-4">
                    <div class="flex justify-center mx-auto">
                        <img class="w-auto h-24 sm:h-24 rounded-full" src={logo} alt="Logo" />
                    </div>

                    <h3 class="mt-3 text-xl font-medium text-center text-bgBlackUI-0">Welcome to our website</h3>

                    <p class="mt-1 text-center text-gray-500 dark:text-gray-400">Create an account</p>
                    <div className="w-full bg-bgWhiteUI-0 rounded-lg md:mt-0 sm:max-w-md xl:p-0">
                            <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
                            <h1 className="text-xl font-bold leading-tight tracking-tight text-bgBlackUI-0 md:text-2xl ">
                                Welcome to our website!
                            </h1>
                            <form className="space-y-4 md:space-y-6" onSubmit={handleSubmit}>
                                <div>
                                    <label htmlFor="userName" className="block mb-2 text-sm font-medium text-bgBlackUI-0">Your username</label>
                                    <input type="userName" value={formData.userName} onChange={handleChange} name="userName" id="userName"  className="bg-gray-100 border border-gray-300 text-bgBlackUI-0 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5" placeholder="name@company.com" required="" />
                                </div>
                                <div>
                                    <label htmlFor="email" className="block mb-2 text-sm font-medium text-bgBlackUI-0">Your email</label>
                                    <input type="email" value={formData.email} onChange={handleChange} name="email" id="email"  className="bg-gray-100 border border-gray-300 text-bgBlackUI-0 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5" placeholder="name@company.com" required="" />
                                </div>
                                <div>
                                    <label htmlFor="password" className="block mb-2 text-sm font-medium text-bgBlackUI-0">Password</label>
                                    <input type="password" value={formData.password} onChange={handleChange} name="password" id="password" placeholder="••••••••"  className="bg-gray-100 border border-gray-300 text-bgBlackUI-0 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5" required="" />
                                </div>
                                <label htmlFor="repeatPass" className="block mb-2 text-sm font-medium text-bgBlackUI-0">Repeat your password</label>
                                <input type="password" value={formData.repeatPass} onChange={handleChange} name="repeatPass" id="repeatPass" placeholder="••••••••"  className="bg-gray-100 border border-gray-300 text-bgBlackUI-0 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5" required="" />
                                <div className="flex items-center justify-between">
                                    <div className="flex items-start">
                                        <div className="flex items-center h-5">
                                            <input id="remember" aria-describedby="remember" type="checkbox" className="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-primary-600 dark:ring-offset-gray-800" required="" />
                                        </div>
                                        <div className="ml-3 text-sm">
                                            <label htmlFor="remember" className="text-gray-500 dark:text-gray-300">Remember me</label>
                                        </div>
                                    </div>
                                    <Link to="#" className="text-sm font-medium text-primary-600 hover:underline dark:text-primary-500">Forgot password?</Link>
                                </div>
                                <button type="submit" className="w-full text-bgWhiteUI-0 bg-pinkUI-0 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">Sign in</button>
                                <p className="text-sm font-light text-bgGreyishBlack-0">
                                    Don’t have an account yet? <Link to={URLS.LOGIN} className="font-medium text-primary-600 hover:underline dark:text-primary-500">Sign up</Link>
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default RegisterPage;
