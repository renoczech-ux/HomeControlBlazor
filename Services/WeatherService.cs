using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly AppDBContext _context;
        public WeatherService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
        //public async Task<List<TblWeatherForecast>> Get()
        //{
        //    return await _context.TblWeatherForecasts.ToListAsync();
        //}

        public async Task<IEnumerable<TblWeatherForecast>> LoadRec()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblWeatherForecasts.OrderByDescending(id => id.WfcId).Take(24).ToListAsync(); // .OrderByDescending(date => date.WfcDate).ToListAsync(); // .OrderByDescending(hour => hour.WfcHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }
    }
}
