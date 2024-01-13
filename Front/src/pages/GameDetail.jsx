import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { FaPlaystation } from "react-icons/fa";
import { FaXbox } from "react-icons/fa";
import { FaComputer } from "react-icons/fa6";
import { BsNintendoSwitch } from "react-icons/bs";
import { RxAvatar } from "react-icons/rx";



const GameDetail = () => {
  const { id } = useParams();
  const [game, setGame] = useState(null);

  useEffect(() => {
    const fetchGameDetail = async () => {
      try {
        const response = await axios.get(`http://localhost:5157/Game/${id}`);
        setGame(response.data);
      } catch (error) {
        console.error('Błąd pobierania szczegółów gry:', error);
      }
    };

    fetchGameDetail();
  }, [id]);

  if (!game) {
    return <p>Ładowanie...</p>;
  }

  return (
    <div>
    <div className="container flex justify-center">
      <div className="text-center max-w-2xl p-8 rounded shadow-lg flex flex-col justify-center items-center">
        <h2 className="text-white bold text-3xl font-bold mb-4" >{game.name}</h2>
        <img src={game.coverPath} alt={game.name} className="border-white-600 border-4 border-b-0 border-l-0 border-r-0 w-full h-48 object-cover mb-4 rounded-full" />
        {/* Add other information you want to display */}
        <div className='flex flex-col border-white-600 border-4 rounded-full border-t-0 border-l-0 border-r-0 px-20 py-10'>
        <p className="text-gray-300 mb-4">ID: {game.id}</p>
        <p className="text-gray-300">{game.description}</p>
        <p className="text-gray-300">{game.platform}</p>
        <p className="text-gray-300">{game.releaseDate}</p>
        <p className="text-gray-300">{game.developer}</p>
        <p className="text-gray-300">{game.publisher}</p>
        </div>
      </div>
      <div className='flex flex-wrap gap-5 items-center justify-center p-10 text-white'>

        <div className='flex flex-col h-[400px]  justify-between gap-3 items-center  p-4 rounded-full  bg-yellow-600 hover:scale-105 transition cursor-pointer'> 
        <FaComputer className='text-yellow-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex flex-col justify-center items-center gap-3 text-lg bold'>
                <h1>Wysok</h1>
                <h2 className='animate-growUpBlock h-[180px] w-10 bg-white rounded-full'></h2>
            </div>
        </div>

        <div className='flex flex-col h-[400px] justify-between items-center  p-4 rounded-full    bg-green-600 hover:scale-105 transition cursor-pointer'>
        <FaXbox className='text-green-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex flex-col justify-center items-center gap-3'>
                <h1>B.Wyso</h1>
                <h2 className='animate-growUpBlock h-[250px] w-10 bg-white rounded-full'></h2>
            </div>
        </div>
        <div className='flex flex-col h-[400px] justify-between items-center p-4 rounded-full  bg-blue-600 hover:scale-105 transition cursor-pointer'> 
        <FaPlaystation className='text-blue-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex flex-col justify-center items-center gap-3'>
                <h1>B.Wyso</h1>
                <h2 className='animate-growUpBlock h-[250px] w-10 bg-white rounded-full'></h2>
            </div>
        </div>

        <div className='flex flex-col h-[400px] justify-between items-center p-4 rounded-full  bg-red-600 hover:scale-105 transition cursor-pointer'> 
        <BsNintendoSwitch className='text-red-600 bg-white p-2 rounded-full bold text-[50px]' />
            <div className='flex flex-col justify-center items-center gap-3'>
                <h1>niskie</h1>
                <h2 className='animate-growUpBlock h-[100px] w-10 bg-white rounded-full'></h2>
            </div>
        </div>
  </div>


    </div>
    <div className="bg-white p-6 rounded-lg shadow-md container w-full">
  <div className="flex items-center mb-4">
  <RxAvatar className='text-[80px]' />
    <span className="font-bold text-lg">Nick Użytkownika</span>
  </div>
  <p className="text-gray-700">Treść opinii użytkownika...</p>
</div>

    </div>
  );
};

export default GameDetail;
