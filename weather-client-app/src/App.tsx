import React, { Fragment } from "react";
import './App.css';
import { HomePage } from './component/home-page';
import { Login } from './component/login';
import {
  BrowserRouter as Router,
  Route,
  Navigate,
  Routes
} from "react-router-dom";
import { Header } from './component/header';
import { useWeatherStore } from "./stores/use-weather-store";

function App() {

  const { routerStore } = useWeatherStore();

  return (
    <div className="App">
      <Router >
        <Header />
        <Fragment>
          <Routes>
            <Route
              path={'/auth/login'}
              element={<Login />}
            />
            <Route
              path={'/home'}
              element={<HomePage />}
            />
            <Route
              path={'*'}
              element={<Navigate to={'/home'} />}
            />
          </Routes>
        </Fragment>
      </Router>
    </div>
  );
}

export default App;
