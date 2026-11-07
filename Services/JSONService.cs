using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using HomeControlBlazor.Services;
using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using static System.Net.Mime.MediaTypeNames;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace HomeControlBlazor.Services
{
    public interface IJSONService
    {
        //public Task<IEnumerable<TblElectricity>> LoadRec();

        public List<TblEquipment> GetEquipment();

        public List<TblEquipmentActual> GetEDataEquipment();

        public List<TblEquipmentHistory> GetEquipmentHistoryData(int SensorID, DateTime DateFrom, DateTime DateTo);

        public List<OTEPricing> LoadOTEByDate(DateTime date);

        public List<TblOte> LoadOTEByInterval(DateTime SelectedDate);

        public int getAuthenticatedUser(string Username, string Password);

        public List<TblToDo> getAllToDos();

        public TblToDo getToDoByID(int ID);

        public List<TblSolarPowerSystem> LoadRecSolarSystem(DateTime Date);

        public TblElectricity LoadElectricityLastRec();

        public List<VwvRelayStatus> LoadRelayStatus();

        public List<TblRelay> getRelaysMode();

        public int getRelayMode(int RelayID);

        public bool setRelayMode(int RelayID, int newValue);

        public List<AKUTempHistoryModel> LoadAKUTempHistory(DateTime date, int TimeRange, int Interval);

        //public bool Upload([FromBody] string base64Image);

        public bool createToDo(string tdoName, string? tdoDescription, int? tdoStatus, int? tdoCategory,
            int? tdoPriority, int? tdoReminder, int? tdoReminderInterval, int? tdoReminderSms, int? tdoReminderEmail);

        public List<TblShoppingList> getShoppingList(int Status);

        public string createShoppingListNewItem(string ItemName, string ItemCount, string Username); //, string Image);

        public bool closeShoppingListItem(int RecordID);

        public bool deleteShoppingListItem(int RecordID);

        public Task<string> createShoppingListNewItemByteImg(string ItemName, int ItemCount, string Username, byte[] Image);

        public Task<string> registerMulletHunterUser(string Username, string Email, string Password);

        public Task<string> createNahlasMeNewItemByteImg(string ItemName, int ItemCount, string Username, byte[] Image);

    }

    public class JSONService : IJSONService
    {
        private readonly AppDBContext _context;

        public JSONService(AppDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }

        public ImageModel GetData()
        {
            // Your logic to fetch or create data
            return new ImageModel { Name = "json test", ThumbnailPath = "cesta nahled", Path = "cesta", Type = "img" };
        }

        public List<TblEquipment> GetEquipment()
        {
            return _context.TblEquipments.ToList();
        }

        public List<TblEquipmentActual> GetEDataEquipment()
        //public TblEquipmentActual GetEDataEquipment()
        {
            return _context.TblEquipmentActuals.ToList();
        }

        public List<TblEquipmentHistory> GetEquipmentHistoryData(int SensorID, DateTime DateFrom, DateTime DateTo)
        //public TblEquipmentActual GetEDataEquipment()
        {
            return _context.TblEquipmentHistories.Where(data => data.EquIoTid == SensorID && (data.EquLastUpdate >= DateFrom && data.EquLastUpdate <= DateTo)).ToList();
        }

        #region "OTE"
        public List<OTEPricing> LoadOTEByDate(DateTime date)
        {
            try
            {
                string SQLquery = string.Format("EXECUTE proc_OTETarifCompare '{0}'", date.ToString("yyyy-MM-dd"));
                return _context.OTEPricings.FromSqlRaw(SQLquery).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TblOte> LoadOTEByInterval(DateTime SelectedDate)
        {
            try
            {
                return _context.TblOtes.Where(date => date.OteDate == SelectedDate.Date).OrderBy(hour => hour.OteHour)
                    .OrderBy(interval => interval.OteInterval).ToList(); // id => id.OteId).ToList();
                //string SQLquery = string.Format("EXECUTE proc_OTETarifCompare '{0}'", date.ToString("yyyy-MM-dd"));
                //return _context.OTEPricings.FromSqlRaw(SQLquery).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        public int getAuthenticatedUser(string Username, string Password)
        {
            if (Username == "a" && Password == "b")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        #region "ToDo"
        public List<TblToDo> getAllToDos()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return _context.TblToDos.ToList(); // .OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public TblToDo getToDoByID(int ID)
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return _context.TblToDos.Where(id => id.TdoId == ID).Single(); // .OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();


        }
        public bool createToDo(string tdoName, string? tdoDescription, int? tdoStatus, int? tdoCategory, int? tdoPriority, int? tdoReminder, int? tdoReminderInterval, int? tdoReminderSms, int? tdoReminderEmail)
        {
            try
            {
                var newRecord = new TblToDo
                {
                    TdoName = tdoName,
                    TdoDescription = tdoDescription,
                    TdoStatus = tdoStatus,
                    TdoCategory = tdoCategory,
                    TdoPriority = tdoPriority,
                    TdoReminder = tdoReminder,
                    TdoReminderInterval = tdoReminderInterval,
                    TdoReminderSms = tdoReminderSms,
                    TdoReminderEmail = tdoReminderEmail
                };

                // Here you would typically add code to insert the newRecord into your database
                // For example, using Entity Framework: dbContext.TblToDos.Add(newRecord);
                // dbContext.SaveChanges();
                _context.TblToDos.Add(newRecord);
                _context.SaveChanges();
                return true; // Return the new record, possibly with an updated TdoId if it's auto-generated by the database
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region "FVE"
        public List<TblSolarPowerSystem> LoadRecSolarSystem(DateTime Date)
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return _context.TblSolarPowerSystems.OrderByDescending(id => id.SpsId).Where(datum => datum.SpsDateTime.Date == Date.Date).OrderBy(hour => hour.SpsDateTime.Hour).ToList(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }
        #endregion

        #region "Electricity"
        public TblElectricity LoadElectricityLastRec()
        {
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            return _context.TblElectricities.OrderByDescending(id => id.SelId).FirstOrDefault(); // .Where(datum => datum.SelDateTime.Date == DateTime.Now.Date).OrderBy(hour => hour.SelDateTime.Hour).FirstOrDefault(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }
        #endregion

        #region "Relays"
        public List<VwvRelayStatus> LoadRelayStatus()
        {
            try
            {
                return _context.VwvRelayStatuses.ToList();
                // string SQLquery = "SELECT * FROM vwv_RelayStatus"; // string.Format("EXECUTE proc_HourlyConsumptionWh '{0}'", date.ToString("yyyy-MM-dd"));
                //return await _context.PowerConsumption.FromSqlRaw(SQLquery).ToListAsync();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        public List<TblRelay> getRelaysMode()
        //public TblEquipmentActual GetEDataEquipment()
        {
            return _context.TblRelays.ToList();
        }

        public int getRelayMode(int RelayID)
        {
            return _context.TblRelays.Where(id => id.RlyRelayNr == RelayID).Select(item => item.RlyState).FirstOrDefault();
        }

        public bool setRelayMode(int RelayID, int newValue)
        {
            bool retValue = false;

            try
            {
                var entity = _context.TblRelays.Where(id => id.RlyRelayNr == RelayID).SingleOrDefault(); //.FindAsync(id);
                if (entity != null)
                {
                    entity.RlyState = newValue;
                    _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region "Temp"
        public List<AKUTempHistoryModel> LoadAKUTempHistory(DateTime date, int TimeRange, int Interval)
        {
            try
            {
                string SQLquery = string.Format("EXECUTE proc_GetAKUTempLast24Hours '{0}', -{1}, {2}", date.ToString("yyyy-MM-dd HH:mm:00.000"), TimeRange, Interval);
                return _context.AKUTempHistory.FromSqlRaw(SQLquery).ToList();

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Debugger.Break();
                return null;
            }
        }
        #endregion

        #region "Shopping List"
        public List<TblShoppingList> getShoppingList(int Status)
        {
            switch (Status)
            {
                case 0:
                    // return _context.TblShoppingLists.Where(status => status.ShlStatus == 0).ToList();
                    return _context.TblShoppingLists.Where(status => status.ShlStatus == 0)
                        .Include("TblShoppingListImages").ToList();
                case 1:
                    return _context.TblShoppingLists.Where(status => status.ShlStatus == 1).ToList();
                default:
                    return _context.TblShoppingLists.ToList();
            }
            // return await _context.TblReportMeRecords.Include("TblReportMeDialogs").Include("TblReportMePictures").ToListAsync(); //.Include("tbl_ReportMeRecords").Include("tbl_ReportMeDialog").ToListAsync();
            //return _context.TblShoppingLists.ToList(); // .OrderByDescending(id => id.OteId).Where(datum => datum.OteDate == DateTime.Now.Date).OrderBy(hour => hour.OteHour).ToListAsync(); //.OrderByDescending(id => id.OteId).Take(100);//.ToListAsync();
        }

        public string createShoppingListNewItem(string ItemName, string ItemCount, string Username) //, string Image)
        {
            string SQLquery = string.Empty;

            try
            {
                //TblShoppingList item = new TblShoppingList();
                //item.ShlName = ItemName;
                //item.ShlCount = ItemCount;
                //item.ShlDate = DateTime.Now;
                //item.ShlTime = (DateTime.Now.TimeOfDay);
                //item.ShlStatus = 0;
                //item.ShlDateUpdate = null;
                //item.ShlTimeUpdate = null;

                //item.ShlUser = "pwa";
                int retValue = 0;
                //if (Image == "0")
                //{
                SQLquery = string.Format("INSERT INTO tbl_ShoppingList VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2});",
                    ItemName, Username, ItemCount);
                retValue = _context.Database.ExecuteSqlRaw(SQLquery);
                //}
                //else
                //{
                //    //string query = "INSERT INTO YourTable (BinaryColumn) VALUES (@BinaryData)"

                //    byte[] imageBytes = Convert.FromBase64String(Image);
                //    SQLquery = string.Format ("DECLARE @OutputTable TABLE(ID INT); " +
                //                "--Insert into the first table and capture the IDs " +
                //                "INSERT INTO tbl_ShoppingList " +
                //                "OUTPUT INSERTED.shl_ID INTO @OutputTable " +
                //                "VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2}); " +
                //                "--Insert into the second table using the captured IDs " +
                //                "INSERT INTO tbl_ShoppingListImages " +
                //                "SELECT ID, 1, @BinaryData " +
                //                "FROM @OutputTable;", ItemName, Username, ItemCount );
                //    var parameter = new SqlParameter("@BinaryData", SqlDbType.VarBinary, -1) { Value = imageBytes };
                //    retValue = _context.Database.ExecuteSqlRaw(SQLquery, parameter);
                //}
                //_context.TblShoppingLists.Add(item); // (SQLquery).ToList();               

                return (SQLquery);
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + SQLquery;
            }
        }

        public bool closeShoppingListItem(int RecordID)
        {
            try
            {
                string SQLQuery = string.Format("UPDATE tbl_ShoppingList SET shl_DateUpdate = GETDATE(), shl_TimeUpdate = GETDATE(), shl_Status = 1 WHERE shl_ID = {0};",
                    RecordID);
                int retVaule = _context.Database.ExecuteSqlRaw(SQLQuery);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deleteShoppingListItem(int RecordID)
        {
            try
            {
                string SQLQuery = string.Format("UPDATE tbl_ShoppingList SET shl_DateUpdate = GETDATE(), shl_TimeUpdate = GETDATE(), shl_Status = 2 WHERE shl_ID = {0};",
                    RecordID);
                int retVaule = _context.Database.ExecuteSqlRaw(SQLQuery);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> createShoppingListNewItemByteImg(string ItemName, int ItemCount, string Username, byte[] byteArrayImage)
        {
            try
            {
                //TblShoppingList item = new TblShoppingList();
                //item.ShlName = ItemName;
                //item.ShlCount = ItemCount;
                //item.ShlDate = DateTime.Now;
                //item.ShlTime = (DateTime.Now.TimeOfDay);
                //item.ShlStatus = 0;
                //item.ShlDateUpdate = null;
                //item.ShlTimeUpdate = null;

                //item.ShlUser = "pwa";
                string SQLquery = string.Empty;
                int retValue = 0;
                //if (byteArrayImage == null)
                //{
                //    SQLquery = string.Format("INSERT INTO tbl_ShoppingList VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2});",
                //   ItemName, Username, ItemCount);
                //    retValue = _context.Database.ExecuteSqlRaw(SQLquery);
                //    //retValue = 1;
                //}
                //else
                //{
                // resize image - convert byte array to img
                SixLabors.ImageSharp.Image img = await ConvertByteArrayToImage(byteArrayImage);
                // resize image - resize image to 640x480
                SixLabors.ImageSharp.Image resizedImg = await ResizeImageWithAspectRatio(img, 640, 480);
                // resize image - convert img to byte array
                byte[] imgByteArray = await ConvertImageToByteArray(resizedImg);

                //byte[] imageBytes = Convert.FromBase64String(Image);
                SQLquery = string.Format("DECLARE @OutputTable TABLE(ID INT); " +
                            //"--Insert into the first table and capture the IDs " +
                            "INSERT INTO tbl_ShoppingList " +
                            "OUTPUT INSERTED.shl_ID INTO @OutputTable " +
                            "VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2}); " +
                            //"--Insert into the second table using the captured IDs " +
                            "INSERT INTO tbl_ShoppingListImages " +
                            "SELECT ID, 1, @BinaryData " +
                            "FROM @OutputTable;", ItemName, Username, ItemCount);
                var parameter = new SqlParameter("@BinaryData", SqlDbType.VarBinary, -1) { Value = imgByteArray };
                retValue = _context.Database.ExecuteSqlRaw(SQLquery, parameter);
                //return SQLquery;
                // }
                //_context.TblShoppingLists.Add(item); // (SQLquery).ToList();               

                return (retValue.ToString());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region "Customize image"
        public async Task<SixLabors.ImageSharp.Image> ConvertByteArrayToImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return SixLabors.ImageSharp.Image.Load(ms);
            }
        }

        public async Task<SixLabors.ImageSharp.Image> ResizeImageWithAspectRatio(SixLabors.ImageSharp.Image image, int maxWidth, int maxHeight)
        {
            // Calculate the ratio
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Calculate new dimensions
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Resize the image
            image.Mutate(x => x.Resize(newWidth, newHeight));

            return image;
        }


        public async Task<byte[]> ConvertImageToByteArray(SixLabors.ImageSharp.Image image)
        {
            // Use a MemoryStream to save the image
            using (var ms = new MemoryStream())
            {
                // Specify the image format (PNG in this example)
                var encoder = new PngEncoder();

                // Save the image to the MemoryStream
                image.SaveAsync(ms, encoder);

                // Convert the MemoryStream to a byte array
                byte[] imageBytes = ms.ToArray();

                // Return the Base64 string
                return imageBytes;
            }
        }


        #endregion

        public async Task<string> registerMulletHunterUser(string Username, string Email, string Password) //, string Image)
        {
            string SQLquery = string.Empty;

            try
            {

                int retValue = 0;
                //if (Image == "0")
                //{
                SQLquery = string.Format("INSERT INTO tbl_MulletHunterUsers VALUES ('{0}', '{1}', '{2}', GETDATE());",
                    Username, Email, Password);
                retValue =  _context.Database.ExecuteSqlRaw(SQLquery);


                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + SQLquery;
                //return false;
            }
        }

        #region "NahlasMe"
        public async Task<string> createNahlasMeNewItemByteImg(string ItemName, int ItemCount, string Username, byte[] byteArrayImage)
        {
            try
            {
                //TblShoppingList item = new TblShoppingList();
                //item.ShlName = ItemName;
                //item.ShlCount = ItemCount;
                //item.ShlDate = DateTime.Now;
                //item.ShlTime = (DateTime.Now.TimeOfDay);
                //item.ShlStatus = 0;
                //item.ShlDateUpdate = null;
                //item.ShlTimeUpdate = null;

                //item.ShlUser = "pwa";
                string SQLquery = string.Empty;
                int retValue = 0;
                //if (byteArrayImage == null)
                //{
                //    SQLquery = string.Format("INSERT INTO tbl_ShoppingList VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2});",
                //   ItemName, Username, ItemCount);
                //    retValue = _context.Database.ExecuteSqlRaw(SQLquery);
                //    //retValue = 1;
                //}
                //else
                //{
                // resize image - convert byte array to img
                SixLabors.ImageSharp.Image img = await ConvertByteArrayToImage(byteArrayImage);
                // resize image - resize image to 640x480
                SixLabors.ImageSharp.Image resizedImg = await ResizeImageWithAspectRatio(img, 640, 480);
                // resize image - convert img to byte array
                byte[] imgByteArray = await ConvertImageToByteArray(resizedImg);

                //byte[] imageBytes = Convert.FromBase64String(Image);
                SQLquery = string.Format("DECLARE @OutputTable TABLE(ID INT); " +
                            //"--Insert into the first table and capture the IDs " +
                            "INSERT INTO tbl_ShoppingList " +
                            "OUTPUT INSERTED.shl_ID INTO @OutputTable " +
                            "VALUES ('{0}', '{1}', GETDATE(), GETDATE(), NULL, NULL, 0, {2}); " +
                            //"--Insert into the second table using the captured IDs " +
                            "INSERT INTO tbl_ShoppingListImages " +
                            "SELECT ID, 1, @BinaryData " +
                            "FROM @OutputTable;", ItemName, Username, ItemCount);
                var parameter = new SqlParameter("@BinaryData", SqlDbType.VarBinary, -1) { Value = imgByteArray };
                retValue = _context.Database.ExecuteSqlRaw(SQLquery, parameter);
                //return SQLquery;
                // }
                //_context.TblShoppingLists.Add(item); // (SQLquery).ToList();               

                return (retValue.ToString());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
    //public async Task<bool> saveProdPlan2DB(string SQLQuery)
    //{
    //    try
    //    {
    //        await _context.Database.ExecuteSqlRawAsync(SQLQuery); //  FromSqlRaw("proc_Warehouse1120MastStatus").ToListAsync();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        string er = ex.Message;
    //        return false;
    //    }

    //}

    //public bool Upload([FromBody] string base64Image)
    //{
    //    // Dekódovat Base64 řetězec do byte[]
    //    var imageBytes = Convert.FromBase64String(base64Image);

    //    // Uložit obrázek na serveru (např. do souboru nebo databáze)
    //    System.IO.File.WriteAllBytes("path/to/save/image.jpg", imageBytes);

    //    return true;
    //}


}

