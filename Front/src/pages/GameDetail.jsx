import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { FaPlaystation } from 'react-icons/fa';
import { FaXbox } from 'react-icons/fa';
import { FaComputer } from 'react-icons/fa6';
import { BsNintendoSwitch } from 'react-icons/bs';
import { RxAvatar } from 'react-icons/rx';
import AuthService from '../services/auth.service';

const GameDetail = () => {
  const { id } = useParams();
  const [game, setGame] = useState(null);
  const [reviewContent, setReviewContent] = useState('');
  const [reviewRating, setReviewRating] = useState(0);
  const [userReviews, setUserReviews] = useState([]);

  useEffect(() => {
    const fetchGameDetail = async () => {
      try {
        const user = AuthService.getCurrentUser();
        const headers = {
          'Content-Type': 'application/json',
        };

        if (user) {
          headers.Authorization = `Bearer ${user.token}`;
        }

        const response = await axios.get(`http://localhost:5157/Game/${id}`, { headers });
        setGame(response.data);
      } catch (error) {
        console.error('Błąd pobierania szczegółów gry:', error);
      }
    };

    fetchGameDetail();
    fetchUserReviews();
  }, [id]);

  const fetchUserReviews = async () => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const response = await axios.get('http://localhost:5157/GetUserReviews', { headers });
      setUserReviews(response.data);
    } catch (error) {
      console.error('Błąd pobierania recenzji użytkownika:', error);
    }
  };

  const handleAddFavorite = async () => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const response = await axios.post('http://localhost:5157/AddFavoriteGame', { gameId: id }, { headers });
      console.log('Gra dodana do ulubionych:', response.data);
    } catch (error) {
      console.error('Błąd dodawania do ulubionych:', error);
    }
  };

  const handleAddCompletedGames = async () => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const response = await axios.post('http://localhost:5157/AddCompletedGame', { gameId: id }, { headers });
      console.log('Gra dodana do ulubionych:', response.data);
    } catch (error) {
      console.error('Błąd dodawania do ulubionych:', error);
    }
  };

  const handleAddGamesToFinish = async () => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const response = await axios.post('http://localhost:5157/AddGameToFinish', { gameId: id }, { headers });
      console.log('Gra dodana do ulubionych:', response.data);
    } catch (error) {
      console.error('Błąd dodawania do ulubionych:', error);
    }
  };
  

  const handleReviewSubmit = async () => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const reviewData = {
        gameId: id,
        content: reviewContent,
        rating: reviewRating,
      };

      const response = await axios.post('http://localhost:5157/AddReview', reviewData, { headers });
      console.log('Recenzja dodana:', response.data);

      fetchUserReviews();
    } catch (error) {
      console.error('Błąd dodawania recenzji:', error);
    }
  };

  const handleReviewDelete = async (reviewId) => {
    try {
      const user = AuthService.getCurrentUser();
      const headers = {
        'Content-Type': 'application/json',
      };

      if (user) {
        headers.Authorization = `Bearer ${user.token}`;
      }

      const response = await axios.delete(`http://localhost:5157/DeleteReview/${reviewId}`, { headers });
      console.log('Recenzja usunięta:', response.data);

      fetchUserReviews();
    } catch (error) {
      console.error('Błąd usuwania recenzji:', error);
    }
  };

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
        <div className='flex justify-center items-center flex-col border-white-600 border-4 rounded-full border-t-0 border-l-0 border-r-0 px-20 py-10'>
        <p className="text-gray-300 mb-4">ID: {game.id}</p>
        <p className="text-gray-300">{game.description}</p>
        <p className="text-gray-300">{game.platform}</p>
        <p className="text-gray-300">{game.releaseDate}</p>
        <p className="text-gray-300">{game.developer}</p>
        <p className="text-gray-300">{game.publisher}</p>
        <button
    className="my-1 list-none bg-gradient px-6 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
    onClick={handleAddFavorite}
    >
    <Link to={"/favorites"} className="text-white">
        Dodaj do ulubionych
      </Link>
    </button>

    <button
    className="my-1 list-none bg-gradient px-6 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
    onClick={handleAddCompletedGames}
    >
    <Link to={"/CompletedgGames"} className="text-white">
        Dodaj do gier ukończonych
      </Link>
    </button>

    <button
    className="my-1 list-none bg-gradient px-6 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
    onClick={handleAddGamesToFinish}
    >
    <Link to={"/GameToFinish"} className="text-white">
        Dodaj do gier które chcesz ukończyć
      </Link>
    </button>

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

      <div className="bg-white p-6 rounded-lg shadow-md container w-full mt-8">
        <h2 className="text-2xl font-bold mb-4">Recenzje użytkownika</h2>
        <div className="mb-4">
          <textarea
            rows="4"
            placeholder="Dodaj swoją recenzję..."
            value={reviewContent}
            onChange={(e) => setReviewContent(e.target.value)}
            className="w-full p-2 border rounded"
          ></textarea>
          <input
            type="number"
            placeholder="Ocena (0-10)"
            value={reviewRating}
            onChange={(e) => setReviewRating(e.target.value)}
            className="w-full p-2 border rounded mt-2"
          />
          <button
            className="bg-blue-500 text-white px-4 py-2 rounded mt-2"
            onClick={handleReviewSubmit}
          >
            Dodaj recenzję
          </button>
        </div>
        <div>
          {userReviews.map((review) => (
            <div key={review.id} className="mb-4">
              <p>{review.content}</p>
              <p>Ocena: {review.rating}</p>
              <button
                className="text-red-500"
                onClick={() => handleReviewDelete(review.id)}
              >
                Usuń recenzję
              </button>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default GameDetail;
