export const About = () => {
    return (
        <div className="2xl:container 2xl:mx-auto lg:py-16 lg:px-20 md:py-12 md:px-6 py-9 px-4">
            <div className="flex flex-col lg:flex-row justify-between gap-8">
                <div className="w-full lg:w-5/12 flex flex-col justify-center">
                    <h1 className="text-3xl lg:text-4xl font-bold leading-9 text-bgBlackUI-0 pb-4">About Us</h1>
                    <p className="font-normal text-base leading-6 text-gray-600">
                    At CheatSheet, we understand the challenges of modern life – juggling work, family, and personal goals. We've been there, and that's why we're passionate about making learning flexible, engaging, and enjoyable. Our journey began with a simple yet powerful idea: to create a platform that bridges the gap between busy lives and the desire for continuous education.                        </p>
                    <h1 className="text-3xl lg:text-4xl font-bold leading-9 text-bgBlackUI-0 pb-4 mt-4">Our Mission</h1>
            
                    <p className="font-normal text-base leading-6 text-gray-600">At CheatSheet, our mission is clear: to make high-quality education accessible, engaging, and flexible. We believe that learning is a lifelong pursuit, and everyone deserves the opportunity to acquire new skills, expand their horizons, and thrive in a rapidly evolving world.</p>

            <h5 className="text-3xl lg:text-4xl font-bold leading-9 text-bgBlackUI-0 pb-4 mt-4">Exceptional Content, Expert Instructors</h5>
            <p className="font-normal text-base leading-6 text-gray-600">We take pride in curating top-notch courses across a wide range of subjects. Our team of experienced instructors brings real-world expertise to each course, ensuring that you receive the most current and relevant information. Whether you're seeking academic excellence, professional growth, or personal enrichment, our courses are designed to empower you every step of the way.</p>
                </div>
                <div className="w-full lg:w-8/12 ">
                    <img className="w-full h-full object-contain" src="https://i.ibb.co/FhgPJt8/Rectangle-116.png" alt="A group of People" />
                </div>
            </div>


            <div className="flex lg:flex-row flex-col justify-between gap-8 pt-12">
                <div className="w-full lg:w-5/12 flex flex-col justify-center">
                    <h1 className="text-3xl lg:text-4xl font-bold leading-9 text-bgBlackUI-0 pb-4">Our Story</h1>
                    <p className="font-normal text-base leading-6 text-gray-600 ">
                    It all started with a conversation among friends who realized that the traditional education system, while valuable, often left many eager learners underserved. We saw a world where people, driven by curiosity and ambition, were looking for opportunities to learn, grow, and adapt. The idea of CheatSheet was born from this realization – a platform that would empower individuals to access high-quality education on their own terms.                        </p>
                </div>
                <div className="w-full lg:w-8/12 lg:pt-8">
                    <div className="grid md:grid-cols-4 sm:grid-cols-2 grid-cols-1 lg:gap-4 shadow-lg rounded-md">
                        <div className="p-4 pb-6 flex justify-center flex-col items-center">
                            <img className="md:block hidden" src="https://i.ibb.co/FYTKDG6/Rectangle-118-2.png" alt="Alexa featured Img" />
                            <img className="md:hidden block" src="https://i.ibb.co/zHjXqg4/Rectangle-118.png" alt="Alexa featured Img" />
                            <p className="font-medium text-xl leading-5 text-bgBlackUI-0 mt-4">Alexa</p>
                        </div>
                        <div className="p-4 pb-6 flex justify-center flex-col items-center">
                            <img className="md:block hidden" src="https://i.ibb.co/fGmxhVy/Rectangle-119.png" alt="Olivia featured Img" />
                            <img className="md:hidden block" src="https://i.ibb.co/NrWKJ1M/Rectangle-119.png" alt="Olivia featured Img" />
                            <p className="font-medium text-xl leading-5 text-bgBlackUI-0 mt-4">Olivia</p>
                        </div>
                        <div className="p-4 pb-6 flex justify-center flex-col items-center">
                            <img className="md:block hidden" src="https://i.ibb.co/Pc6XVVC/Rectangle-120.png" alt="Liam featued Img" />
                            <img className="md:hidden block" src="https://i.ibb.co/C5MMBcs/Rectangle-120.png" alt="Liam featued Img" />
                            <p className="font-medium text-xl leading-5 text-bgBlackUI-0 mt-4">Liam</p>
                        </div>
                        <div className="p-4 pb-6 flex justify-center flex-col items-center">
                            <img className="md:block hidden" src="https://i.ibb.co/7nSJPXQ/Rectangle-121.png" alt="Elijah featured img" />
                            <img className="md:hidden block" src="https://i.ibb.co/ThZBWxH/Rectangle-121.png" alt="Elijah featured img" />
                            <p className="font-medium text-xl leading-5 text-bgBlackUI-0 mt-4">Elijah</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

