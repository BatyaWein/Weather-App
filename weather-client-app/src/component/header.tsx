import React, { useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import { useWeatherStore } from '../stores/use-weather-store';
import { Link } from 'react-router-dom';
import { observer } from 'mobx-react-lite';

export const Header = observer(() => {

  const { favoriteStore, authStore } = useWeatherStore();
  useEffect(() => {
    if (authStore.user)
      favoriteStore.getFavoriteAmount();
  }, [authStore.user, favoriteStore])

  return (
    <Navbar expand="lg" variant="light" bg="black">
      <Container>
        <Link to={'/home'}>
          <Navbar.Brand style={{ color: 'orange' }}>Weather App</Navbar.Brand>
        </Link>
        <Link to={'/auth/login'}>
          <Navbar.Brand style={{ color: 'orange' }} >Login</Navbar.Brand>
        </Link>
        {favoriteStore.favoriteAmount && <Navbar.Brand style={{ color: 'orange' }} href="#">You Have {favoriteStore.favoriteAmount} Favorites</Navbar.Brand>}
      </Container>
    </Navbar>
  );
});
