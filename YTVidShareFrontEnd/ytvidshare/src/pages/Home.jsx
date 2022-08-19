import axios from 'axios'
import React, { useEffect } from 'react'
import styled from 'styled-components'
import Card from '../components/Card'
const Container = styled.div`
    display:flex;
    justify-content:space-between;
    flex-wrap:wrap;
`

const Home = () => {
    useEffect(() => {
      axios.get('/video').then((response) => {
        console.log(response.data);
      })
    
    }, [])
    
    return (
        <Container>
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