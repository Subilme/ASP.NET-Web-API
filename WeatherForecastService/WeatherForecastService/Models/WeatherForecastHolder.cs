namespace WeatherForecastService.Models
{
    public class WeatherForecastHolder
    {
        private List<WeatherForecast> _forecasts;

        public WeatherForecastHolder()
        {
            _forecasts = new List<WeatherForecast>();
        }

        public void Add(DateTime date, int temperatureC)
        {
            _forecasts.Add(new WeatherForecast() { Date = date, TemperatureC = temperatureC });
        }

        public bool Update(DateTime date, int temperatureC)
        {
            foreach(var item in _forecasts)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _forecasts.FindAll(item => item.Date >= dateFrom && item.Date <= dateTo);
        }

        public void Delete(DateTime date)
        {
            _forecasts.RemoveAll(item => item.Date == date);
        }
    }
}
