
  
  import React, { useState, useEffect } from 'react';
  import axios from 'axios';
  import { useParams } from 'react-router-dom';
  import { Fa2 } from "react-icons/fa6";
 
  
  const Video2 = () => {
    const { id } = useParams();
    const [game, setGame] = useState(null);
  
    useEffect(() => {
      const fetchGameDetail = async () => {
        try {
          const response = await axios.get(`https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/Game/5813e83c-d0df-4f9f-8843-b403e560f431`);
          setGame(response.data);
        } catch (error) {
          console.error('Błąd pobierania szczegółów gry:', error);
        }
      };
  
      // Zakładając, że API zwraca dane w oczekiwanej strukturze, możesz usunąć poniższą linijkę
      // i odkomentować poniższą linię, aby skorzystać z przykładowych danych.
      // setGame(sampleData);
  
      fetchGameDetail();
    }, [id]);
  
    if (!game) {
      return <p>Ładowanie...</p>;
    }
  
    return (

      <div className="justify-center flex flex-col my-5 container rounded-lg ">
        <div className='f'>
                    <video
            className="object-cover w-full h-[300px] shadow-lg border-4 border-red-600 rounded-lg border-b-0"
            autoPlay
            loop
            muted
            playsInline
            poster="https://a.ltrbxd.com/resized/sm/upload/8n/h1/ex/59/spider%20verse%20alt-0-1400-0-788-crop.jpg?k=ea71b7d8fc"
            style={{ borderRadius: '40px' }}
        >
            <source
            src="https://a.ltrbxd.com/sm/upload/82/7u/32/3u/1-highestrated-spiderverse.webm?k=bfe5a39d3e"
            type="video/webm"
            />
            <source
            src="https://a.ltrbxd.com/sm/upload/u2/7c/47/cv/1-highestrated-spiderverse.mp4?k=a0cf93e7df"
            type="video/mp4"
            />
        </video>
        <div className=" p-5 flex flex-row-reverse">
            <div className='-mt-[100px]'>
                <img src={game.coverPath} alt={game.name} className="w-[330px] rounded-full" />
            </div>
            <div className='-mt-[50px] px-8'>
            <Fa2 className='text-white bold text-4xl' />
            
        </div>
        
          <div className="p-0 m-0 w-full flex gap-2 flex-col object-cover -mt-[90px] px-8 rounded shadow-lg">
            <h2 className="text-[70px] font-bold mb-4 text-white">{game.name}</h2>
            <p className="text-gray-400 text-2xl">{game.description}</p>
            <div className='flex justify-between'>
                <p className="text-gray-500">{game.platform}</p>
                <p className="text-gray-500">{game.releaseDate}</p>
            </div>
            <div className='flex justify-between'>
                <p className="text-gray-500">{game.developer}</p>
                <p className="text-gray-500">{game.publisher}</p>
            </div>
          </div>

        </div>
        </div>
      </div>
    );
  };
  
  export default Video2;
  