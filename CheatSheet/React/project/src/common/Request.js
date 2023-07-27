import { useNavigate } from 'react-router-dom';
import {SuccessfulAlert} from '../components/Helper components/SuccessfulAlert'
import {UnsuccessfulAlert} from '../components/Helper components/UnsuccessfulAlert';


export const GetRequest = (request,id, setState, message) => {
  const requestData = id ? { id } : {};
    request(requestData)
      .then((res) => {
        if (res.status === 200) {
          if (setState) {
            setState(res.data);
          }
          SuccessfulAlert(message);
        } else {
          UnsuccessfulAlert(message);
        }
      })
      .catch((error) => {
        console.error('Error:', error);
        ErrorAlert('An error occurred.');
      });
  };


export const PostRequestAndData=(request,data)=>{
  request(data)
  .then((res)=>{
    if(res.status===200){
      SuccessfulAlert(res.data);
    }else{
      UnsuccessfulAlert(res.data);
    }
  })
}

export const PostRequestWithId=(request,data)=>{
  request(data)
  .then((res)=>{
    if(res.status===200){
      SuccessfulAlert(res.data);
    }else{
      UnsuccessfulAlert(res.data);
    }
  })
}

export const PostRequestWithRedirection=(request,id,url) => {
  const requestData = id ? { id } : {};
  request(requestData)
    .then((res) => {
      if (res.status === 200) {
        if(!url){
          navigate(url);
        }
        SuccessfulAlert(res.data);
      } else {
        UnsuccessfulAlert(res.data);
      }
    })
    .catch((error) => {
      console.error('Error:', error);
      ErrorAlert('An error occurred.');
    });
};