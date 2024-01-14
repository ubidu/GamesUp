import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

const SearchBar = () => {
  const [searchQuery, setSearchQuery] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  const navigate = useNavigate();

  const handleSearchChange = (event) => {
    const query = event.target.value;
    setSearchQuery(query);

    // Tutaj możesz wywołać funkcję do pobierania propozycji wyników wyszukiwania
    // np. poprzez wywołanie API lub przeszukanie lokalnej listy gier
    // i ustawienie wyników w stanie setSearchResults([...wyniki wyszukiwania...]);
  };

  const handleResultClick = (result) => {
    // Przekieruj użytkownika do trasy wyników wyszukiwania po kliknięciu w wynik
    navigate(`/game/${result.id}`);
  };

  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      // Przekieruj użytkownika do trasy wyników wyszukiwania po wciśnięciu Enter
      navigate(`/game/${searchQuery}`);
    }
  };

  return (
    <div>


<div className='flex items-center'>
        <form className="max-w-sm px-4 hidden sm:block">
            <div className="relative">
                <svg
                    className="absolute top-0 bottom-0 w-6 h-6 my-auto text-white left-3"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                >
                    <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
                    />
                </svg>
                <input
                    type="text"
                    placeholder="Search..."
                    value={searchQuery}
                    onChange={handleSearchChange}
                    onKeyPress={handleKeyPress}
                    className="w-full py-3 pl-12 pr-4 text-gray-100 border-slate-500 border-bottom outline-none bg-transparent focus:border-lightgray"
                />
            </div>
        </form>
         </div>  
    </div>
  );
};

export default SearchBar;
