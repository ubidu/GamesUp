import React from 'react'
import logoimage from './Logo.png' 
import { Link } from 'react-router-dom'

const Navbar = () => {
  return (

<div className='flex items-center container justify-between  m-auto left-0 right-0 p-12   z-[100] w-[1000px]' >
        <Link to='/'>
            <img src={logoimage} className='w-[180px] hover:scale-105 transition' alt="" />
        </Link>

        
        <div className='flex items-center'>
        <form className="max-w-sm px-4 hidden sm:block">
            <div className="relative">
                <svg
                    className="absolute top-0 bottom-0 w-6 h-6 my-auto text-white left-3"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                >
                    <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
                    />
                </svg>
                <input
                    type="text"
                    placeholder="Search"
                    className="w-full py-3 pl-12 pr-4 text-gray-100 border-slate-500 border-bottom outline-none bg-transparent focus:border-lightgray"
                />
            </div>
        </form>
            
        <Link to='/login'>
            <button className='text-white pr-4 hover:scale-105 transition'><a href="#">Zaloguj się</a></button>
            </Link>
            <Link to='/register'>
            <button className='bg-gradient px-6 py-2 rounded cursor-pointer text-white hover:scale-105 transition'>Zarejestruj się</button>
            </Link>
        </div>
    </div>

  )
}

export default Navbar