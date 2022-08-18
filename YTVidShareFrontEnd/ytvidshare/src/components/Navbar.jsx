import AccountCircleOutlinedIcon from "@mui/icons-material/AccountCircleOutlined";
import React from 'react';
import { Link } from "react-router-dom";
import styled from 'styled-components';
import OnnoRokom from "../img/logo.jpg";
const Container = styled.div`
position:sticky;
top: 0;
height: 66px;
background-color: white;
`;
const Wrapper = styled.div`
display: flex;
  align-items: center;
  justify-content: space-between;
  height: 100%;
  padding: 0px 20px;
  position: relative; 
`;


const Img = styled.img`
  height: 88px;
`;
const User = styled.div`
  display: flex;
  align-items: center;
  gap: 10px;
  font-weight: 500;
  color: ${({ theme }) => theme.text};
`;

const Button = styled.button`
  padding: 5px 15px;
  background-color: transparent;
  border: 1px solid #3ea6ff;
  color: #3ea6ff;
  border-radius: 3px;
  font-weight: 500;
  cursor: pointer;
  display: flex;
  align-items: center;
  gap: 5px;
  justify-content: flex-end;
`;

const Logo = styled.div`
  display: flex;
  align-items: center;
  gap: 5px;
  font-weight: bold;
  margin-bottom: 25px;
  justify-content: flex-start;
  position: relative; 
`;

const Navbar = () => {
    return (
        <Container>
            <Wrapper>
                <Link to="/" style={{ textDecoration: "none", color: "inherit" }}>
                    <Logo>
                        <Img src={OnnoRokom} />
                    </Logo>
                </Link>
                <Button>
                    <AccountCircleOutlinedIcon />
                    SIGN IN
                </Button>
            </Wrapper>
        </Container>
    )
}

export default Navbar