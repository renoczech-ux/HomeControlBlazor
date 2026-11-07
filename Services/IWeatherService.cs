using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface IWeatherService
    {
        public Task<IEnumerable<TblWeatherForecast>> LoadRec();
    }
}
