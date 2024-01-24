import React from 'react'
import axios from 'axios';




const signup = (email, password, username) => {
    return axios.post("https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/Authentication/register", {
        email,
        password,
        username
    })
    
    
    .then((response) => {
        if (response.data.token) {
            localStorage.setItem("user", JSON.stringify(response.data));
        }
        
        
        return response.data;
    });
};


// auth-service.jsx
const login = (email, password) => {
  return axios.post("https://gamesup-ap-dev-tmxp.2.ie-1.fl0.io/Authentication/login", {
    email,
    password
  })
  .then((response) => {
    if (response.data.token) {
      const token = response.data.token;
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
      localStorage.setItem("user", JSON.stringify(response.data));
      console.log("Uzyskano token JWT:", token);
    } else {
      console.error("Nie udało się uzyskać tokena JWT. Brak klucza 'token' w odpowiedzi.");
    }

    return response.data;
  })
  .catch((error) => {
    console.error("Wystąpił błąd podczas logowania:", error);
    throw error;
  });
};

  
    const logout = () => {
        localStorage.removeItem("user");
    };


    const getCurrentUser = () => {
        return JSON.parse(localStorage.getItem("user"));
    };
    
    const authService = {
        signup,
        login,
        logout,
        getCurrentUser,
    };
    
    export default authService;