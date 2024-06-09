import { combineReducers } from "redux";

const allReducers = combineReducers(
    {
        songReducer: songsReducer,
        userReducer: usersReducer,
        playlistReducer: playlistsReducer,
        albumReducer: albumsReducer,
    }
)
export default allReducers