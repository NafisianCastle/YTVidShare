import ReplyOutlinedIcon from "@mui/icons-material/ReplyOutlined";
import ThumbDownOffAltOutlinedIcon from "@mui/icons-material/ThumbDownOffAltOutlined";
import ThumbUpOutlinedIcon from "@mui/icons-material/ThumbUpOutlined";
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import styled from "styled-components";
import Card from "../components/Card";

const Container = styled.div`
  display: flex;
  gap: 24px;
`;

const Content = styled.div`
  flex: 5;
`;
const VideoWrapper = styled.div``;

const Title = styled.h1`
  font-size: 18px;
  font-weight: 400;
  margin-top: 20px;
  margin-bottom: 10px;
  color: ${({ theme }) => theme.text};
`;

const Details = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
`;

const Info = styled.span`
  color: ${({ theme }) => theme.textSoft};
`;

const Buttons = styled.div`
  display: flex;
  gap: 20px;
  color: ${({ theme }) => theme.text};
`;

const Button = styled.div`
  display: flex;
  align-items: center;
  gap: 5px;
  cursor: pointer;
`;

const Hr = styled.hr`
  margin: 15px 0px;
  border: 0.5px solid ${({ theme }) => theme.soft};
`;

const Recommendation = styled.div`
  flex: 2;
`;


const Video = () => {
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
      <Content>
        <VideoWrapper>
          <iframe
            width="100%"
            height="720"
            src="https://www.youtube.com/embed/tjfA8HYUYFM"
            title="YouTube video player"
            frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowfullscreen
          ></iframe>
        </VideoWrapper>
        <Title>OnnoRokom Pathshala_Physics_Circuit_Part-02</Title>
        <Details>
          <Info>7,948,154 views • Jun 22, 2022</Info>
          <Buttons>
            <Button>
              <ThumbUpOutlinedIcon /> 123
            </Button>
            <Button>
              <ThumbDownOffAltOutlinedIcon /> 34
            </Button>
            <Button>
              <ReplyOutlinedIcon /> Details
            </Button>
          </Buttons>
        </Details>
        <Hr />
     
        
      </Content>
      <Recommendation>
      {videos.map((video) => (
        <Card key={video.videoID} video={video}/>
      ))}

      {videos.map((video) => (
        <Card key={video.videoID} video={video}/>
      ))}

      {videos.map((video) => (
        <Card key={video.videoID} video={video}/>
      ))}
        {/* <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/>
        <Card type="sm"/> */}
      </Recommendation>
    </Container>
  );
};

export default Video;