import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export const Notification = (message) => {

  console.log(message);
  console.log(message);

  const handleNotification = () => {
    toast('Test');
  };

  return (
    <div>
      <button onClick={handleNotification}>Show Notification</button>
    </div>
  );
};
