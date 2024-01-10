import React from 'react'
import Main from '../components/Main'
import requests from '../Requests'
import Row from '../components/Row'
import Platforms from '../components/Platforms'

export const Home = () => {
  return (
    <>
      <Main/>
      <Platforms/>
      <Row/>
    </>
  )
}


export default Home
