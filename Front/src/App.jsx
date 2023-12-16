import { Route, Routes } from 'react-router-dom';
import './App.css';
import AppContent from './components/AppContent';
import Button from './components/Button';
import Navbar from './components/Navbar';
import Home from './pages/Home';
import Login from './pages/Login';
import Register from './pages/SignUp';


function App() {
  return(
    <>
      <Navbar />
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/login' element={<Login />} />
        <Route path='/Signup' element={<Register />} />
      </Routes>
      <AppContent />
      <Button />
    </>
  );
}


export default App;
