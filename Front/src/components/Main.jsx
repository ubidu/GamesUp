import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { v4 as uuidv4 } from 'uuid';

const Main = () => {
  const [Games, setGames] = useState([]);
  const [randomGame, setRandomGame] = useState(null);

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

  useEffect(() => {
    if (Games.length > 0) {
      // Losowo wybierz jedną grę do wyświetlenia
      const randomIndex = Math.floor(Math.random() * Games.length);
      const randomGame = Games[randomIndex];
      setRandomGame(randomGame);
    }
  }, [Games]);

  const truncateString = (str, num) => {
    if (str?.length > num) {
      return str.slice(0, num) + '...';
    } else {
      return str;
    }
  };

  return (
    <div className='rounded-lg h-[300px] lg:h-[400px] m-auto left-0 right-0   text-white w-full container'>
      {randomGame && (
        <div className='relative h-full rounded-lg' key={uuidv4()}>
          <img className='w-full rounded-lg h-full object-cover' src={randomGame.coverPath} alt="" />
          <div className='absolute rounded-lg top-0 left-0 w-full h-full bg-gradient-to-r from-[#000000]'>
            <div className='flex flex-col justify-center items-center h-full'>
              <h1 className='text-3xl md:text-5xl font-bold'>{randomGame.name}</h1>
              <div className='flex mt-4'>
                <button className='bg-gradient px-6 py-2 rounded cursos-pointer text-white hover:scale-105 transition'>Odtwórz</button>
                <button className='bg-gray-800 px-6 py-2 rounded cursos-pointer text-white ml-4 hover:scale-105 transition'>Więcej informacji</button>
              </div>
              <h1 className='text-sm md:text-lg mt-4 max-w-[600px]'>
                {truncateString(randomGame.description, 150)}{randomGame.Description}
              </h1>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Main;
