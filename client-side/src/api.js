import axios from 'axios';

const API_URL = 'https://localhost:7279'; 

export const getData = async () => {
  try {
    const response = await axios.get(`${API_URL}/api/Songs/api/songs`);
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};