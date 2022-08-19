import axios from 'axios'
import React, { useEffect, useState } from 'react'
import styled from 'styled-components'
import Card from '../components/Card'
const Container = styled.div`
    display:flex;
    justify-content:space-between;
    flex-wrap:wrap;
`

const Home = ({type}) => {
    const [videos, setVideos] = useState([]);
    useEffect(() => {
        const fetchVideos = async () => {
          const res = await axios.get(`/videos/${type}`);
          console.log(res.data);
          setVideos(res.data);
        };
        fetchVideos();
      }, [type]);
    
    return (
        <Container>
        {videos.map((video) => (
        <Card key={video._id} video={video}/>
      ))}
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            <Card />
            
            
        </Container>
    )
}

export default Home