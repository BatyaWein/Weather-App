import { makeAutoObservable, runInAction } from "mobx";
import { ApiClient } from "../api-client/api-client";
import { Option, Location } from "../models/models";

export class LocationStore {
    private _locationsResult: Location[] = [];
    private _loadLocation?: boolean;
    private _selectedLocation: Option | undefined;
    private _querySearch: string = '';


    constructor(
        private _apiClient: ApiClient,
    ) {
        makeAutoObservable(this);
    }


    public searchLocation = async (query: string) => {
        if (!query || query === '')
            return
        this._querySearch = query;
        this._loadLocation = true;
        const response = await this._apiClient.searchLocation(query);
        runInAction(() => {
            this._locationsResult = response;
            this._loadLocation = false;
        })
    }

    public get locationsResult(): Location[] {
        return this._locationsResult;
    }
    public set locationsResult(value: Location[]) {
        this._locationsResult = [...value];
    }

    public get loadLocation(): boolean | undefined {
        return this._loadLocation;
    }

    public get selectedLocation(): Option | undefined {
        return this._selectedLocation;
    }
    public set selectedLocation(value: Option | undefined) {
        this._selectedLocation = value;
    }

    public get querySearch(): string {
        return this._querySearch;
    }
    public set querySearch(value: string) {
        this._querySearch = value;
    }
}