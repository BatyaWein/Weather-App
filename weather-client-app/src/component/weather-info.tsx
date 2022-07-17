import React from 'react'
import { observer } from 'mobx-react-lite';
import { assert } from 'ts-essentials';
import { css } from '@emotion/css';
import { useToggle } from 'react-use';
import { useNavigate } from 'react-router-dom'
import { useWeatherStore } from '../stores/use-weather-store';

export const WeatherInfo = observer(() => {

    const { favoriteStore, weatherInfoStore, locationStore, authStore } = useWeatherStore();
    const [isFavorite, setIsFavorite] = useToggle(false);
    const history = useNavigate();

    assert(weatherInfoStore.weatherInfo);

    return <div className={css`border: 1px solid;
    margin: 30px;
    padding: 30px;
    border-radius: 35px;`}>
        <div>
            <h3>Location:   {locationStore.selectedLocation?.label}</h3>
            <div>Add to favorite:
                <label>
                    <input checked={isFavorite} onChange={() => {
                        if(isFavorite){
                            alert('This Location already exists in favorites');
                            return;
                        }
                        if (!authStore.user) {
                            alert('Login first')
                            history('/auth/login');
                            return;
                        }
                        assert(locationStore.selectedLocation);
                        favoriteStore.addToFavorite(locationStore.selectedLocation.value)
                        setIsFavorite(true)
                    }} type="checkbox" />
                    <span>
                        <i className={isFavorite ? 'mdi mdi-star' : 'mdi mdi-star-outline'} />
                    </span>
                </label>
            </div>
        </div>
        <h4>Weather Info For {(new Date(weatherInfoStore.weatherInfo.DateTime)).toLocaleString()}  </h4>
        <h5>Description:</h5>
        <div>
            {weatherInfoStore.weatherInfo.HasPrecipitation ? 'Precipitation ' : 'Not Precipitation '}
            {weatherInfoStore.weatherInfo.IconPhrase}
            {weatherInfoStore.weatherInfo.IsDaylight ? 'Daylight' : 'Without daylight'}
            <div>
                PrecipitationProbability:{weatherInfoStore.weatherInfo.PrecipitationProbability}
            </div>
            <div> Temperature:{Object.entries(weatherInfoStore.weatherInfo.Temperature).map(
                ([key, val]) => (
                    <span key={key}>{key}: {val}</span>
                )
            )}
            </div>
            <div> For Details:
                <a href={weatherInfoStore.weatherInfo.Link} rel="noreferrer" target="_blank">{weatherInfoStore.weatherInfo.Link}</a>
            </div>
        </div>
    </div>
});
