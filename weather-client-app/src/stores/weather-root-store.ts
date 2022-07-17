import { RouterStore } from '@superwf/mobx-react-router';
import axios from 'axios';
import { ApiClient } from '../api-client/api-client';
import { AuthStore } from './auth-store';
import { FavoriteStore } from './favorite-store';
import { LocationStore } from './location-store';
import { WeatherInfoStore } from './weather-info-store';
import { createBrowserHistory } from 'history'

export class WeatherRootStore {
    private readonly _apiClient = new ApiClient(axios);
    private readonly _browserHistory = createBrowserHistory();

    public readonly routerStore= new RouterStore(this._browserHistory);
    public readonly authStore=new AuthStore(this._apiClient);
    public readonly locationStore=new LocationStore(this._apiClient);
    public readonly weatherInfoStore=new WeatherInfoStore(this._apiClient);
    public readonly favoriteStore=new FavoriteStore(this._apiClient,this.authStore);
}

