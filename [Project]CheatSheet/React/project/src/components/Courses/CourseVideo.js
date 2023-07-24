import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import YouTube, { YouTubeProps } from 'react-youtube';
import { getVideoId } from '../../api/Requests/videos';

export const CourseVideo = () => {
    const [videoId,setVideoId]=useState();
    const { id } = useParams()
    console.log(id);

    useEffect(()=>{
        getVideoId(id).then((res)=>setVideoId(()=>res.data))
    },[]);
    return (
        <>
            {videoId &&
            <YouTube videoId={videoId} />
            }
        </>
    )
}