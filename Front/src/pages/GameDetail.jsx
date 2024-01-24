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
import {
  AiFillClockCircle,
  AiOutlineDesktop,
  AiFillSetting,
  AiFillTags,
} from "react-icons/ai";
import { FaGlobe } from 'react-icons/fa';

const GameDetail = () => {
  const { id } = useParams();
  const [game, setGame] = useState(null);
  const [reviewContent, setReviewContent] = useState('');
  const [reviewRating, setReviewRating] = useState(0);
  const [userReviews, setUserReviews] = useState([]);
  const [userId, setUserId] = useState('');

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

        const response = await axios.get(`https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/Game/${id}`, { headers });
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

      const response = await axios.get(`https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/GetGameReviews/${id}`, { headers });
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

      const response = await axios.post('https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/AddFavoriteGame', { gameId: id }, { headers });
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

      const response = await axios.post('https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/AddCompletedGame', { gameId: id }, { headers });
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

      const response = await axios.post('https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/AddGameToFinish', { gameId: id }, { headers });
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
        userId: userId,
      };

      const response = await axios.post('https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/AddReview', reviewData, { headers });
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

      const response = await axios.delete(`https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/DeleteReview/${reviewId}`, { headers });
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
      <div className="text-center max-w-4xl p-3 rounded shadow-lg flex flex-col justify-center items-center">
        <h2 className="text-white bold text-3xl font-bold font-serif mb-4" >{game.name}</h2>
        <img src={game.coverPath} alt={game.name} className="border-white-600 border-4 border-b-0 border-l-0 border-r-0 w-full h-48 object-cover mb-4 rounded-full" />
        <div className='flex flex-row mt-5'>
          <button
          className="max-w-3 mr-3 list-none bg-gradient px-3 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
          onClick={handleAddFavorite}
          >
          <Link to={"/favorites"} className="text-white">
              Dodaj do ulubionych
            </Link>
          </button>
          <button
          className="max-w-3 mr-3 list-none bg-gradient px-3 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
          onClick={handleAddCompletedGames}
          >
          <Link to={"/CompletedgGames"} className="text-white">
              Dodaj do gier ukończonych
            </Link>
          </button>
          <button
          className="max-w-3 list-none bg-gradient px-3 py-2 rounded cursor-pointer text-white hover:scale-105 transition"
          onClick={handleAddGamesToFinish}
          >
          <Link to={"/GameToFinish"} className="text-white">
              Dodaj do gier które chcesz ukończyć
            </Link>
          </button>
        </div>
        <div className='flex flex-col md:flex-row border-white-600 border-4 rounded-full border-t-0 border-l-0 border-r-0 mt-6 px-20 py-10'>
          <div className="font-medium font-mono tracking-wide opacity-90 text-white w-1/2">
          <h4 className="fw-7 bg-gradient-to-br from-red-600 to-purple-500 text-transparent bg-clip-text text-4xl font-extrabold mb-3">
            Szczegóły <span className="text-white text-4xl font-extrabold">Gry</span>
          </h4>
            <div className='text-lg font-medium'>{game.description.split(".").slice(0, 5).join(".").replace(/\./g, ". ")}</div>
          </div>
          <ul className='ml-12'>
            <li className="text-white flex items-center flex-wrap space-x-2 py-3 hover:ease-in-out hover:scale-105 cursor-pointer">
              <div className="item-right flex items-center">
                <span className="flex items-center justify-start overflow-hidden w-8">
                  <AiFillClockCircle size={25} />
                </span>
                <span className="text-uppercase font-bold text-lg">
                  data wydania:
                </span>
              </div>
              <span className="item-right font-normal text-md text-teal-400">
                {game.releaseDate}
              </span>
            </li>

            <li className="text-white flex items-center flex-wrap space-x-2 py-3 hover:ease-in-out hover:scale-105 cursor-pointer">
              <div className="item-right flex items-center">
                <span className="flex items-center justify-start overflow-hidden w-8">
                  <AiOutlineDesktop size={25} />
                </span>
                <span className="text-uppercase font-bold text-lg">
                  platformy:
                </span>
              </div>
              <span className="item-right font-normal text-md text-teal-400">
                {game.platform}
              </span>
            </li>

            <li className="text-white flex items-center flex-wrap space-x-2 py-3 hover:ease-in-out hover:scale-105 cursor-pointer">
              <div className="item-right flex items-center">
                <span className="flex items-center justify-start overflow-hidden w-8">
                  <AiFillSetting size={25} />
                </span>
                <span className="text-uppercase font-bold text-lg">
                  producent:
                </span>
              </div>
              <span className="item-right font-normal text-md text-teal-400">
                {game.developer}
              </span>
            </li>

            <li className="text-white flex items-center flex-wrap space-x-2 py-3 hover:ease-in-out hover:scale-105 cursor-pointer">
              <div className="item-right flex items-center">
                <span className="flex items-center justify-start overflow-hidden w-8">
                  <AiFillTags size={25} />
                </span>
                <span className="text-uppercase font-bold text-lg">
                  gatunek:
                </span>
              </div>
              <span className="item-right font-normal text-md text-teal-400">
                Gry {game.category}
              </span>
            </li>

            <li className="text-white flex items-center flex-wrap space-x-2 py-3 hover:ease-in-out hover:scale-105 cursor-pointer">
              <div className="item-right flex items-center">
                <span className="flex items-center justify-start overflow-hidden w-8">
                  <FaGlobe size={25} />
                </span>
                <span className="text-uppercase font-bold text-lg">
                  wydawca:
                </span>
              </div>
              <span className="item-right font-normal text-md text-teal-400">
                {game.publisher}
              </span>
            </li>
          </ul>
        </div> 
      </div>
      <div className='flex flex-wrap gap-5 items-center justify-center p-8 text-white'>
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

      <div className="bg-zinc-900 p-6 rounded-lg shadow-md container w-full mt-8">
        <h2 className="text-2xl font-extrabold font-serif mb-4 bg-gradient-to-br from-red-600 to-purple-500 text-transparent bg-clip-text">Recenzje użytkownika</h2>
        <div className="mb-4">
        <textarea
          rows="4"
          placeholder="Dodaj swoją recenzję..."
          value={reviewContent}
          onChange={(e) => setReviewContent(e.target.value)}
          className="w-full p-3 border border-gray-300 rounded bg-opacity-90 focus:outline-none focus:ring focus:border-blue-300 resize-none transition duration-300 hover:bg-gray-50"
        ></textarea>

        <input
          type="number"
          placeholder="Ocena (0-10)"
          value={reviewRating}
          onChange={(e) => {
            const newValue = Math.min(Math.max(0, e.target.value), 10);
            setReviewRating(newValue);
          }}
          className="w-full p-3 border border-gray-300 rounded mt-2 focus:outline-none focus:ring focus:border-blue-300 transition duration-300 hover:bg-gray-50"
        />
        <button
          className="text-teal-400 rounded-full text-white px-6 py-3 rounded mt-2 hover:bg-blue-600 focus:outline-none focus:ring focus:border-blue-300 transition duration-300"
          onClick={handleReviewSubmit}
        >
          Dodaj recenzję
        </button>


        </div>
        <div>
          {userReviews.map((review) => (
            <div key={review.id} className="mb-4 flex flex-col gap-5">
              <p className='text-white'>{review.content}</p>
              <p className='text-white'>Ocena: {review.rating}</p>
              <p className='text-white'>Użytkownik: {review.userId}</p>
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
