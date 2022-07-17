import React from 'react';
import { useWeatherStore } from '../stores/use-weather-store';
import { Location } from '../models/models';
import { Observer, observer } from 'mobx-react-lite';
import { V2Choice } from '../ui/v2-choice';
import { Option } from '../models/models';


export const AutocompleteField = observer(() => {
    const { locationStore, weatherInfoStore } = useWeatherStore();


    return (
        <div style={{ width: '50%', margin: 'auto' }}>
            <Observer>
                {() => {
                    let options: Array<Option> = [];

                    if (locationStore.loadLocation === false) {
                        locationStore.locationsResult?.forEach((location: Location) => {
                            options.push({
                                label: `${location.LocalizedName}, ${location.Country.LocalizedName}`,
                                value: location.Key,
                            });
                        });
                    }
                    return (
                        <div >
                            <V2Choice
                                //@ts-ignore
                                inputValue={locationStore.querySearch}
                                isLoading={locationStore.loadLocation}
                                value={locationStore.selectedLocation?.value ?? null}
                                placeholder={'Select a location to find the weather'}
                                noOptionsMessage={() => 'No matched location'}
                                options={options}
                                onInputChange={locationStore.searchLocation}
                                onChange={(optionKey: string) => {
                                    locationStore.selectedLocation = options.find((option) => option.value === optionKey);
                                    weatherInfoStore.getWeather(optionKey);
                                }}
                            />
                        </div>
                    );
                }}
            </Observer>
        </div>
    );
});