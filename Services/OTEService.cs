using Microsoft.EntityFrameworkCore;
using HomeControlBlazor.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace HomeControlBlazor.Services
{
    public class OTEService : IOTEService
    {
        private readonly IDbContextFactory<AppDBContext> _dbFactory;

        public OTEService(IDbContextFactory<AppDBContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<TblOte> Records { get; set; } = new();
        public List<OTEPricing> OTEPricings { get; set; } = new();

        public async Task<List<TblOte>> Get()
        {
            await using var ctx = await _dbFactory.CreateDbContextAsync();
            return await ctx.TblOtes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TblOte>> LoadRec()
        {
            await using var ctx = await _dbFactory.CreateDbContextAsync();
            var today = DateTime.Today;

            return await ctx.TblOtes
                .AsNoTracking()
                .Where(x => x.OteDate == today)
                .OrderBy(x => x.OteHour)
                .ToListAsync();
        }

        public async Task<IEnumerable<TblOte>> LoadRecByDate(DateTime date)
        {
            await using var ctx = await _dbFactory.CreateDbContextAsync();
            var d = date.Date;

            return await ctx.TblOtes
                .AsNoTracking()
                .Where(x => x.OteDate == d)
                .OrderBy(x => x.OteHour)
                .ToListAsync();
        }

        public async Task<IEnumerable<OTEPricing>> LoadOTEByDate(DateTime date)
        {
            try
            {
                await using var ctx = await _dbFactory.CreateDbContextAsync();

                // Parametr pro SP (očekávej @DateFrom DATE/DATEIME v proc_OTETarifCompare)
                var p = new SqlParameter("@DateFrom", date.Date);

                var list = await ctx.OTEPricings
                    .FromSqlInterpolated($"EXEC proc_OTETarifCompare {p}")
                    .AsNoTracking()
                    .ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[OTEService] LoadOTEByDate error: {ex}");
                // neházej dál, vrať prázdno -> UI se nezhroutí
                return Enumerable.Empty<OTEPricing>();
            }
        }

        // Pokud helper potřebuješ, sjednoceně přes factory + interpolated
        public async Task<List<OTEPricing>> FindStudentsFromSqlRaw(DateTime searchFor)
        {
            await using var ctx = await _dbFactory.CreateDbContextAsync();
            var p = new SqlParameter("@searchFor", searchFor.Date);

            return await ctx.OTEPricings
                .FromSqlInterpolated($"EXEC proc_OTETarifCompare {p}")
                .AsNoTracking()
                .ToListAsync();
        }

        // Pouze ukázka – neměnit běh
        public FormattableString FormattableStringExample(DateTime date)
            => $"EXEC proc_OTETarifCompare '{date:yyyy-MM-dd}'";
    }
}

//using Microsoft.EntityFrameworkCore;
//using HomeControlBlazor.Models;
//using HomeControlBlazor.Services;
//using System.Diagnostics;
//using Microsoft.Data.SqlClient;
//using System.Collections.Generic;
//using System;
//using System.Linq.Dynamic.Core;

//namespace HomeControlBlazor.Services
//{


//    public class OTEService : IOTEService
//    {
//        private readonly AppDBContext _context;


//        public OTEService(AppDBContext context)
//        {
//            _context = context;
//            _context.Database.EnsureCreated();

//        }
//        public List<TblOte> Records { get; set; } = new List<TblOte>();
//        public List<OTEPricing> OTEPricings { get; set; } = new List<OTEPricing>();

//        public async Task<List<TblOte>> Get()
//        {
//            return await _context.TblOtes.ToListAsync();
//        }

//        public async Task<IEnumerable<TblOte>> LoadRec()
//        {
//            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
//            return await _context.TblOtes.OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
//        }

//        public async Task<IEnumerable<TblOte>> LoadRecByDate(DateTime date)
//        {
//            return await _context.TblOtes.OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == date.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();

//        }

//        public async Task<IEnumerable<OTEPricing>> LoadOTEByDate(DateTime date)
//        {
//            try {
//                string SQLquery = string.Format("EXECUTE proc_OTETarifCompare '{0}'", date.ToString("yyyy-MM-dd"));
//                return await _context.OTEPricings.FromSqlRaw(SQLquery).ToListAsync();
//                /*

//                // Add a new OTEPricing entity
//                //var otePricing = new OTEPricing
//                //{
//                //    OteDate = DateTime.Now,
//                //    OteHour = 0,
//                //    OtePrice = 0,
//                //    OteExchangeRate = 0,
//                //    OtePriceMWh = 0
//                //};

//                DateTime dte = new DateTime(2023, 10, 31);
//                if (date.Day == DateTime.Now.Day)
//                {
//                    dte = new DateTime(2023, 10, 30);
//                }
//                else
//                {
//                    dte = date.Date;
//                }
//                //return await _context.OTEPricings.FromSqlRaw("EXECUTE proc_OTETarifCompare {0}", date.ToString("yyyy-MM-dd")).ToListAsync();
//                string SQLquery = string.Format("EXECUTE proc_OTETarifCompare '{0}'", dte.ToString("yyyy-MM-dd"));

//                //var otepricing = await _context.OTEPricings.FromSqlRaw(SQLquery).ToListAsync(); // "EXECUTE proc_OTETarifCompare {0}", date.ToString("yyyy-MM-dd")).ToListAsync();

//                //List<OTEPricing> otepricing = await _context.OTEPricings.FromSqlRaw(SQLquery).ToListAsync(); // "EXECUTE proc_OTETarifCompare {0}", date.ToString("yyyy-MM-dd")).ToListAsync();
//                FormattableString formString = FormattableStringExample(date);
//                //var otepricing = _context.OTEPricings.FromSql(formString).ToList();
//                //await _context!.Database.ExecuteSqlRaw(SQLquery).

//                //return null; // otepricing.ToList();
//                // _context.OTEPricings.Add(otePricing);

//                // List<OTEPricing> list;
//                //// string sql = "EXEC SalesLT.Product_GetAll";
//                // list = _context.OTEPricings.FromSqlRaw<OTEPricing>(SQLquery).ToList();
//                // Debugger.Break();
//                // return list;
//                List<OTEPricing> xx = new List<OTEPricing>();
//                //xx = FindStudentsFromSqlRaw(_context, date);
//                //Debugger.Break();

//                //int records = _context.OTEPricings.Local.Count();
//                //if (records > 0)
//                //{
//                //    var allOTEPricings = await _context.OTEPricings.Local.ToDynamicListAsync();
//                //    // _context.OTEPricings.Local.Remove

//                //    foreach (var otePricing in allOTEPricings)
//                //    {
//                //        _context.OTEPricings.Local.Remove(otePricing);
//                //    }
//                //}

//                //var CustCDs = CustCD;
//                //var CustNames = CustName;
//                //SqlParameter param1 = new SqlParameter("@DateFrom", date.ToString("yyyy-MM-dd"));
//                //SqlParameter param2 = new SqlParameter("@CustName", CustName);

//                Debugger.Break();
//               // var baf = _context.Database.SqlQueryRaw<List<OTEPricing>>(SQLquery).ToList();
//                xx = _context.OTEPricings.FromSqlRaw(SQLquery).ToList(); //EXECUTE dbo.proc_OTETarifCompare @DateFrom", param1).ToList();
//                return xx;
//                */
//            }
//            catch(Exception ex)
//            {
//                string err = ex.Message;
//                Debugger.Break();
//                return null;
//            }


//        }

//        public static List<OTEPricing>? FindStudentsFromSqlRaw(AppDBContext context, DateTime searchFor)
//        {
//            return context?.OTEPricings?.FromSqlRaw("EXECUTE proc_OTETarifCompare '@searchFor'",
//                new SqlParameter("@searchFor", searchFor.ToString("yyyy-MM-dd"))).ToList();

//            //return context?.OTEPricings?.FromSqlRaw("EXECUTE proc_OTETarifCompare '2023-10-31'").ToList();

//        }

//        public FormattableString FormattableStringExample( DateTime date)
//        {
//            //string SQLquery = string.Format("EXECUTE proc_OTETarifCompare '{0}'", date.ToString("yyyy-MM-dd"));
//            return $"EXECUTE proc_OTETarifCompare '{date.ToString("yyyy-MM-dd")}'";
//        }

//        //List<OTEPricing> u = new List<OTEPricing>();

//        //var result = _context.OTEPricings
//        //    .FromSqlRaw("EXECUTE proc_OTETarifCompare {0}", day.ToString("yyyy-MM-dd"))
//        //    .ToArray();

//        //u = result.ToList();

//        //return u;
//        //}

//        //public async Task<ToDo> Get(int id)
//        //{
//        //    var toDo = await _context.ToDoList.FindAsync(id);
//        //    return toDo;
//        //}

//        //public async Task<ToDo> Add(ToDo toDo)
//        //{
//        //    _context.ToDoList.Add(toDo);
//        //    await _context.SaveChangesAsync();
//        //    return toDo;
//        //}

//        //public async Task<ToDo> Update(ToDo toDo)
//        //{
//        //    _context.Entry(toDo).State = EntityState.Modified;
//        //    await _context.SaveChangesAsync();
//        //    return toDo;
//        //}

//        //public async Task<ToDo> Delete(int id)
//        //{
//        //    var toDo = await _context.ToDoList.FindAsync(id);
//        //    _context.ToDoList.Remove(toDo);
//        //    await _context.SaveChangesAsync();
//        //    return toDo;
//        //}
//    }
//}

