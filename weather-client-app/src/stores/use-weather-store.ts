import { createContext, useContext } from 'react';
import { assert } from 'ts-essentials';
import { WeatherRootStore } from './weather-root-store';

export const StoreContext = createContext<WeatherRootStore | null>(null);

export const useWeatherStore = () => {
  const context = useContext(StoreContext);
  assert(context);
  return context;
};