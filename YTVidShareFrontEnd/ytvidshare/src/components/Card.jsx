
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import styled from 'styled-components';
import { format } from "timeago.js";
const Container = styled.div`
  width: ${(props) => props.type !== "sm" && "360px"};
  margin-bottom: ${(props) => (props.type === "sm" ? "10px" : "45px")};
  cursor: pointer;
  display: ${(props) => props.type === "sm" && "flex"};
  gap: 10px;
`;

const Image = styled.img`
  width: 100%;
  height: ${(props) => (props.type === "sm" ? "120px" : "202px")};
  background-color: #999;
  flex: 1;
`;

const Details = styled.div`
  display: flex;
  margin-top: ${(props) => props.type !== "sm" && "16px"};
  gap: 12px;
  flex: 1;
`;



const Texts = styled.div``;

const Title = styled.h1`
  font-size: 16px;
  font-weight: 500;
  color: ${({ theme }) => theme.text};
`;


const Info = styled.div`
  font-size: 14px;
  color: ${({ theme }) => theme.textSoft};
`;


const Card = ({ video  }) => {
  useEffect(() => {
    
  }, []);
  return (
    <Link to={`/video/${video.videoID}`} style={{ textDecoration: "none" }}>
      <Container >
      <Image
          src={video.thumbnailUrl}
        />
        <Details >
          <Texts>
            <Title>{video.title}</Title>
            <Info>{video.viewCount} views • {format(video.uploadDate)}</Info>
          </Texts>
        </Details>
      </Container>
    </Link>
  )
}

export default Card