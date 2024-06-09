import React, { useEffect, useState } from 'react';
import { getItems } from '../songsApi';

export default function Songs() {

    const [items, setItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                debugger
                const result = await getItems();
                setItems(result);
            } catch (error) {
                console.error('Error fetching items:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div>
              
            <h1>Songs</h1>
            <ul>
          
                {items.map(item => (
                 
                    <li key={item.id}>{item.name}</li>
                ))}
            </ul>
        </div>
    );
}
