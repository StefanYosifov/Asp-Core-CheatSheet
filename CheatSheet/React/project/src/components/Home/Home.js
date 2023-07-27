import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom'
import { GetStatistics } from '../../api/Requests/statistics'


const HomePage = () => {
  const [statistics, setStatistics] = useState();


  useEffect(() => {
    GetStatistics()
      .then(data => data)
      .then(res => setStatistics(res.data));
  }, [])

  console.log(statistics);


  function Welcome() {
    return (
      <div class="container my-24 mx-auto md:px-6">
      <section class="mb-32 text-center">
        <div class="flex justify-center">
          <div class="max-w-[700px] text-center">
            <h2 class="mb-6 text-center text-3xl font-bold">
              <u class="text-primary dark:text-primary-400">
                Why choose us?
                </u>
            </h2>
            <p class="mb-16 text-neutral-500 dark:text-primary-400">
              Minus fuga aliquid vero facere ducimus quos, quisquam nemo?
              Molestias ullam provident vitae error aliquam dolorum temporibus?
              Doloremque, quasi
            </p>
          </div>
        </div>
    
        <div class="grid gap-x-6 md:grid-cols-2 lg:grid-cols-4 lg:gap-x-12">
          <div class="mb-12 lg:mb-0">
            <div class="mb-6 inline-block rounded-full bg-primary-100 p-4 text-primary shadow-sm">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2"
                stroke="currentColor" class="h-6 w-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M11.42 15.17L17.25 21A2.652 2.652 0 0021 17.25l-5.877-5.877M11.42 15.17l2.496-3.03c.317-.384.74-.626 1.208-.766M11.42 15.17l-4.655 5.653a2.548 2.548 0 11-3.586-3.586l6.837-5.63m5.108-.233c.55-.164 1.163-.188 1.743-.14a4.5 4.5 0 004.486-6.336l-3.276 3.277a3.004 3.004 0 01-2.25-2.25l3.276-3.276a4.5 4.5 0 00-6.336 4.486c.091 1.076-.071 2.264-.904 2.95l-.102.085m-1.745 1.437L5.909 7.5H4.5L2.25 3.75l1.5-1.5L7.5 4.5v1.409l4.26 4.26m-1.745 1.437l1.745-1.437m6.615 8.206L15.75 15.75M4.867 19.125h.008v.008h-.008v-.008z" />
              </svg>
            </div>
            <h5 class="mb-4 text-lg font-bold">Support 24/7</h5>
            <p class="text-neutral-500 dark:text-primary-4000">
              Laudantium totam quas cumque pariatur at doloremque hic quos quia
              eius. Reiciendis optio minus mollitia rerum labore
            </p>
          </div>
    
          <div class="mb-12 lg:mb-0">
            <div class="mb-6 inline-block rounded-full bg-primary-100 p-4 text-primary shadow-sm">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2"
                stroke="currentColor" class="h-6 w-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M15.75 5.25a3 3 0 013 3m3 0a6 6 0 01-7.029 5.912c-.563-.097-1.159.026-1.563.43L10.5 17.25H8.25v2.25H6v2.25H2.25v-2.818c0-.597.237-1.17.659-1.591l6.499-6.499c.404-.404.527-1 .43-1.563A6 6 0 1121.75 8.25z" />
              </svg>
            </div>
            <h5 class="mb-4 text-lg font-bold">Safe and solid</h5>
            <p class="text-neutral-500 dark:text-primary-4000">
              Eum nostrum fugit numquam, voluptates veniam neque quibusdam ullam
              aspernatur odio soluta, quisquam dolore animi
            </p>
          </div>
    
          <div class="mb-12 md:mb-0">
            <div class="mb-6 inline-block rounded-full bg-primary-100 p-4 text-primary shadow-sm">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2"
                stroke="currentColor" class="h-6 w-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M8.25 18.75a1.5 1.5 0 01-3 0m3 0a1.5 1.5 0 00-3 0m3 0h6m-9 0H3.375a1.125 1.125 0 01-1.125-1.125V14.25m17.25 4.5a1.5 1.5 0 01-3 0m3 0a1.5 1.5 0 00-3 0m3 0h1.125c.621 0 1.129-.504 1.09-1.124a17.902 17.902 0 00-3.213-9.193 2.056 2.056 0 00-1.58-.86H14.25M16.5 18.75h-2.25m0-11.177v-.958c0-.568-.422-1.048-.987-1.106a48.554 48.554 0 00-10.026 0 1.106 1.106 0 00-.987 1.106v7.635m12-6.677v6.677m0 4.5v-4.5m0 0h-12" />
              </svg>
            </div>
            <h5 class="mb-4 text-lg font-bold">Extremely fast</h5>
            <p class="text-neutral-500 dark:text-primary-400">
              Enim cupiditate, minus nulla dolor cumque iure eveniet facere
              ullam beatae hic voluptatibus dolores exercitationem
            </p>
          </div>
    
          <div class="mb-12 md:mb-0">
            <div class="mb-6 inline-block rounded-full bg-primary-100 p-4 text-primary shadow-sm">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2"
                stroke="currentColor" class="h-6 w-6">
                <path stroke-linecap="round" stroke-linejoin="round" d="M10.5 6a7.5 7.5 0 107.5 7.5h-7.5V6z" />
                <path stroke-linecap="round" stroke-linejoin="round" d="M13.5 10.5H21A7.5 7.5 0 0013.5 3v7.5z" />
              </svg>
            </div>
            <h5 class="mb-4 text-lg font-bold">Live analytics</h5>
            <p class="text-neutral-500 dark:text-primary-400">
              Illum doloremque ea, blanditiis sed dolor laborum praesentium
              maxime sint, consectetur atque ipsum ab adipisci
            </p>
          </div>
        </div>
      </section>
    </div>
    )
  }

  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
        {Welcome()}
        <header className="flex flex-col items-center justify-center w-full mb-12">

          <h1 className="text-4xl font-bold text-gray-800 text-center">
            Welcome to My Educational Site
          </h1>
          {statistics && (
            <p className="text-lg text-gray-600 mt-4 text-center">
              So far, we've educated over {statistics.usersCount} people with {statistics.resourcesCount} resources available on the platform.
            </p>
          )}
        </header>
        <main className="flex flex-col items-center justify-center w-full">
          <article>

            <p className="text-2xl font-bold text-gray-800 mb-8 text-center">
              Explore our courses and resources
            </p>
            <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
              <Link
                to="/course/all/1"
                className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-4 px-8 rounded transition duration-200 ease-in-out transform hover:-translate-y-1 hover:scale-110"
              >
                View Courses
              </Link>
              <Link
                to="/resources/1"
                className="bg-green-500 hover:bg-green-600 text-white font-bold py-4 px-8 rounded transition duration-200 ease-in-out transform hover:-translate-y-1 hover:scale-110"
              >
                View Resources
              </Link>
            </div>
          </article>
          <div className="container mx-auto py-10 px-4 lg:px-0">
            <article className="mb-10">
              <h2 className="text-3xl font-bold mb-4">About Us</h2>
              <p className="text-lg leading-7">
                At Cheat Sheet Project, we believe that software development should be accessible to everyone. Our mission is to provide high-quality educational resources to individuals of all skill levels who are interested in learning how to code.
              </p>
              <p className="text-lg leading-7 mt-4">
                We understand that the world of software development can be overwhelming, especially for beginners. That's why we've created a comprehensive library of cheat sheets, tutorials, and courses that break down complex coding concepts into easy-to-understand chunks.
              </p>
              <p className="text-lg leading-7 mt-4">
                Our team of experienced software developers and educators is committed to providing the most up-to-date information and best practices in the industry. We cover a wide range of topics, from programming languages and frameworks to development tools and techniques.
              </p>
              <p className="text-lg leading-7 mt-4">
                Whether you're a complete beginner or an experienced developer looking to sharpen your skills, Cheat Sheet Project has something for you. Our courses are designed to be flexible, so you can learn at your own pace and on your own schedule.
              </p>
              <p className="text-lg leading-7 mt-4">
                At Cheat Sheet Project, we're passionate about empowering people to learn how to code. We believe that anyone can become a successful software developer with the right resources and support. Join us on this exciting journey and discover the possibilities of software development.
              </p>
            </article>
            <article>
              <h2 className="text-3xl font-bold mb-4">Our History</h2>
              <p className="text-lg leading-7">
                Cheat Sheet Project was founded in 2015 by a group of software developers who wanted to make learning how to code easier and more accessible for everyone. They recognized that traditional programming textbooks and courses could be overwhelming and confusing, especially for beginners.
              </p>
              <p className="text-lg leading-7 mt-4">
                The team started by creating a series of cheat sheets that condensed complex coding concepts into simple, easy-to-understand reference guides. These cheat sheets quickly gained popularity among developers of all skill levels and became the foundation for Cheat Sheet Project's educational resources.
              </p>
              <p className="text-lg leading-7 mt-4">
                As the demand for more comprehensive learning materials grew, Cheat Sheet Project began creating tutorials and courses that covered a wide range of programming languages, frameworks, and development tools. The company's mission was to provide the most up-to-date and relevant information in the industry, while still making it accessible and easy to understand.
              </p>
              <p className="text-lg leading-7 mt-4">
                Today, Cheat Sheet Project has become a leading provider of online educational resources for software development. With a team of experienced developers and educators, we continue to create high-quality content that empowers individuals to learn how to code and pursue careers in tech.
              </p>
              <p className="text-lg leading-7 mt-4">
                We're proud of how far we've come and remain committed to our founding mission of making software development accessible to everyone. Whether you're a complete beginner or an experienced developer, we believe that anyone can learn how to code with the right resources and support. Join us on this exciting journey and discover the possibilities
              </p>
            </article>
          </div>

        </main>
      </div>
    </>
  )
}

export default HomePage;
