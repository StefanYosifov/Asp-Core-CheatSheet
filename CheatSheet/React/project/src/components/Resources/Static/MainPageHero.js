import { Link } from "react-router-dom"
import { URLS } from "../../../constants/URLConstants"

export const MainPageHero = () => {
    return (
        <section className="bg-bgWhiteUI-0 text-bgBlackUI-0  border-b border-b-pinkUI-0 shadow-md">
            <div className="container flex flex-col items-center px-4 py-12 mx-auto xl:flex-row">
                <div className="flex justify-center xl:w-1/2">
                    <img className="h-80 w-80 sm:w-[28rem] sm:h-[28rem] flex-shrink-0 object-cover rounded-full" 
                    src="https://images.unsplash.com/photo-1551650975-87deedd944c3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1974&q=80" alt=""/>
                </div>

                <div className="flex flex-col items-center mt-6 xl:items-start xl:w-1/2 xl:mt-0">
                    <h2 className="text-2xl font-semibold tracking-tight xl:text-3xl">
                        Create an article and win great prizes
                    </h2>

                    <p className="block max-w-2xl mt-4">
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Aut corporis esse dolorum, illum, consectetur earum provident alias dolore omnis quis tempore voluptatum excepturi ea numquam? Aperiam fugiat consequuntur nostrum odio. </p>

                    <div className="mt-6 sm:-mx-2">
                        <Link 
                        to={`${URLS.RESOURCES_ADD}`}
                        className="inline-flex items-center justify-center w-full px-4 text-sm py-2.5 overflow-hidden text-pinkUI-0 transition-colors duration-300 bg-bgBlackUI-0 rounded-lg shadow sm:w-auto sm:mx-2 hover:bg-gray-700 focus:ring focus:ring-gray-300 focus:ring-opacity-80">
                            <svg className="w-5 h-5 mx-2 fill-current" xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 512 512"space="preserve">
                                <g>
                                    <g>
                                        <path d="M407,0H105C47.103,0,0,47.103,0,105v302c0,57.897,47.103,105,105,105h302c57.897,0,105-47.103,105-105V105C512,47.103,464.897,0,407,0z M482,407c0,41.355-33.645,75-75,75H105c-41.355,0-75-33.645-75-75V105c0-41.355,33.645-75,75-75h302c41.355,0,75,33.645,75,75V407z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M305.646,123.531c-1.729-6.45-5.865-11.842-11.648-15.18c-11.936-6.892-27.256-2.789-34.15,9.151L256,124.166l-3.848-6.665c-6.893-11.937-22.212-16.042-34.15-9.151h-0.001c-11.938,6.893-16.042,22.212-9.15,34.151l18.281,31.664L159.678,291H110.5c-13.785,0-25,11.215-25,25c0,13.785,11.215,25,25,25h189.86l-28.868-50h-54.079l85.735-148.498C306.487,136.719,307.375,129.981,305.646,123.531z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M401.5,291h-49.178l-55.907-96.834l-28.867,50l86.804,150.348c3.339,5.784,8.729,9.921,15.181,11.65c2.154,0.577,4.339,0.863,6.511,0.863c4.332,0,8.608-1.136,12.461-3.361c11.938-6.893,16.042-22.213,9.149-34.15L381.189,341H401.5c13.785,0,25-11.215,25-25C426.5,302.215,415.285,291,401.5,291z"></path>
                                    </g>
                                </g>
                                <g>
                                    <g>
                                        <path d="M119.264,361l-4.917,8.516c-6.892,11.938-2.787,27.258,9.151,34.15c3.927,2.267,8.219,3.345,12.458,3.344c8.646,0,17.067-4.484,21.693-12.495L176.999,361H119.264z"></path>
                                    </g>
                                </g>
                            </svg>

                            <span className="mx-2">
                                Create an article here
                            </span>
                        </Link>

                    </div>
                </div>
            </div>
        </section>
    )
}