import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

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
    <div className="container mx-auto mt-8">
      <div className="max-w-2xl mx-auto bg-white p-8 rounded shadow-lg">
        <h2 className="text-3xl font-bold mb-4">{game.name}</h2>
        <img src={game.coverPath} alt={game.name} className="w-full h-64 object-cover mb-4 rounded" />
        <p className="text-gray-600 mb-4">ID: {game.id}</p>
        <p className="text-gray-800">{game.description}</p>
        <p className="text-gray-800">{game.platform}</p>
        <p className="text-gray-800">{game.releaseDate}</p>
        <p className="text-gray-800">{game.developer}</p>
        <p className="text-gray-800">{game.publisher}</p>
        <input type="b-black" />
        {/* Add other information you want to display */}
      </div>
    </div>
  );
};

export default GameDetail;
