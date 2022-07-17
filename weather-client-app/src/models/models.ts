
export type User = {
    id: string,
    name: string,
    email: string,
    password: string
}

export type LoginObject = { email: string, password: string };

export type Location = {
    Version: number,
    Key: string,
    Type: string,
    Rank: number,
    LocalizedName: string,
    Country: {
        ID: string,
        LocalizedName: string
    },
    AdministrativeArea: {
        ID: string,
        LocalizedName: string
    }
}

export type WeatherInfo = {
    DateTime: string,
    EpochDateTime: number,
    weatherIcon: number,
    IconPhrase: string,
    HasPrecipitation: boolean,
    IsDaylight: boolean,
    Temperature: {
        Value: number,
        Unit: string,
        UnitType: number
    },
    PrecipitationProbability: number,
    MobileLink: string,
    Link: string
}

export type Favorite = {
    Id: string,
    UserId: string,
    CityCode: string
}

export type Option = { label: string; value: string };