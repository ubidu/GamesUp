import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { FaHeart, FaRegHeart } from 'react-icons/fa';
import { Link } from 'react-router-dom'; // Dodajemy Link z React Router


const MyComponent = () => {
  const [Games, setGames] = useState([]);
  const [like, setLike] = useState(false);

  useEffect(() => {
    const fetchGames = async () => {
      try {
        const response = await axios.get('http://localhost:5157/Game');
        setGames(response.data);
      } catch (error) {
        console.error('Błąd pobierania gier:', error);
      }
    };

    fetchGames();
  }, []);

  return (
    <div>
      <p className='text-white px-4 py-1'>Trendy</p>
            <hr
  class="mb-12 h-0.5 border-t-0 bg-neutral-500 opacity-100 dark:opacity-50 " />
    <div className='flex flex-wrap justify-center w-full'>
      {Games.map((game) => (
        <Link to={`/game/${game.id}`} key={game.id}>
          <div className=' cursor-pointer w-[286px]  rounded relative m-1 hover:scale-105 transition'>
            <img className='w-full h-full object-cover rounded-md' src={game.coverPath} alt="" />
            <div className='absolute top-0 left-0 w-full h-full hover:bg-black/80 transition-opacity opacity-0 hover:opacity-100 text-white'>
              <p className='white-space-normal text-xs md:text-sm font-bold flex justify-center items-center h-full text-center'>{game.name}</p>
              <p>
                {like ? <FaHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)} /> : <FaRegHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)} />}
              </p>
            </div>
          </div>
        </Link>
      ))}
    </div>
    </div>
  );
};

export default MyComponent;
