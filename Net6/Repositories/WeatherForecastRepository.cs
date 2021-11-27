namespace Net6.Repositories;
class WeatherForecastRepository
{
    public WeatherForecast[] GetAll()
    {
        return Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           50,
           "Hola Hot Reload"
       ))
        .ToArray();
    }
}
