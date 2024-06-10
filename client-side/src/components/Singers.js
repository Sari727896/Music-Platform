import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchSingers } from '../redux/actions/singerAction';

const style = {
  borderRadius: '50%',
  width: '160px',
  height: '160px',
  objectFit: 'cover',
  marginRight: '10px',
};

const gridContainerStyle = {
  display: 'grid',
  gridTemplateColumns: 'repeat(auto-fit, minmax(150px, 1fr))',
  gap: '20px',
  justifyContent: 'center',
};

const itemStyle = {
  textAlign: 'center',
};

export default function Singers() {
  const dispatch = useDispatch();
  const singers = useSelector((state) => state.singersReducer.singers); // Ensure correct state path

  useEffect(() => {
    dispatch(fetchSingers());
  }, [dispatch]);

  if (!Array.isArray(singers)) {
    return <p>Loading...</p>; // Handle non-array state
  }

  return (
    <div>
      <h1>Singers</h1>
      <div style={gridContainerStyle}>
        {singers.map((singer) => (
          <div key={singer.id} style={itemStyle}>
            <img src={singer.image} style={style} alt={singer.firstName} />
            <h3>{singer.firstName} {singer.lastName}</h3>
          </div>
        ))}
      </div>
    </div>
  );
}
