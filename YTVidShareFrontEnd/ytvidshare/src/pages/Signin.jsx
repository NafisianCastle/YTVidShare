import { React, useState } from "react";
import styled from "styled-components";
import axios from "../api/axios";
const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: calc(100vh - 56px);
  color: ${({ theme }) => theme.text};
`;

const Wrapper = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  background-color: ${({ theme }) => theme.bgLighter};
  border: 1px solid ${({ theme }) => theme.soft};
  padding: 20px 50px;
  gap: 10px;
`;

const Title = styled.h1`
  font-size: 24px;
`;

const SubTitle = styled.h2`
  font-size: 20px;
  font-weight: 300;
`;

const Input = styled.input`
  border: 1px solid ${({ theme }) => theme.soft};
  border-radius: 3px;
  padding: 10px;
  background-color: transparent;
  width: 100%;
  color: ${({ theme }) => theme.text};
`;

const Button = styled.button`
  border-radius: 3px;
  border: none;
  padding: 10px 20px;
  font-weight: 500;
  cursor: pointer;
  background-color: ${({ theme }) => theme.soft};
  color: ${({ theme }) => theme.textSoft};
`;

const SignIn = () => {
    const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
 
  const handleLogin = async (e) => {
    e.preventDefault();
    const res = await axios.post("https://localhost:44345/api/User/login",{email, password});
    console.log(res);
  };
  const handleRegister = async (e) => {
    e.preventDefault();
  }


  return (
    <Container>
      <Wrapper>
        <Title>Sign in</Title>
        <SubTitle>to continue to OnnoRokom VidShare</SubTitle>
        <Input
          placeholder="Email"
          onChange={(e) => setName(e.target.value)}
        />
        <Input
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
        />
        <Button onClick={handleLogin}>Sign in</Button>
       
       
        <Title>or</Title>
        <Input
          placeholder="username"
          
          onChange={(e) => setName(e.target.value)}
        />
        <Input placeholder="email"  type="email" onChange={(e) => setEmail(e.target.value)} />
        <Input
          type="password"
          placeholder="password"
          
          onChange={(e) => setPassword(e.target.value)}
        />
        <Button onClick={handleRegister}>Sign up</Button>
      </Wrapper>
     
    </Container>
  );
};

export default SignIn;