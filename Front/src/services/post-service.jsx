import axios from 'axios';

const API_URL = 'http://localhost:5157';

const PostService = {
  getFavoriteGames: () => {
    // Assume that you have a token stored after user login
    const token = localStorage.getItem('token'); // Replace with your actual token retrieval logic

    // Set up headers with the authorization token
    const headers = {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`,
    };

    // Make the request to the /GetFavoriteGames endpoint
    return axios.get(`${API_URL}/GetFavoriteGames`, { headers });
  },
};

export default PostService;


