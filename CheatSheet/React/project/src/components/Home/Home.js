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


  const Hero = () => {
    return (
      <div className='hero h-screen bg-bgBlackUI-0'>
        <div className='wrap flex'>
          <div className='bg-blue-950'>
            <svg width="235.95" height="53.207197742164595" viewBox="0 0 370 83.4357413206226" class="css-1j8o68f"><defs id="SvgjsDefs1262"></defs><g id="SvgjsG1263" featurekey="hmhgWD-0" transform="matrix(0.777505174306155,0,0,0.777505174306155,-3.887525871530775,12.371768685634716)" fill="#c4aff0"><path xmlns="http://www.w3.org/2000/svg" d="M95,61.8c-0.4-4.1-1.7-6.7-4.1-8c1.6-1.7,3.7-5.5,3.2-10.4c-0.4-3.9-1.3-5.9-3.4-7.3c1.8-1.9,3.9-5.7,3.4-10.1  c-0.8-7-4.5-8.7-8.4-9.6L50.1,8.6c-0.7-0.1-1.4-0.1-2,0L8.3,17.8c-0.6,0.1-1.1,0.7-1.1,1.3c0,0.6,0.3,1.2,0.9,1.4l6.6,2.5  c0.5,0.7,2.5,4,0.7,6.1l-8.7,3.9c-0.2,0.1-0.4,0.2-0.5,0.4c-0.4,0.3-0.9,0.9-0.9,1.9c0,1.5,0.9,2.1,1.3,2.2l8.9,4.3  c0.3,0.5,1.7,2.6-0.1,4.7l-8.9,3.2c-0.1,0-0.1,0-0.2,0.1C6,49.9,5,50.5,5,52c0,1.6,1,2.1,1.4,2.2c0,0,0,0,0.1,0l0,0l10,5.1  c0.3,0.8,1.2,3.8-0.2,5.5L6.4,69c-0.5,0.2-0.9,0.7-0.9,1.3c0,0.6,0.3,1.1,0.8,1.3L44.6,91c0.6,0.3,1.2,0.4,1.9,0.4  c0.5,0,1.1-0.1,1.6-0.3l40.6-17.7c0.5-0.2,0.9-0.4,1.3-0.8C91.9,71.2,95.4,67,95,61.8z M8.4,19.2c0-0.1,0-0.2,0.2-0.2l39.8-9.2  c0.5-0.1,1-0.1,1.5,0l35.6,7.7c4,0.9,6.9,2.7,7.5,8.6c0.5,4.5-1.9,8.2-3.6,9.6c0,0-2.3,1.8-5.6,3.2c0,0,0,0,0,0l-9.4,3.9  c-0.1-0.5-0.3-1-0.4-1.5l-0.6,0.2l0.6-0.2c-0.1-0.3-0.2-0.7-0.2-1l0-0.1c-0.1-0.4-0.2-0.8-0.2-1.2c0,0,0-0.1,0-0.1l12.4-5  c0,0,4.7-1.7,4.7-7.5c0-1.9-0.5-3.3-1.6-4.3c-1.6-1.4-3.8-1.2-3.9-1.2c0,0-0.1,0-0.1,0L48.1,32.6c-0.6,0.2-1.2,0.3-1.8,0.3  c-0.1-0.1-0.3-0.1-0.5,0c-1,0-2-0.1-2.9-0.5l-34.4-13C8.4,19.4,8.4,19.3,8.4,19.2z M87.2,40c1.4,0.6,2.1,1.9,2.1,3.9  c0,1.2-0.2,2.3-0.6,3.3c-0.9,2.2-2.7,4-5,4.9l-2.8,1.2c0,0,0,0,0,0c-0.2-0.2-0.4-0.4-0.7-0.6c-1.6-1.5-3.8-4.2-5.5-8.8l9.5-4l0,0  c0,0,0,0,0,0C85.2,39.6,86.3,39.6,87.2,40z M65.1,48c0.6,1.6,1.1,3,1.4,4.3c0,0.1,0.9,3.1,3.3,5.7l-22.3,8.8  c-0.2,0.1-0.3,0.1-0.5,0.1c2.6-6.7,1.3-10.2,0.3-11.6c0.3-0.1,0.6-0.2,0.9-0.3L65.1,48z M71.6,58.3c-0.1-0.1-0.3-0.3-0.5-0.4  c0,0,0,0,0,0c0,0,0,0,0,0c-0.1-0.1-0.2-0.3-0.4-0.4l-0.1-0.1c-2.2-2.5-3.1-5.4-3.1-5.4c-0.4-1.4-0.9-3.1-1.6-5  c-0.5-1.2-1.1-2.6-1.7-4c-0.2-0.4-0.4-0.8-0.6-1.2c-1.2-2.4-2.2-4.4-2.7-5.2l8.9-2.9c0,0.1,0.1,0.1,0.1,0.2c2,2.1,2.1,5.2,2.1,5.3  c0,0,0,0.1,0,0.1c0.1,0.4,0.2,0.8,0.3,1.2l0,0.1c0.1,0.4,0.2,0.7,0.3,1c0,0,0,0.1,0,0.1c0.2,0.7,0.4,1.5,0.6,2.1  c1.7,5.1,4.2,8.2,6,9.8c0.3,0.3,0.6,0.5,0.8,0.7l-5.9-0.8c-0.2,0-0.3,0-0.5,0.1c-0.1,0.1-0.2,0.3-0.2,0.4v5.5  c-0.1-0.1-0.2-0.1-0.3-0.2l-0.1-0.1c-0.2-0.1-0.3-0.2-0.5-0.4c-0.1-0.1-0.3-0.2-0.4-0.3l-0.1-0.1C71.9,58.6,71.8,58.5,71.6,58.3  l-0.3,0.5L71.6,58.3z M71.1,33.3l4.4-1.5c0.3-0.1,0.5-0.4,0.4-0.7c-0.1-0.3-0.4-0.5-0.7-0.4l-18.1,6c-0.3,0.1-0.5,0.4-0.4,0.7  c0.1,0.2,0.3,0.4,0.6,0.4c0.1,0,0.1,0,0.2,0l2.5-0.8c0.3,0.5,1.3,2.4,2.5,4.7l-15.2,5.8c3.3-7.4,1.4-11.8,0.1-13.6  c0.4-0.1,0.8-0.2,1.1-0.3l36.7-11.5c0.3,0,1.8-0.1,3,0.9c0.8,0.7,1.2,1.9,1.2,3.4c0,4.9-3.7,6.3-3.9,6.4l-12.2,4.9  C72.9,36.5,72.4,34.8,71.1,33.3z M16.3,29.9c1.8-2,1-4.6,0.2-6.2l26,9.8c1.1,0.4,2.2,0.6,3.4,0.6c0.9,0.9,3.9,5.2-0.2,13.7  c-0.4,0-0.7-0.1-1.1-0.2L12.7,33.7C13.9,32.6,15.9,30.8,16.3,29.9z M7.1,36.5c-0.4-0.1-0.6-0.5-0.6-1.1c0-0.5,0.1-0.8,0.4-1  c0,0,0.1-0.1,0.1-0.1c0,0,0.1-0.1,0.1-0.1l6.4-2.9c-0.7,0.7-1.6,1.5-2.4,2.2C11.1,33.6,11,33.8,11,34c0,0.2,0.2,0.4,0.3,0.5  l32.7,14.3c1,0.4,2.2,0.5,3.2,0.1l15.5-6c0.1,0.2,0.2,0.5,0.3,0.7c0.5,1.2,1,2.3,1.5,3.4l-17,7.1c-1.4,0.6-3,0.5-4.3-0.1l-27.1-13  c0,0,0,0,0,0l-9-4.3C7.2,36.5,7.1,36.5,7.1,36.5z M16.3,47.3c1.4-1.6,1.4-3.3,1-4.7l25.6,12.3c0.9,0.4,1.8,0.6,2.8,0.6  c0.1,0,0.1,0,0.2,0c0.6,0.5,3,3.5-0.1,11.4c-0.2,0-0.4-0.1-0.5-0.2L12.7,51.1C13.9,50.1,15.9,48.2,16.3,47.3z M7,53.2  C6.9,53.2,6.9,53.2,7,53.2c-0.1-0.1-0.1-0.1-0.2-0.1c-0.2-0.1-0.6-0.3-0.6-1.1c0-0.8,0.4-1,0.6-1.1c0,0,0.1,0,0.1,0c0,0,0,0,0.1,0  l7-2.5c-0.8,0.8-1.8,1.7-2.8,2.5C11.1,51,11,51.2,11,51.4c0,0.2,0.1,0.4,0.3,0.5l33.3,16c1,0.4,2.2,0.5,3.2,0.1l22.7-9  c0.1,0.1,0.1,0.1,0.2,0.2l0.1,0.1c0.1,0.1,0.3,0.2,0.4,0.4l0.1,0.1c0.2,0.1,0.3,0.2,0.5,0.4c0,0,0.1,0,0.1,0  c0.2,0.1,0.4,0.3,0.6,0.4l0.1,0.1c0.1,0.1,0.3,0.2,0.5,0.3l0.1,0.1c0.2,0.1,0.4,0.2,0.6,0.3c0.1,0,0.2,0.1,0.2,0.1  c0.1,0,0.2,0,0.3-0.1c0.2-0.1,0.3-0.3,0.3-0.5v-5.8l7.9,1.1c0.3,0,0.5-0.2,0.6-0.4c0.1-0.3-0.1-0.6-0.4-0.7c-0.1-0.1-0.5-0.2-1-0.6  l2.2-0.9c2.6-1.1,4.7-3.1,5.6-5.6c0.5-1.2,0.7-2.5,0.7-3.8c0-3.1-1.5-4.4-2.8-5c-0.2-0.1-0.5-0.2-0.7-0.2c1.3-0.7,2.3-1.4,2.8-1.8  c1.8,1.1,2.8,2.5,3.2,6.6c0.6,5-2.1,8.9-3.3,9.9c0,0,0,0-0.1,0c0,0,0,0-0.1,0.1c0,0,0,0,0,0c0,0-2.5,2.8-4.8,3.7l-8.4,3.5L48.1,72.5  c-1.1,0.5-2.4,0.4-3.5-0.1L7,53.2C7,53.2,7,53.2,7,53.2z M88.1,58.3c1.4,0.6,2.1,1.9,2.1,3.9c0,4.9-3.7,6.3-3.9,6.4L47.8,84.5  c-0.2,0.1-0.5,0.1-0.7,0.2c3.2-5.4,1.4-9.1,0.2-10.8c0.4-0.1,0.9-0.2,1.3-0.4l28.1-11.7l8.4-3.5C86,57.9,87.1,57.9,88.1,58.3z   M17.2,65.6c1.4-1.7,1.1-4,0.7-5.5l26.1,13.3c0.5,0.3,1.1,0.4,1.7,0.5c0.7,0.6,4.1,4.3,0,10.7c-0.1,0-0.2-0.1-0.3-0.1l-31.9-15  C14.8,68.4,16.8,66.5,17.2,65.6z M89.2,71.8c-0.3,0.2-0.7,0.4-1.1,0.6L47.6,90.1c-0.8,0.3-1.7,0.3-2.5-0.1L6.8,70.5  c-0.1-0.1-0.1-0.2-0.1-0.2c0-0.1,0-0.2,0.2-0.2l7.8-3.2c-0.7,0.7-1.7,1.6-2.5,2.3c-0.2,0.1-0.2,0.3-0.2,0.5c0,0.2,0.2,0.4,0.3,0.5  L45,85.6c1,0.4,2.2,0.5,3.2,0.1l38.4-15.9c0,0,4.7-1.7,4.7-7.5c0-3.1-1.5-4.4-2.8-5c-0.4-0.2-0.7-0.3-1.1-0.3  c1.1-0.9,2.1-1.8,2.6-2.3c2.2,1,3.4,3.3,3.8,7.2C94.2,66.8,90.7,70.7,89.2,71.8z"></path></g><g id="SvgjsG1264" featurekey="1RRcwp-0" transform="matrix(2.653022527677519,0,0,2.653022527677519,88.19594450407092,15.88592475757299)" fill="#ffffff"><path d="M8.14 20.22 c-1 0 -1.98 -0.2 -2.9 -0.58 c-0.88 -0.38 -1.68 -0.92 -2.36 -1.6 c-0.7 -0.68 -1.24 -1.48 -1.6 -2.38 c-0.4 -0.92 -0.6 -1.88 -0.6 -2.9 c0 -4.1 3.36 -7.44 7.46 -7.44 c1.16 0 2.32 0.28 3.34 0.8 c1.02 0.5 1.94 1.28 2.62 2.2 l0.32 0.4 l-2.14 1.58 l-0.3 -0.4 c-0.9 -1.22 -2.3 -1.92 -3.84 -1.92 c-2.64 0 -4.8 2.14 -4.8 4.78 c0 2.66 2.16 4.82 4.8 4.82 c1.52 0 2.92 -0.7 3.84 -1.92 l0.3 -0.38 l2.12 1.56 l-0.32 0.4 c-0.7 0.94 -1.58 1.68 -2.62 2.2 c-1.02 0.52 -2.16 0.78 -3.32 0.78 z M24.98 20 l-2.52 0 l0 -4.9 c0 -1.08 -0.86 -1.92 -1.94 -1.92 c-1.04 0 -1.94 0.86 -1.94 1.92 l0 4.9 l-2.5 0 l0 -14.68 l2.5 0 l0 6.18 c0.62 -0.62 1.28 -0.84 1.94 -0.84 c1.2 0 2.32 0.46 3.16 1.28 c0.84 0.86 1.3 1.98 1.3 3.16 l0 4.9 z M31.04 20.22 l-0.02 0 c-0.58 0 -1.18 -0.14 -1.74 -0.4 c-0.52 -0.22 -1 -0.58 -1.44 -1.04 c-0.7 -0.76 -1.12 -1.76 -1.22 -2.8 c-0.02 -0.18 -0.04 -0.36 -0.04 -0.56 c0 -0.4 0.06 -0.82 0.16 -1.24 c0.18 -0.8 0.56 -1.54 1.1 -2.1 c0.4 -0.44 0.86 -0.78 1.44 -1.06 c0.54 -0.26 1.14 -0.38 1.76 -0.38 c0.64 0 1.22 0.12 1.76 0.38 c0.6 0.28 1.08 0.64 1.44 1.06 c0.52 0.56 0.92 1.28 1.12 2.1 c0.1 0.38 0.14 0.78 0.14 1.24 l0 0.46 l-6.72 0 l0.02 0.14 c0.26 1.24 1.2 2.14 2.24 2.14 l0.02 0 c0.58 -0.04 1.22 -0.4 1.6 -0.72 l0.22 -0.18 l1.66 1.44 l-0.3 0.26 c-0.22 0.2 -0.5 0.44 -0.8 0.6 l-0.02 0 c-0.72 0.42 -1.5 0.64 -2.38 0.66 z M31.04 12.719999999999999 c-0.78 0 -1.56 0.54 -1.98 1.38 l-0.08 0.16 l4.14 0 l-0.08 -0.16 c-0.46 -0.86 -1.22 -1.38 -2 -1.38 z M41.519999999999996 20.18 c-1.26 0 -2.46 -0.48 -3.38 -1.38 c-0.9 -0.92 -1.4 -2.12 -1.4 -3.38 s0.5 -2.46 1.4 -3.38 c0.9 -0.9 2.1 -1.38 3.38 -1.38 c0.84 0 1.6 0.3 2.26 0.9 l0.1 0.08 l0 -0.8 l2.42 0 l0 9.16 l-2.42 0 l0 -0.72 l-0.1 0.1 c-0.72 0.7 -1.54 0.8 -2.26 0.8 z M41.519999999999996 13 c-1.28 0 -2.36 1.12 -2.36 2.42 c0 1.32 1.08 2.42 2.36 2.42 s2.36 -1.1 2.36 -2.42 c0 -1.3 -1.08 -2.42 -2.36 -2.42 z M55.05999999999999 20 l-2.4 0 c-0.88 0 -1.7 -0.34 -2.3 -0.94 c-0.62 -0.62 -0.94 -1.42 -0.94 -2.3 l0 -3.8 l-1.28 0 l0 -2.06 l1.28 0 l0 -3.6 l2.38 0 l0 3.6 l2.66 0 l0 2.06 l-2.66 0 l0 3.76 c0 0.5 0.44 0.96 0.88 0.96 l1.74 0 z M62.07999999999999 20.12 c-0.46 0 -0.94 -0.06 -1.44 -0.16 c-1.48 -0.3 -2.92 -1.02 -4.18 -2.12 l-0.38 -0.34 l1.76 -2 l0.38 0.34 c0.92 0.8 1.94 1.34 2.94 1.54 l0.02 0 c0.3 0.06 0.6 0.1 0.9 0.1 c0.5 0 0.96 -0.1 1.34 -0.28 c0.48 -0.2 1.04 -0.64 1.04 -1.46 c0 -0.44 -0.22 -0.78 -0.68 -1.06 c-0.56 -0.34 -1.32 -0.52 -1.86 -0.62 c-0.24 -0.04 -2.28 -0.46 -3.22 -0.98 c-0.62 -0.38 -1.1 -0.86 -1.44 -1.42 c-0.34 -0.58 -0.5 -1.22 -0.5 -1.92 c0 -0.76 0.24 -1.52 0.7 -2.22 c0.44 -0.58 1.04 -1.06 1.76 -1.4 s1.52 -0.52 2.38 -0.52 c0.34 0 0.7 0.04 1.06 0.08 c1.32 0.24 2.62 0.84 3.76 1.8 l0.38 0.32 l-1.7 2.06 l-0.38 -0.32 c-1.3 -1.06 -2.42 -1.3 -3.14 -1.3 c-0.46 0 -0.88 0.1 -1.24 0.26 c-0.56 0.26 -0.92 0.74 -0.92 1.22 c0 0.44 0.16 0.72 0.54 0.98 s0.96 0.46 1.88 0.66 c0.12 0.02 0.28 0.06 0.44 0.1 c0.84 0.16 1.96 0.4 2.74 0.86 c0.68 0.36 1.2 0.86 1.56 1.44 s0.54 1.26 0.54 1.98 c0 0.9 -0.24 1.7 -0.72 2.38 c-0.42 0.58 -1.04 1.08 -1.86 1.48 c-0.7 0.36 -1.48 0.52 -2.46 0.52 z M77.78 20 l-2.52 0 l0 -4.9 c0 -1.08 -0.86 -1.92 -1.94 -1.92 c-1.04 0 -1.94 0.86 -1.94 1.92 l0 4.9 l-2.5 0 l0 -14.68 l2.5 0 l0 6.18 c0.62 -0.62 1.28 -0.84 1.94 -0.84 c1.2 0 2.32 0.46 3.16 1.28 c0.84 0.86 1.3 1.98 1.3 3.16 l0 4.9 z M83.83999999999999 20.22 l-0.02 0 c-0.58 0 -1.18 -0.14 -1.74 -0.4 c-0.52 -0.22 -1 -0.58 -1.44 -1.04 c-0.7 -0.76 -1.12 -1.76 -1.22 -2.8 c-0.02 -0.18 -0.04 -0.36 -0.04 -0.56 c0 -0.4 0.06 -0.82 0.16 -1.24 c0.18 -0.8 0.56 -1.54 1.1 -2.1 c0.4 -0.44 0.86 -0.78 1.44 -1.06 c0.54 -0.26 1.14 -0.38 1.76 -0.38 c0.64 0 1.22 0.12 1.76 0.38 c0.6 0.28 1.08 0.64 1.44 1.06 c0.52 0.56 0.92 1.28 1.12 2.1 c0.1 0.38 0.14 0.78 0.14 1.24 l0 0.46 l-6.72 0 l0.02 0.14 c0.26 1.24 1.2 2.14 2.24 2.14 l0.02 0 c0.58 -0.04 1.22 -0.4 1.6 -0.72 l0.22 -0.18 l1.66 1.44 l-0.3 0.26 c-0.22 0.2 -0.5 0.44 -0.8 0.6 l-0.02 0 c-0.72 0.42 -1.5 0.64 -2.38 0.66 z M83.83999999999999 12.719999999999999 c-0.78 0 -1.56 0.54 -1.98 1.38 l-0.08 0.16 l4.14 0 l-0.08 -0.16 c-0.46 -0.86 -1.22 -1.38 -2 -1.38 z M94.02 20.22 l-0.02 0 c-0.58 0 -1.18 -0.14 -1.74 -0.4 c-0.52 -0.22 -1 -0.58 -1.44 -1.04 c-0.7 -0.76 -1.12 -1.76 -1.22 -2.8 c-0.02 -0.18 -0.04 -0.36 -0.04 -0.56 c0 -0.4 0.06 -0.82 0.16 -1.24 c0.18 -0.8 0.56 -1.54 1.1 -2.1 c0.4 -0.44 0.86 -0.78 1.44 -1.06 c0.54 -0.26 1.14 -0.38 1.76 -0.38 c0.64 0 1.22 0.12 1.76 0.38 c0.6 0.28 1.08 0.64 1.44 1.06 c0.52 0.56 0.92 1.28 1.12 2.1 c0.1 0.38 0.14 0.78 0.14 1.24 l0 0.46 l-6.72 0 l0.02 0.14 c0.26 1.24 1.2 2.14 2.24 2.14 l0.02 0 c0.58 -0.04 1.22 -0.4 1.6 -0.72 l0.22 -0.18 l1.66 1.44 l-0.3 0.26 c-0.22 0.2 -0.5 0.44 -0.8 0.6 l-0.02 0 c-0.72 0.42 -1.5 0.64 -2.38 0.66 z M94.02 12.719999999999999 c-0.78 0 -1.56 0.54 -1.98 1.38 l-0.08 0.16 l4.14 0 l-0.08 -0.16 c-0.46 -0.86 -1.22 -1.38 -2 -1.38 z M106.22 20 l-2.4 0 c-0.88 0 -1.7 -0.34 -2.3 -0.94 c-0.62 -0.62 -0.94 -1.42 -0.94 -2.3 l0 -3.8 l-1.28 0 l0 -2.06 l1.28 0 l0 -3.6 l2.38 0 l0 3.6 l2.66 0 l0 2.06 l-2.66 0 l0 3.76 c0 0.5 0.44 0.96 0.88 0.96 l1.74 0 z"></path></g></svg>
            <img src='' />
          </div>
          <div>
            <div className='bg-red-700'>
              <div className=''>SDADSADAS</div>
            </div>
            <div>

            </div>
          </div>
        </div>
      </div>
    )
  }


  function Welcome() {
    return (
      <div class="container my-24 md:px-6">
        <Hero />
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
