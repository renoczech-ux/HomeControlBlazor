using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface IElectricityService
    {
        public Task<IEnumerable<TblElectricity>> LoadRec();

        public Task<IEnumerable<PowerConsumptionModel>> LoadPowerConsumptionByHour(DateTime date);

        public Task<IEnumerable<PowerConsumptionModel>> LoadPowerConsumptionByDay(DateTime date);

        public Task<IEnumerable<OTEPricing>> LoadPriceMWhByProvider(DateTime date, string SelectedYear, string Provider, string Distribution, string Tarif, string Breaker);

        public Task<IEnumerable<OTEPricing>> LoadPriceMWhByProviderResults(List<OTEPricing> bezDodavatele, List<OTEPricing> CEZ, List<OTEPricing> Electree);

    }
}
