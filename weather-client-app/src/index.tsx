import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { StoreContext } from './stores/use-weather-store';
import { WeatherRootStore } from './stores/weather-root-store';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const rootStore = new WeatherRootStore();

root.render(
  <React.StrictMode>
    <StoreContext.Provider value={rootStore}>
      <App />
    </StoreContext.Provider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
