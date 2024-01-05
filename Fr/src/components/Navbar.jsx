import React from 'react'

const Navbar = () => {
  return (
    <div className='flex items-center justify-between p-4 z-[100] w-full absolute' >
        <h1 className='text-blue-600 text-2xl font-bold cursor-pointer'>GamesUp</h1>
        <div>
            <button className='text-white pr-4'>Zaloguj się</button>
            <button className='bg-blue-600 px-6 py-2 rounded cursos-pointer text-white'>Zarejestruj się</button>
        </div>
    </div>
  )
}

export default Navbar