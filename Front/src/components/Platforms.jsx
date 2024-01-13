import React from 'react'
import { FaPlaystation } from "react-icons/fa";
import { FaXbox } from "react-icons/fa";
import { FaComputer } from "react-icons/fa6";
import { BsNintendoSwitch } from "react-icons/bs";

export default function Platforms() {
  return (
    <div className='flex flex-wrap gap-5 container justify-between  p-10 text-white'>

        <div className='flex justify-between gap-3 items-center flex-1 p-4 rounded-full  bg-yellow-600 hover:scale-105 transition cursor-pointer'> 
        <FaComputer className='text-yellow-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex justify-center items-center gap-3 text-lg bold'>
                <h1>Gier</h1>
                <h2 className='text-yellow-600 bg-white p-2 rounded-full bold' >155</h2>
            </div>
        </div>

        <div className='flex justify-between items-center flex-1  p-4 rounded-full  w-full   bg-green-600 hover:scale-105 transition cursor-pointer'>
        <FaXbox className='text-green-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex justify-center items-center gap-3'>
                <h1>Gier</h1>
                <h2 className='text-green-600 bg-white p-2 rounded-full bold'>222</h2>
            </div>
        </div>
        <div className='flex justify-between items-center flex-1 p-4 rounded-full  w-full  bg-blue-600 hover:scale-105 transition cursor-pointer'> 
        <FaPlaystation className='text-blue-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex justify-center items-center gap-3'>
                <h1>Gier</h1>
                <h2 className='text-blue-600 bg-white p-2 rounded-full bol'>182</h2>
            </div>
        </div>

        <div className='flex justify-between items-center flex-1 p-4 rounded-full  w-full  bg-red-600 hover:scale-105 transition cursor-pointer'> 
        <BsNintendoSwitch className='text-red-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex justify-center items-center gap-3'>
                <h1>Gier</h1>
                <h2 className='text-red-600 bg-white p-2 rounded-full bold '>126</h2>
            </div>
        </div>
    </div>
  )
}
