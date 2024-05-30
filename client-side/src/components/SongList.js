import React, { useEffect, useState } from 'react';
import { getData } from '../api';

const SongList = () => {
    const [songs, setSongs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchSongs = async () => {
            try {
                const data = await getData();
                setSongs(data);
                setLoading(false);
            } catch (err) {
                setError('Error fetching songs');
                setLoading(false);
            }
        };

        fetchSongs();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div>
            <h2>All Songs</h2>
            {songs.length > 0 ? (
                <ul>
                    {songs.map((song) => (
                        <li key={song.id}>
                            {song.title} - {song.artist}
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No songs available</p>
            )}
        </div>
    );
};

export default SongList;
