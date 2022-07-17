using AutoMapper;
using RestSharp;
using System.Threading.Tasks;
using WeatherProjectAPI.DL;


namespace WeatherProjectAPI.BL
{
    public class WeatherBL : IWeatherBL
    {
        private readonly string _baseUrl = "http://dataservice.accuweather.com";
        private readonly string _apiKey = "nRd7nu3zSZ0SKprhJgZzZtgVxH9r6Qtw";
        private readonly IMapper _mapper;
        public WeatherBL( IMapper mapper)
        {
            _mapper = mapper;
        }
        public  IRestResponse SearchLocation(string q)
        {
            var client = new RestClient($"{_baseUrl}/locations/v1/cities/autocomplete?apikey={_apiKey}&q={q}")
            {
                ThrowOnAnyError = true,
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetWeather(string locationCode)
        {
            var client = new RestClient($"{_baseUrl}/forecasts/v1/hourly/1hour/{locationCode}?apikey={_apiKey}")
            {
                ThrowOnAnyError = true,
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
