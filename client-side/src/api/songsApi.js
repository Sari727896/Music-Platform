import axios from 'axios';

const API_URL = 'https://localhost:7279/api'; 

export const getItems = async () => {
  try {
    const response = await axios.get(`${API_URL}/Songs/api/songs`);
    return response.data;
  } catch (error) {
    console.error('Error fetching items:', error);
    throw error;
  }
};


