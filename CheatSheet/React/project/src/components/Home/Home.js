import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom'
import { GetStatistics } from '../../api/Requests/statistics'
import image from '../../for the project.jpg'
import { BsGithub, BsDiscord } from "react-icons/bs"
import { URLS } from '../../constants/URLConstants';



const HomePage = () => {
  const [statistics, setStatistics] = useState();


  useEffect(() => {
    GetStatistics()
      .then(data => data)
      .then(res => setStatistics(res.data));
  }, [])

  console.log(statistics);


  const Hero = () => {
    return (
      <div className='hero h-128 bg-gradient-to-r from-bgBlackUI-0 to to-bgNearBlackUI-0 w-full'>
        <div className='flex flex-wrap mx-14 content-center justify-center pt-8'>
          <div className='basis-12 items-start'>
            <img src={image} className='max-w-xs border rounded-full border-bgBlackUI-0 shadow-sm mix-blend-screen' />
          </div>
          <div className='flex items-start flex-col h-full ml-24'>
            <div className='text-bgWhiteUI-0'>
              <div className='flex justify-end h-20'>
                <ul className='flex justify-end'>
                  <li className='ml-2 py-2 hover:cursor-pointer'><BsGithub /></li>
                  <li className='ml-2 py-2 hover:cursor-pointer'><BsDiscord /></li>
                </ul>
              </div>
              <div className='p-4'>
                <h1 className='text-5xl'>Project Cheat Sheet</h1>
                <h1 className='mt-4 text-2xl'>Sharpen your computer science skills</h1>
              </div>
            </div>
            <div className='mt-4 p-4'>
              <Link
                to={`${URLS.COURSES}1`}
                className="py-3 px-4 inline-flex justify-center items-center gap-2 rounded-md border-2 bg-bgWhiteUI-0 border-purple-100 font-semibold text-pinkUI-0-500 hover:text-white hover:bg-pinkUI-0 hover:border-pinkUI-0 focus:outline-none focus:ring-2 focus:ring-purple-200 focus:ring-offset-2 transition-all text-sm dark:focus:ring-offset-gray-800">
                View Courses
              </Link>
              <Link
                to={`${URLS.RESOURCES}1`}
                className="py-3 px-4 ml-4 inline-flex justify-center items-center gap-2 rounded-md border-2 bg-bgWhiteUI-0 border-purple-100 font-semibold text-pinkUI-0-500 hover:text-white hover:bg-pinkUI-0 hover:border-pinkUI-0 focus:outline-none focus:ring-2 focus:ring-purple-200 focus:ring-offset-2 transition-all text-sm dark:focus:ring-offset-gray-800">
                View Resources
              </Link>
            </div>
            <div>
            </div>
            <div>
            </div>
          </div>
        </div>
      </div>

    )
  }

  const Features = () => {
    return (
      <>
        <section className="flex items-center justify-center h-128 bg-bgWhiteUI-0 text-bgBlackUI-0">
          <div className="container px-6 py-12 flex">
            <div className="grid grid-cols-1 gap-8 md:grid-cols-2 lg:grid-cols-3">
              <div>
                <svg className="w-8 h-8" viewBox="0 0 30 30" fill="none">
                  <path d="M29.6931 14.2283L22.7556 6.87823C22.3292 6.426 21.6175 6.40538 21.1652 6.83212C20.7137 7.25851 20.6927 7.9706 21.1195 8.42248L27.3284 15L21.1195 21.5783C20.6927 22.0302 20.7137 22.7419 21.1652 23.1687C21.3827 23.3738 21.6606 23.4754 21.9374 23.4754C22.2363 23.4754 22.5348 23.3569 22.7557 23.1233L29.6932 15.7729C30.1022 15.339 30.1023 14.6618 29.6931 14.2283Z" fill="#2D3748" /><path d="M8.88087 21.578L2.67236 15L8.88087 8.42215C9.30726 7.97028 9.28664 7.25812 8.83476 6.83179C8.38323 6.4054 7.67073 6.42603 7.2444 6.87791L0.306858 14.2279C-0.102245 14.6614 -0.102245 15.3391 0.306858 15.7726L7.24475 23.123C7.466 23.3574 7.76413 23.4755 8.06302 23.4755C8.33976 23.4755 8.61767 23.3735 8.83476 23.1684C9.28705 22.742 9.30726 22.0299 8.88087 21.578Z" fill="#2D3748" /><path d="M16.8201 3.08774C16.2062 2.99476 15.6317 3.41622 15.5379 4.03011L12.2379 25.6302C12.1441 26.2445 12.566 26.8186 13.1803 26.9124C13.238 26.921 13.295 26.9252 13.3516 26.9252C13.898 26.9252 14.3773 26.5266 14.4624 25.97L17.7624 4.3699C17.8562 3.7556 17.4343 3.1815 16.8201 3.08774Z" fill="#4299E1" />
                </svg>

                <h1 className="mt-4 text-xl font-semibold ">Wide Range of Subjects</h1>

                <p className="mt-2 ">
                  Whether you're looking to master a specific academic subject, explore a new hobby, or develop professional skills, we've got you covered. We offer a diverse range of courses spanning various disciplines.
                </p>
              </div>

              <div>
                <svg className="w-8 h-8" viewBox="0 0 30 30" fill="none">
                  <path d="M27.3633 7.08984H26.4844V6.21094C26.4844 4.75705 25.3015 3.57422 23.8477 3.57422H4.39453C2.94064 3.57422 1.75781 4.75705 1.75781 6.21094V21.1523H0.878906C0.393516 21.1523 0 21.5459 0 22.0312V23.7891C0 25.2429 1.18283 26.4258 2.63672 26.4258H27.3633C28.8172 26.4258 30 25.2429 30 23.7891V9.72656C30 8.27268 28.8172 7.08984 27.3633 7.08984ZM3.51562 6.21094C3.51562 5.72631 3.9099 5.33203 4.39453 5.33203H23.8477C24.3323 5.33203 24.7266 5.72631 24.7266 6.21094V7.08984H20.332C18.8781 7.08984 17.6953 8.27268 17.6953 9.72656V21.1523H3.51562V6.21094ZM1.75781 23.7891V22.9102H17.6953V23.7891C17.6953 24.0971 17.7489 24.3929 17.8465 24.668H2.63672C2.15209 24.668 1.75781 24.2737 1.75781 23.7891ZM28.2422 23.7891C28.2422 24.2737 27.8479 24.668 27.3633 24.668H20.332C19.8474 24.668 19.4531 24.2737 19.4531 23.7891V9.72656C19.4531 9.24193 19.8474 8.84766 20.332 8.84766H27.3633C27.8479 8.84766 28.2422 9.24193 28.2422 9.72656V23.7891Z" fill="#2D3748" /><path d="M24.7266 21.1523H22.9688C22.4834 21.1523 22.0898 21.5459 22.0898 22.0312C22.0898 22.5166 22.4834 22.9102 22.9688 22.9102H24.7266C25.212 22.9102 25.6055 22.5166 25.6055 22.0312C25.6055 21.5459 25.212 21.1523 24.7266 21.1523Z" fill="#4299E1" /><path d="M23.8477 12.3633C24.3331 12.3633 24.7266 11.9698 24.7266 11.4844C24.7266 10.999 24.3331 10.6055 23.8477 10.6055C23.3622 10.6055 22.9688 10.999 22.9688 11.4844C22.9688 11.9698 23.3622 12.3633 23.8477 12.3633Z" fill="#4299E1" />
                </svg>

                <h1 className="mt-4 text-xl font-semibold">High-Quality Courses</h1>

                <p className="mt-2 ">
                  Our courses are meticulously designed by experts in their respective fields. You can trust that you're getting top-notch educational content that's both accurate and up-to-date.
                </p>
              </div>

              <div>
                <svg className="w-8 h-8" viewBox="0 0 30 30" fill="none">
                  <g clip-path="url(#clip0)"><path d="M26.599 4.339a1.875 1.875 0 11-3.75 0 1.875 1.875 0 013.75 0zM7.151 25.661a1.875 1.875 0 11-3.75 0 1.875 1.875 0 013.75 0zM23.486 13.163a8.636 8.636 0 00-1.19-2.873l1.123-1.123-2.592-2.59L19.705 7.7a8.636 8.636 0 00-2.873-1.19V4.921h-3.664v1.586a8.634 8.634 0 00-2.873 1.19l-1.122-1.12-2.592 2.589 1.123 1.123a8.636 8.636 0 00-1.19 2.873H4.922l-.002 3.663h1.592A8.626 8.626 0 007.704 19.7l-1.127 1.127 2.59 2.591 1.128-1.127a8.623 8.623 0 002.873 1.19v1.597h3.664v-1.597a8.628 8.628 0 002.873-1.19l1.128 1.128 2.59-2.592-1.127-1.127a8.627 8.627 0 001.19-2.873h1.593v-3.664h-1.593zM15 19.256a4.255 4.255 0 110-8.511 4.255 4.255 0 010 8.51z" fill="#4299E1" /><path d="M5.276 23.2c-.42 0-.823.105-1.182.302A13.853 13.853 0 011.172 15C1.172 7.375 7.375 1.172 15 1.172c.927 0 1.854.092 2.754.274a.586.586 0 00.232-1.149A15.111 15.111 0 0015 0C10.993 0 7.226 1.56 4.393 4.393A14.902 14.902 0 000 15c0 3.37 1.144 6.66 3.228 9.296-.268.4-.413.872-.413 1.365 0 .657.257 1.275.721 1.74a2.444 2.444 0 001.74.721c.658 0 1.276-.256 1.74-.721.465-.465.721-1.083.721-1.74s-.256-1.276-.72-1.74a2.445 2.445 0 00-1.74-.72zm.912 3.373a1.28 1.28 0 01-.912.377 1.28 1.28 0 01-.911-.377 1.28 1.28 0 01-.378-.912c0-.344.134-.668.378-.912a1.28 1.28 0 01.911-.377c.345 0 .668.134.912.378.243.243.377.567.377.911 0 .344-.134.668-.377.912zM26.772 5.703a2.465 2.465 0 00-.308-3.104 2.446 2.446 0 00-1.74-.721c-.658 0-1.276.256-1.74.72a2.445 2.445 0 00-.721 1.74c0 .658.256 1.276.72 1.741.465.465 1.083.72 1.74.72.42 0 .824-.104 1.183-.3A13.854 13.854 0 0128.828 15c0 7.625-6.203 13.828-13.828 13.828-.918 0-1.836-.09-2.728-.269a.586.586 0 00-.23 1.15c.968.193 1.963.291 2.958.291 4.007 0 7.773-1.56 10.607-4.393A14.902 14.902 0 0030 15c0-3.37-1.145-6.66-3.228-9.297zm-2.96-.452a1.28 1.28 0 01-.377-.912c0-.344.134-.668.377-.911a1.28 1.28 0 01.912-.378 1.29 1.29 0 010 2.578 1.28 1.28 0 01-.912-.377z" fill="#2D3748" /><path d="M12.582 25.078c0 .324.263.586.586.586h3.664a.586.586 0 00.586-.586v-1.136a9.179 9.179 0 002.199-.911l.802.802a.586.586 0 00.829 0l2.59-2.592a.586.586 0 000-.828l-.802-.802a9.169 9.169 0 00.911-2.199h1.132a.586.586 0 00.586-.585v-3.664a.586.586 0 00-.586-.586h-1.132a9.17 9.17 0 00-.911-2.199l.797-.797a.587.587 0 000-.829l-2.592-2.59a.586.586 0 00-.829 0l-.795.797a9.177 9.177 0 00-2.2-.912V4.922a.586.586 0 00-.585-.586h-3.664a.586.586 0 00-.586.586v1.126a9.169 9.169 0 00-2.199.91l-.796-.795a.586.586 0 00-.828 0l-2.592 2.59a.585.585 0 000 .828l.797.797a9.173 9.173 0 00-.911 2.199h-1.13a.586.586 0 00-.586.585l-.002 3.664a.585.585 0 00.586.586h1.132c.207.77.512 1.507.911 2.2l-.801.8a.586.586 0 000 .83l2.59 2.59a.586.586 0 00.829 0l.801-.801a9.185 9.185 0 002.2.911v1.136zm-1.97-3.28a.586.586 0 00-.732.078l-.713.714-1.761-1.763.712-.713a.586.586 0 00.078-.732 8.02 8.02 0 01-1.11-2.679.586.586 0 00-.572-.462H5.507l.002-2.492h1.005a.586.586 0 00.572-.463 8.022 8.022 0 011.11-2.678.586.586 0 00-.078-.733l-.708-.708 1.763-1.761.707.707c.196.196.5.228.733.078a8.016 8.016 0 012.678-1.11.586.586 0 00.463-.573v-1h2.492v1c0 .277.193.515.463.573a8.024 8.024 0 012.678 1.11c.232.15.537.118.732-.078l.708-.707 1.762 1.761-.708.708a.586.586 0 00-.078.732 8.027 8.027 0 011.11 2.679c.058.27.297.463.573.463h1.007v2.492h-1.007a.586.586 0 00-.573.462 8.02 8.02 0 01-1.11 2.679.586.586 0 00.078.732l.713.713-1.761 1.762-.714-.713a.586.586 0 00-.732-.078 8.027 8.027 0 01-2.678 1.11.586.586 0 00-.463.573v1.011h-2.492v-1.01a.586.586 0 00-.463-.574 8.021 8.021 0 01-2.678-1.11z" fill="#2D3748" /><path d="M19.841 15A4.847 4.847 0 0015 10.158 4.847 4.847 0 0010.158 15 4.847 4.847 0 0015 19.841 4.847 4.847 0 0019.841 15zm-8.51 0A3.674 3.674 0 0115 11.33 3.674 3.674 0 0118.67 15 3.674 3.674 0 0115 18.67 3.674 3.674 0 0111.33 15z" fill="#2D3748" /><path d="M20.395 2.216a.59.59 0 00.415-.172.593.593 0 00.171-.415.59.59 0 00-.586-.586.589.589 0 00-.586.586.589.589 0 00.586.587zM9.63 27.794a.59.59 0 00-.586.586.59.59 0 00.586.586.59.59 0 00.586-.586.59.59 0 00-.586-.585z" fill="#4299E1" /></g><defs><clipPath id="clip0"><path fill="#fff" d="M0 0h30v30H0z" /></clipPath></defs>
                </svg>

                <h1 className="mt-4 text-xl font-semibold ">24/7 Support</h1>

                <p className="mt-2 ">
                  Have a question or need assistance? Our dedicated support team is here to help, 24/7. Your success is our priority.
                </p>
              </div>
            </div>
          </div>
        </section>
      </>
    )
  }

  const Testimonials = () => {
    return (
      <section className="bg-bgWhiteUI-0 text-bgBlackUI-0 w-full flex justify-center">
        <div className="container px-6 py-10 ">
          <h1 className="text-2xl font-semibold text-center capitalize lg:text-3xl ">
            What our <span className="text-pinkUI-0">clients</span> say
          </h1>

          <div className="mt-4 text-center flex justify-center items-center"> {/* Modified this div */}
            {statistics && (
              <div>
                <p className="text-lg mt-4 text-center">
                  So far, we've educated over {statistics.usersCount} people with {statistics.resourcesCount} resources available on the platform.
                </p>
                <p>Look what some have to say</p>
              </div>
            )}
          </div>

          <section className="grid grid-cols-1 gap-8 mt-8 xl:mt-12 lg:grid-cols-2 xl:grid-cols-3">
            <div className="p-8 border shadow-md rounded-lg">
              <p className="leading-loose text-bgBlackUI-0">
                "As a previous customer of CheatSheet, I can't say enough positive things about the courses I've taken.
                The quality of the content is truly exceptional.
                Each course is structured in a way that's easy to follow, and the material is presented in a clear and engaging manner.
                It's evident that the instructors are experts in their fields, and they have a knack for simplifying complex topics."
              </p>

              <div className="flex items-center mt-8 -mx-2">
                <img className="object-cover mx-2 rounded-full w-14 shrink-0 h-14 ring-4 ring-gray-300 dark:ring-gray-700" src="https://images.unsplash.com/photo-1570295999919-56ceb5ecca61?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80" alt="" />

                <div className="mx-2">
                  <h1 className="font-semibold text-gray-800 dark:text-white">Robert</h1>
                  <span className="text-sm text-bgBlackUI-0">Robert Consultency</span>
                </div>
              </div>
            </div>

            <div className="p-8 border shadow-md rounded-lg">
              <p className="leading-loose text-bgBlackUI-0">
                "I appreciate the flexibility the courses offer. Being able to learn at my own pace has been a game-changer for me.
                I don't have to worry about rigid schedules, and I can fit my studies around my busy life. Plus, the interactive elements in the courses keep me motivated.
                The quizzes and assignments not only reinforce my understanding but also make the learning process more enjoyable."
              </p>

              <div className="flex items-center mt-8 -mx-2">
                <img className="object-cover mx-2 rounded-full w-14 shrink-0 h-14 ring-4 ring-gray-300 dark:ring-gray-700" src="https://images.unsplash.com/photo-1531590878845-12627191e687?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=764&q=80" alt="" />

                <div className="mx-2">
                  <h1 className="font-semibold text-gray-800 dark:text-white">Jeny Doe</h1>
                  <span className="text-sm text-bgBlackUI-0">Jeny Consultency</span>
                </div>
              </div>
            </div>

            <div className="p-8 border shadow-md rounded-lg">
            <p className="leading-loose text-bgBlackUI-0">
              "Lastly, I've been pleasantly surprised by the sense of community. Connecting with other learners, sharing insights, and even collaborating on projects has enriched my learning experience. 
              I'm truly grateful to have found CheatSheet, and I highly recommend their courses to anyone looking to expand their knowledge and skills. I have been loving every single moment."
              </p>

              <div className="flex items-center mt-8 -mx-2">
                <img className="object-cover mx-2 rounded-full w-14 shrink-0 h-14 ring-4 ring-gray-300 dark:ring-gray-700" src="https://images.unsplash.com/photo-1488508872907-592763824245?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80" alt="" />

                <div className="mx-2">
                  <span className="text-sm text-bgBlackUI-0">Ema watson</span>
                </div>
              </div>
            </div>
          </section>
        </div>
      </section>
    )
  }


  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen divide-y">
        <header className="flex flex-col items-center justify-center w-full mb-12 divide-y">
          <Hero />
        </header>
        <main className="flex flex-col items-center justify-center w-full divide-y">
          <Features />
          <Testimonials />
        </main>
      </div>
    </>
  )
}

export default HomePage;
