import React from "react";
import { useWeatherStore } from '../stores/use-weather-store';
import { AutocompleteField } from "./autocomplete-field";
import { WeatherInfo } from "./weather-info";
import { observer } from "mobx-react-lite";

export const HomePage = observer(() => {
    const { weatherInfoStore } = useWeatherStore();
    return <div>
        <h1>Weather</h1>
        <AutocompleteField />
        {weatherInfoStore.weatherInfo && <WeatherInfo />}
    </div>
});