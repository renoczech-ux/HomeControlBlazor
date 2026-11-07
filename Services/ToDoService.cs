using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Services
{
    public class ToDoService : IToDoService
    {
        private readonly AppDBContext _context;


        public ToDoService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
        public async Task<IEnumerable<TblToDo>> LoadRec()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblToDos.ToListAsync(); // .OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public async Task<TblToDo> LoadRecByID(int ID)
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return await _context.TblToDos.Where(id => id.TdoId == ID).SingleAsync(); // .OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }
    }
}
