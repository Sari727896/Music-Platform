import logo from './logo.svg';
import './App.css';
import { Provider } from 'react-redux';
import store from './redux/store';
import Singers from './components/Singers';
function App() {
  return (
    <div className="App">
      {/* <header className="App-header">
        
      </header> */}
      <Provider store={store}>
        <Singers></Singers>
      </Provider>
    </div>
  );
}

export default App;
