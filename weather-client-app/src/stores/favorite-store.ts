import { makeAutoObservable, runInAction } from "mobx";
import { ApiClient } from "../api-client/api-client";
import { Favorite } from "../models/models";
import { v4 as uuid } from 'uuid';
import { AuthStore } from "./auth-store";
import { assert } from "ts-essentials";

export class FavoriteStore {

    private _favorites: Favorite[] = [];
    private _favoriteAmount: number = 0;


    constructor(private _apiClient: ApiClient, private _authStore: AuthStore) {
        makeAutoObservable(this);
    }


    public addToFavorite = async (countryCode: string) => {
        assert(this._authStore.user);
        const newFavorite: Favorite = {
            Id: uuid(),
            UserId: this._authStore.user.id,
            CityCode: countryCode,
        }
        const response: Favorite = await this._apiClient.addToFavorite(newFavorite);
        runInAction(() => {
            this._favorites.push(response);
        })
    }

    public getFavoriteAmount = async () => {
        assert(this._authStore.user);
        if (!this._authStore.user.id)
            return;
        const response: number = await this._apiClient.getFavoriteAmount(this._authStore.user.id);
        runInAction(() => {
            this._favoriteAmount = response;
        })

    }

    public get favoriteAmount(): number {
        return this._favoriteAmount;
    }
}