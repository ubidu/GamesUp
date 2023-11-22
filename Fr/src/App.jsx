import { Route, Routes } from 'react-router-dom';
import './App.css';
import AppContent from './components/AppContent';
import Button from './components/Button';
import Navbar from './components/Navbar';
import Home from './pages/Home';


function App() {
  return(
    <>
      <Navbar />
      <Routes>
        <Route path='/' element={<Home />} />
      </Routes>
      <AppContent />
      <Button />
    </>
  );
}


export default App;
