import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import styled from "styled-components";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import SignIn from "./pages/Signin";
import Video from "./pages/Video";
const Container = styled.div`
  display: flex;
`;

const Main = styled.div`
  flex: 7;
  background-color: ${({ theme }) => theme.bg};
`;
const Wrapper = styled.div`
  padding: 22px 96px;
`;

function App() {
  // const { currentUser } = useSelector((state) => state.user);
  return (
    <Container>
      <Router>
        <Main>
          <Navbar />
          <Wrapper>
            <Routes>
              <Route path="/">
                <Route index element={<Home />} />
                <Route path="video">
                  <Route path=":id" element={<Video />} />
                </Route>
                <Route
                    path="signin"
                    element={ <SignIn />}
                  />
              </Route>
            </Routes>
          </Wrapper>
        </Main>

      </Router>
    </Container>

  );
}

export default App;
