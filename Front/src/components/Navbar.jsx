import { Link } from 'react-router-dom';
import logoimage from '../img/Logo.png' ;
import AuthService from "../services/auth.service";
import { useState, useEffect } from "react";
import SearchBar from './SearchBar';




function Navbar() {
    const [currentUser, setCurrentUser] = useState(undefined);
  
    useEffect(() => {
      const user = AuthService.getCurrentUser();
  
      if (user) {
        setCurrentUser(user);
      }
    }, []);
  
    const logOut = () => {
      AuthService.logout();
    };
  return (

<div className='flex items-center m-0 containernavbar justify-between  left-0 right-0   z-[100] w-[1000px]' >
        <Link to='/'>
            <img src={logoimage} className='w-[180px] hover:scale-105 transition' alt="" />
        </Link>

        
        <div className='flex items-center'>
          <SearchBar/>
         </div>  

            

            
        {currentUser ? (
          <div className="flex justif-center align-center items-center">
            <li className="">
              <a href="/login" className="text-white pr-4 hover:scale-105 transition" onClick={logOut}>
                Logout
              </a>
            </li>

            <li className=''>
            <Link to='/favorites' className='text-white pr-4 hover:scale-105 transition'>
              Favorites
            </Link>
          </li>

          <li className=''>
            <Link to='/CompletedGames' className='text-white pr-4 hover:scale-105 transition'>
              CompletedGames
            </Link>
          </li>

          <li className=''>
            <Link to='/GameToFinish' className='text-white pr-4 hover:scale-105 transition'>
              Gametofinish
            </Link>
          </li>
          </div>
        ) : (
          <div className="flex justif-center align-center items-center">
            <li className="list-none text-white pr-4 hover:scale-105 transition">
              <Link to={"/login"} className="text-white">
                Login
              </Link>
            </li>

            <li className="list-none bg-gradient px-6 py-2 rounded cursor-pointer text-white hover:scale-105 transition">
              <Link to={"/signup"} className="text-white">
                Sign up
              </Link>
            </li>
          </div>
        )}

         </div>

  )
}

export default Navbar