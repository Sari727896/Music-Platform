import axios from 'axios';
import singer1 from '../images/Avraham Fried.jpg';
// import singer2 from '../images/Benny Friedman.jpg';
// import singer3 from '../images/Beri Weber.jpg';
// import singer4 from '../images/Haim Israel.png';
import singer3 from '../images/Ishy Ribo.jpg';
// import singer6 from '../images/Lipa Shmeltzer.jpg';
import singer7 from '../images/Mordechai Ben David.jpg';
import singer4 from '../images/Mordechai Shapira.jpg';
import singer6 from '../images/Moshe Feld.jpg';
import singer5 from '../images/Moshe Klein.jpeg';
import singer2 from '../images/Naftali Kempe.jpg';
import singer12 from '../images/Shmueli Ungar.jpg';
import singer13 from '../images/Yaakov Shawaki.jpg';

const API_URL = 'https://localhost:7279/api'; // כתובת ה-API שלך

// אובייקט המיפוי של תמונות הזמרים
const singerImages = {
  1: singer1,
  2: singer2,
  3: singer3,
  4: singer4,
  5: singer5,
  6: singer6,
  // 7: singer7,
  // 8: singer8,
  // 9: singer9,
  // 10: singer10,
  // 11: singer11,
  // 12: singer12,
  // 13: singer13,
};

// פונקציה שמביאה את הזמרים ומוסיפה את התמונות המתאימות
export const fetchSingersFromAPI = async () => {
  try {
    debugger
    const response = await axios.get(`${API_URL}/Singers`);
    const singersWithImages = response.data.map((singer) => ({
      ...singer,
      image: singerImages[singer.id] || 'path/to/default/image.jpg', // ברירת מחדל אם אין תמונה מתאימה
    }));
    return singersWithImages;
  } catch (error) {
    throw error;
  }
};
