import { createStore, applyMiddleware } from 'redux';
import {thunk} from 'redux-thunk'; // ייבוא נכון
import allReducers from '../redux/index';

const store = createStore(
  allReducers,
  applyMiddleware(thunk) // הוספת thunk כ-middleWare
);

store.getState();
export default store;
