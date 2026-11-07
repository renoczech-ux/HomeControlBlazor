using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Services
{
    public class ElectricityService : IElectricityService
    {

        private readonly AppDBContext _context;


        public ElectricityService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
        public List<TblElectricity> Records { get; set; } = new List<TblElectricity>();
        public List<TblSolarPowerSystem> SolarRecords { get; set; } = new List<TblSolarPowerSystem>();

        public async Task<IEnumerable<TblElectricity>> LoadRec()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblElectricities.OrderByDescending(id => id.SelId).Where(datum => datum.SelDateTime.Date == DateTime.Now.Date).OrderBy(hour => hour.SelDateTime.Hour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public async Task<IEnumerable<TblSolarPowerSystem>> LoadRecSolarSystem()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblSolarPowerSystems.OrderByDescending(id => id.SpsId).Where(datum => datum.SpsDateTime.Date == DateTime.Now.Date).OrderBy(hour => hour.SpsDateTime.Hour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public async Task<IEnumerable<PowerConsumptionModel>> LoadPowerConsumptionByHour(DateTime date)
        {
            try
            {
                string SQLquery = string.Format("EXECUTE proc_HourlyConsumptionWh '{0}'", date.ToString("yyyy-MM-dd"));
                return await _context.PowerConsumption.FromSqlRaw(SQLquery).ToListAsync();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        //[proc_DailyConsumptionWh]
        public async Task<IEnumerable<PowerConsumptionModel>> LoadPowerConsumptionByDay(DateTime date)
        {
            try
            {
                string SQLquery = string.Format("EXECUTE proc_DailyConsumptionWh '{0}'", date.ToString("yyyy-MM-dd"));
                return await _context.PowerConsumption.FromSqlRaw(SQLquery).ToListAsync();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        #region "Electricity providers"
        public async Task<IEnumerable<OTEPricing>> LoadPriceMWhByProvider(DateTime date, string SelectedYear, string Provider, string Distribution, string Tarif, string Breaker)
        {
            try
            {
                string SQLquery = string.Format("exec proc_TestTarifPrice '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", 
                    date.ToString("yyyy-MM-dd"), SelectedYear, Provider, Distribution, Tarif, Breaker );
                return await _context.OTEPricings.FromSqlRaw(SQLquery).ToListAsync();
             

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<OTEPricing>> LoadPriceMWhByProviderResults(List<OTEPricing> bezDodavatele, List<OTEPricing> CEZ, List<OTEPricing> Electree)
        {
            try
            {
                List<OTEPricing> colPricing = new List<OTEPricing>();

                for (int x= 1; x <= 24; x++ )
                {
                    OTEPricing lclPrice = new OTEPricing();
                    lclPrice.OteHour = x;
                    if (bezDodavatele.Count() >0)
                    {
                        lclPrice.OtePriceMWhbezDodavatele = bezDodavatele.Single(hour => hour.OteHour == x).OtePriceMWh;
                    }
                    if (CEZ.Count() > 0)
                    {
                        lclPrice.OtePriceMWhCEZ = CEZ.Single(hour => hour.OteHour == x).OtePriceMWh;
                    }
                    if (Electree.Count() > 0)
                    {
                        lclPrice.OtePriceMWhElectree = Electree.Single(hour => hour.OteHour == x).OtePriceMWh;
                    }
                    colPricing.Add(lclPrice);
                }

                return colPricing.ToArray();

                //string SQLquery = string.Format("exec proc_TestTarifPrice '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'",
                //    date.ToString("yyyy-MM-dd"), SelectedYear, Provider, Distribution, Tarif, Breaker);
                //return await _context.OTEPricings.FromSqlRaw(SQLquery).ToListAsync();


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion
    }
}
