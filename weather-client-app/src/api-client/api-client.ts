import axios, { AxiosStatic } from "axios";
import { User, WeatherInfo, Favorite, Location } from "../models/models";

export class ApiClient {
    private readonly URL = {
        USER: '/api/User',
        WEATHER: '/api/Weather',
        FAVORITE: '/api/Favorite'
    }

    constructor(private client: AxiosStatic = axios) {
        axios.interceptors.request.use(async (config) => {
            config.baseURL = process.env.REACT_APP_API_HOST;
            config.headers = {
                'Content-Type': 'application/json',
                'accept': ' */*',
                ...config.headers,
            };
            return config;
        });
        axios.interceptors.response.use(
            (response) => response,
            (error) => {
                if (error.message === 'Network Error') {
                    alert(error.message);
                } else {
                    const { status } = error.response;
                    if (status === 500) {
                        alert('Internal Server Error');
                    }
                    if (status === 400) {
                        alert(error.title);
                    }
                    if (status === 404) {
                        alert('Not Found');
                    }
                }
                return Promise.reject(error);
            }
        );
    }

    public login(email: string, password: string) {
        return this.client
            .post<User>(
                `${this.URL.USER}/login`,
                { email, password },
            )
            .then((response) => response.data);
    }

    public loadUser(id: string) {
        return this.client
            .get<User>(
                `${this.URL.USER}/${id}`,
            )
            .then((response) => response.data);
    }

    public searchLocation(query: string) {
        return this.client
            .get<Location[]>(
                `${this.URL.WEATHER}/SearchLocation`,
                { params: { q: query } },
            )
            .then((response) => response.data);
    }

    public getWeather(countryCode: string) {
        return this.client
            .get<WeatherInfo[]>(
                `${this.URL.WEATHER}/${countryCode}`,
            )
            .then((response) => response.data[0]);
    }

    public addToFavorite(favorite: Favorite) {
        return this.client
            .post<Favorite>(this.URL.FAVORITE, favorite)
            .then((response) => response.data);
    }

    public getFavoriteAmount(userId:string){
        return this.client
            .get<number>(`${this.URL.FAVORITE}/GetFavoriteAmount/${userId}`)
            .then((response) => response.data);
    }
}