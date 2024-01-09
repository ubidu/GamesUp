import React from 'react'
import axios from 'axios';




const signup = (email, password, username) => {
    return axios.post("http://localhost:5157/Authentication/register", {
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

const login = (email, password) => {
    return axios.post("http://localhost:5157/Authentication/login", {
        email,
        password
    })
    .then((response) => {
        if (response.data.token) {
            axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`;
            localStorage.setItem("user", JSON.stringify(response.data));
        }
        
        
        return response.data;
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