using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Services
{
    public class FVEService : IFVEService
    {
        private readonly AppDBContext _context;


        public FVEService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
      
        //public List<TblSolarPowerSystem> SolarRecords { get; set; } = new List<TblSolarPowerSystem>();
        //public List<TblPvforecast> PVForecastRecords { get; set; } = new List<TblPvforecast>();

        public async Task<IEnumerable<TblPvforecast>> LoadPVForecastRecords(DateTime Date)
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblPvforecasts.OrderByDescending(id => id.PvfId).Where(datum => datum.PvfDate.Date == Date.Date).OrderBy(hour => hour.PvfTime).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public async Task<IEnumerable<TblSolarPowerSystem>> LoadRecSolarSystem(DateTime Date)
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblSolarPowerSystems.OrderByDescending(id => id.SpsId).Where(datum => datum.SpsDateTime.Date == Date.Date).OrderBy(hour => hour.SpsDateTime.Hour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }
    }
}

