import { combineReducers } from "redux";
import singersReducer from "./reducers/singerReducer";

const allReducers = combineReducers(
    {
        singersReducer:singersReducer,
    }
)
export default allReducers