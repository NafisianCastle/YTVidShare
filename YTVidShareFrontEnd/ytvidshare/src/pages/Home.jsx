import axios from 'axios'
import React, { useEffect, useState } from 'react'
import styled from 'styled-components'
import Card from '../components/Card'
const Container = styled.div`
    display:flex;
    justify-content:space-between;
    flex-wrap:wrap;
`

const Home = () => {
  const [videos, setVideos] = useState([]);
  useEffect(() => {
    const fetchVideos = async () => {
      const res = await axios.get('https://localhost:44345/api/video');
      console.log(res.data);
      setVideos(res.data);
    };
    fetchVideos();
  }, []);

  return (
    <Container>
      {videos.map((video) => (
        <Card key={video.videoID} video={video} />
      ))}

    </Container>
  )
}

export default Home