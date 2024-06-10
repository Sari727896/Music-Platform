import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchSingers } from '../redux/actions/singerAction';
const style = {
  borderRadius:'50%',
  width: '100px', // אתה יכול לשנות את זה לפי הצורך שלך
  height: '100px', // אתה יכול לשנות את זה לפי הצורך שלך
  objectFit: 'cover', // לשמור על יחס הממדים של התמונה
  marginRight: '10px', // רווח בין התמונה לטקסט
};

export default function Singers() {
  const dispatch = useDispatch();
  const singers = useSelector((state) => state.singersReducer.singers); // Ensure correct state path
  // debugger

  useEffect(() => {
    dispatch(fetchSingers());
  }, [dispatch]);

  if (!Array.isArray(singers)) {
    return <p>Loading...</p>; // Handle non-array state
  }

  return (
    
    <div>
      <h1>Singers</h1>
      <ul>
        {singers.map((singer) => (
          <li key={singer.id}>
            <img src={singer.image}  style={style} alt={singer.firstName} />
            <h3> {singer.firstName} {singer.lastName}</h3>
          </li>
        ))}
      </ul>
    </div>
  );
}
