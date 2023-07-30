import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import ResourceAdd from './components/Resources/Add/ResourceAdd';
import { CourseJoin } from './components/Courses/CourseJoin';
import { CourseMy } from './components/Courses/CourseMy';
import { CoursePage } from './components/Courses/CoursePage';
import { CourseVideo } from './components/Courses/CourseVideo';
import { CoursesList } from './components/Courses/CoursesList';

import { Footer } from './components/Footer/Footer';
import HomePage from './components/Home/Home';
import { Navigation } from './components/Navigation/Navigation';
import Profile from './components/Profile/Profile';
import { Layout } from "./components/Setup/Layout";
import { Privacy } from './components/Static pages/Privacy';
import { TermsAndConditions } from './components/Static pages/Terms and conditions';
import { UserDataProvider } from './context/UserDataProvider';
import './index.css';

import { CourseList2 } from './components/Courses/CourseList2';
import { CourseOverView } from './components/Courses/CourseOverview';
import { ResourceList2 } from './components/Resources/MainPage/ResourceList2';
import RequireAuth from './components/Setup/RequireAuth';
import { APP_URLS } from './constants/URLConstants';
import { Edit } from './components/Resources/Edit/Edit';
import { Details2 } from './components/Resources/Detail/Details2';
import { Logout } from './components/Authentication/Logout/Logout';
import { Login } from './components/Authentication/Login/Login';
import RegisterPage from './components/Authentication/Register/Register';
import { Private } from './components/Administrator/Main/Private';

function App() {
  return (

    <UserDataProvider>
      <div className="h-screen w-full">
        <Navigation />
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route path={APP_URLS.REGISTER} Component={RegisterPage} />
            <Route path={APP_URLS.LOGIN} Component={Login} />

            <Route element={<RequireAuth />}>
              <Route path={APP_URLS.HOME} Component={HomePage} />
              <Route path={APP_URLS.LOGOUT} Component={Logout} />
              <Route path={APP_URLS.RESOURCES} Component={ResourceList2} />
              <Route path={APP_URLS.DETAILS} Component={Details2} />
              <Route path={APP_URLS.RESOURCES_ADD} Component={ResourceAdd} />
              <Route path={APP_URLS.RESOURCES_EDIT} Component={Edit} />
              <Route path={APP_URLS.PROFILE} Component={Profile} />
              <Route path={APP_URLS.PRIVACY} Component={Privacy} />
              <Route path={APP_URLS.TERMS} Component={TermsAndConditions} />
              <Route path={APP_URLS.COURSES} Component={CoursesList} />
              <Route path={APP_URLS.COURSES_ALL} Component={CourseList2} />
              <Route path={APP_URLS.COURSES_TRAININGS} Component={CoursePage} />
              <Route path={APP_URLS.COURSES_LESSON} Component={CourseVideo} />
              <Route path={APP_URLS.COURSES_JOIN} Component={CourseJoin} />
              <Route path={APP_URLS.COURSES_MINE} Component={CourseMy} />
              <Route path={APP_URLS.PRIVATE} Component={Private} />
              <Route path={APP_URLS.COURSES_OVERVIEW} Component={CourseOverView} />
            </Route>
          </Route>
        </Routes>
        <Footer/>
        <ToastContainer
          position="top-right"
          autoClose={2499}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          theme="light"
        />
      </div>
    </UserDataProvider>
  );

}

export default App;
