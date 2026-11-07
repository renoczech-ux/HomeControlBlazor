using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HomeControlBlazor.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly AppDBContext _context;
        public TemperatureService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
 
        public async Task<IEnumerable<TblEquipmentActual>> LoadRec()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblEquipmentActuals.ToListAsync(); // .OrderByDescending(date => date.WfcDate).ToListAsync(); // .OrderByDescending(hour => hour.WfcHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public async Task<IEnumerable<AKUTempHistoryModel>> LoadAKUTempHistory(DateTime date, int TimeRange , int Interval)
        {
            try
            {
                string SQLquery = string.Format("EXECUTE proc_GetAKUTempLast24Hours '{0}', {1}, {2}", date.ToString("yyyy-MM-dd HH:mm:00.000"), TimeRange, Interval);
                return await _context.AKUTempHistory.FromSqlRaw(SQLquery).ToListAsync();
          
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Debugger.Break();
                return null;
            }


        }
    }
}
