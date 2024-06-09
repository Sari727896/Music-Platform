import {  createStore } from "redux";
import allReducers from './reducers/index';

const store=createStore(
  allReducers,
);

store.getState()
export default store