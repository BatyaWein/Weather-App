import { makeAutoObservable, runInAction } from "mobx";
import { ApiClient } from "../api-client/api-client";
import { LoginObject, User } from "../models/models";

export class AuthStore {

    private _user?: User;

    constructor(private _apiClient: ApiClient) {
        makeAutoObservable(this);
        this.loadUser();
    }

    public login = async (form:LoginObject) => {
        const response = await this._apiClient.login(form.email, form.password);
        runInAction(() => {
            this._user = response;
            localStorage.setItem('userId', response.id);
        })
    }

    public loadUser = async () => {
        const userId = localStorage.getItem('userId');
        if (!userId)
            return;
        const response = await this._apiClient.loadUser(userId);
        runInAction(() => {
            this._user = response;
            localStorage.setItem('userId', response.id);
        })
    }


    public get user(): User|undefined {
        return this._user;
    }
}