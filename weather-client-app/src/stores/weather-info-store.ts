import { makeAutoObservable, runInAction } from "mobx";
import { ApiClient } from "../api-client/api-client";
import { WeatherInfo } from "../models/models";

export class WeatherInfoStore {

    private _weatherInfo?: WeatherInfo;

    constructor(private _apiClient: ApiClient) {
        makeAutoObservable(this);
    }

    public getWeather=async(countryCode:string)=>{
        const response = await this._apiClient.getWeather(countryCode);
        runInAction(() => {
            this.weatherInfo = response;
        })
    }

    public get weatherInfo(): WeatherInfo | undefined {
        return this._weatherInfo;
    }
    public set weatherInfo(value: WeatherInfo | undefined) {
        this._weatherInfo = value;
    }
}