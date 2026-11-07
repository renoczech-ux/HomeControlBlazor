using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface ITemperatureService
    {
        public Task<IEnumerable<TblEquipmentActual>> LoadRec();

        public Task<IEnumerable<AKUTempHistoryModel>> LoadAKUTempHistory(DateTime date, int TimeRange , int Interval);

    }
}
