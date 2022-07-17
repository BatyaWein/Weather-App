

using RestSharp;

namespace WeatherProjectAPI.BL
{
    public interface IWeatherBL
    {
        public IRestResponse SearchLocation(string q);
        public IRestResponse GetWeather(string locationCode);
    };
}
