import React from 'react'
import MouseIcon from './Logo.png' // replace with actual path
import XboxIcon from './Logo.png' // replace with actual path
import PS5Icon from './Logo.png' // replace with actual path

export default function Platforms() {
  return (
    <div className='flex container justify-between  p-10 text-white'>
        <div className='w-full flex rounded-lg pb-10 pt-10  mr-3 bg-gradient hover:scale-105 transition cursor-pointer'>
            <img src={MouseIcon} alt="Mouse Icon" className='sm:w-[150px] w-[80px]'/>
            <div className='md:display-none'>
                <h1>Games</h1>
                <h2>View</h2>
            </div>
        </div>
        <div className='flex rounded-lg pb-10 pt-10 w-full  mr-3 bg-gradient hover:scale-105 transition cursor-pointer'>
            <img src={XboxIcon} alt="Xbox Controller Icon" className='sm:w-[150px] w-[80px]'/>
            <div clas>
                <h1>Xbox</h1>
                <h2>View</h2>
            </div>
        </div>
        <div className='flex rounded-lg pb-10 pt-10 w-full  bg-gradient hover:scale-105 transition cursor-pointer'> 
            <img src={PS5Icon} alt="PS5 Icon" className='sm:w-[150px] w-[80px]'/>
            <div>
                <h1>PS5</h1>
                <h2>View</h2>
            </div>
        </div>
    </div>
  )
}
