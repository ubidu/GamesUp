import React, { useEffect, useState } from 'react';
import axios from 'axios';
import AuthService from '../services/auth.service';
import { FaHeart, FaRegHeart } from 'react-icons/fa';
import { Link } from 'react-router-dom'; // Dodajemy Link z React Router

const Favorites = () => {
  const [favoriteGames, setFavoriteGames] = useState([]);
  const [error, setError] = useState(null);
  const [detailedGames, setDetailedGames] = useState([]);
  const [like, setLike] = useState(false);

  useEffect(() => {
    const fetchFavoriteGames = async () => {
      try {
        const user = AuthService.getCurrentUser();

        if (user) {
          const token = user.token;

          const config = {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          };

          const response = await axios.get('http://localhost:5157/GetFavoriteGames', config);
          setFavoriteGames(response.data);
        }
      } catch (error) {
        console.error('Error fetching favorite games:', error);
        setError(error.message || 'An error occurred while fetching favorite games.');
      }
    };

    fetchFavoriteGames();
  }, []);

  useEffect(() => {
    const fetchDetailedGames = async () => {
      try {
        const detailedGamesData = await Promise.all(
          favoriteGames.map(async (gameId) => {
            const response = await axios.get(`http://localhost:5157/Game/${gameId}`);
            return response.data;
          })
        );

        setDetailedGames(detailedGamesData);
      } catch (error) {
        console.error('Error fetching detailed game information:', error);
      }
    };

    if (favoriteGames.length > 0) {
      fetchDetailedGames();
    }
  }, [favoriteGames]);

  console.log('detailedGames:', detailedGames);

  return (
    <div >
      <h2>Your Favorite Games</h2>
      {error && <p>Error: {error}</p>}
      <ul className='flex flex-wrap justify-center w-full'>
        {detailedGames.map((game) => (
          <li  key={game.id}>
            <Link to={`/game/${game.id}`} key={game.id}>
              <div className='h-[200px] w-[150px] cursor-pointer  rounded-md relative m-1 hover:scale-105 transition'>
                <img className='w-full h-full object-cover rounded-md' src={game.coverPath} alt="" />
                <div className='absolute top-0 left-0 w-full h-full hover:bg-black/80 transition-opacity opacity-0 hover:opacity-100 text-white'>
                  <p className='white-space-normal text-xs md:text-sm font-bold flex justify-center items-center h-full text-center'>{game.name}</p>
                </div>
                <p>
                    {like ? <FaHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)} /> : <FaRegHeart className='text-red-500 absolute top-1 right-1' onClick={() => setLike(!like)} />}
                  </p>
              </div>
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Favorites;
