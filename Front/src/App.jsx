import React from 'react';
import { Route, Routes } from 'react-router-dom';
import './App.css';
import AppContent from './components/AppContent';
import Button from './components/Button';
import Navbar from './components/Navbar';
import Home from './pages/Home';
import Login from './pages/Login';
import Register from './pages/SignUp';
import GameDetail from './pages/GameDetail';
import MyComponent from './components/Row';
import Favorites from './components/Favorites';
import SearchResults from "./components/SearchResults"; // Nowy komponent dla wyników wyszukiwania
import CompletedGames from './components/CompletedGames';
import GameToFinish from './components/GameToFinish';

function App() {
  return (
    <>
      <Navbar />
      <Routes>
          <Route path="/search/:query" component={SearchResults} />
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Register />} />
        <Route path='/favorites' element={<Favorites />} />
        <Route path='/CompletedGames' element={<CompletedGames />} />
        <Route path='/GameToFinish' element={<GameToFinish />} />
        <Route path="/games" element={<MyComponent />} />
        <Route path="/game/:id" element={<GameDetail />} />
      </Routes>
      <AppContent />
      <Button />
    </>
  );
}

export default App;
