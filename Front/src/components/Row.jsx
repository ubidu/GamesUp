import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {FaHeart, FaRegHeart} from 'react-icons/fa';

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
    <div className='flex flex-wrap justify-center w-full'>
      {Games.map((game) => (
        <div className='h-[200px] w-[150px] cursor-pointer  rounded-md relative m-1 hover:scale-105 transition' key={game.id}>
          <img className='w-full h-full object-cover rounded-md' src={game.coverPath} alt="" />
          <div  className='absolute top-0 left-0 w-full h-full hover:bg-black/80 transition-opacity opacity-0 hover:opacity-100 text-white'>
            <p className='white-space-normal text-xs md:text-sm font-bold flex justify-center items-center h-full text-center'>{game.name}</p>
            <p>
              {like ? <FaHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)}/> : <FaRegHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)}/> }
            </p>
          </div>
        </div>
))}
    </div>




 /*     <h2>Lista gier:</h2>
      <ul className='flex justi'>
        {Games.map((game) => (




          <div className='text-white' key={game.id}>
            <img src={game.coverPath} alt="" />
            <strong>{game.name}</strong> - ID: {game.id}
          </div>
          
        ))}
      </ul>
    </>
*/
  );
};

export default MyComponent;