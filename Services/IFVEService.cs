using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface IFVEService
    {
        public Task<IEnumerable<TblSolarPowerSystem>> LoadRecSolarSystem(DateTime Date);

        public Task<IEnumerable<TblPvforecast>> LoadPVForecastRecords(DateTime Date);
    }
}
