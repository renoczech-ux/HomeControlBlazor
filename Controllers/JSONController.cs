using HomeControlBlazor.Models;
using HomeControlBlazor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DataController : ControllerBase
{
    private readonly IJSONService jsonservice;

    public DataController(IJSONService _jsonservice)
    {
        jsonservice = _jsonservice;
    }

    //[HttpGet]
    //public ActionResult<ImageModel> Get()
    //{
    //    var data = jsonservice.GetData();
    //    return Ok(data);
    //}
    [HttpGet("readEquipment")]
    public ActionResult<List<TblEquipment>> GetEquipment()
    {
        var data = jsonservice.GetEquipment();
        string test = string.Empty;
        return Ok(data);
    }

    [HttpGet("readEquipmentActual")]
    public ActionResult<List<TblEquipmentActual>> Get()
    {
        var data = jsonservice.GetEDataEquipment();
        string test = string.Empty;
        return Ok(data);
    }
  
    //public List<TblEquipmentHistory> GetEquipmentHistoryData(int SensorID, DateTime DateFrom, DateTime DateTo)
    [HttpGet("loadEquipmentHistoryDataByDate/{snsID:int}~{datefrom:datetime}~{dateto:datetime}")]
    public ActionResult<List<TblEquipmentHistory>> LoadOTEByDate(int snsID, DateTime datefrom, DateTime dateto)
    {
        var data = jsonservice.GetEquipmentHistoryData(snsID, datefrom, dateto);
        return Ok(data);
    }

    #region "OTE"
    [HttpGet("loadOTEByDate/{reqdate:datetime}")]
    public ActionResult<List<OTEPricing>> LoadOTEByDate(DateTime reqdate)
    {
        var data = jsonservice.LoadOTEByDate(reqdate);
        return Ok(data);
    }

    [HttpGet("loadOTEByInterval/{reqdate:datetime}")]
    public ActionResult<List<TblOte>> LoadOTEByInterval(DateTime reqdate)
    {
        var data = jsonservice.LoadOTEByInterval(reqdate);
        return Ok(data);
    }
    #endregion

    [HttpGet("getAuthenticatedUser/{user}~{pwd}")]
    public ActionResult<string> getAuthenticatedUser(string user, string pwd)
    {
        int RelayMode = jsonservice.getAuthenticatedUser(user, pwd);
        if (RelayMode == 1)
        {
            return Ok("1"); // Ok(RelayMode);
        }
        else if (RelayMode == 0)
        {
            return Ok("0"); //BadRequest(RelayMode);
        }
        else
        {
            return BadRequest();
        }

    }

    #region "ToDo"
    [HttpGet("getAllToDos")]
    public ActionResult<List<TblToDo>> getAllToDos()
    {
        var data = jsonservice.getAllToDos();
        string test = string.Empty;
        return Ok(data);
    }

    [HttpGet("getToDoByID/{ID:int}")]
    public ActionResult<TblToDo> getToDoByID(int ID)
    {
        var data = jsonservice.getToDoByID(ID);
        return Ok(data);

    }

    [HttpGet("getToDoByID/{tdoName}~{tdoDescription}~{tdoStatus:int}~{tdoCategory:int}~{tdoPriority:int}~{tdoReminder:int}" +
        "~{tdoReminderInterval:int}~{tdoReminderSms:int}~{tdoReminderEmail:int}")]
    public ActionResult<bool> createToDo(string tdoName, string? tdoDescription, int? tdoStatus, int? tdoCategory, int? tdoPriority,
          int? tdoReminder, int? tdoReminderInterval, int? tdoReminderSms, int? tdoReminderEmail)
    {
        //  public bool createToDo(string tdoName, string? tdoDescription, int? tdoStatus, int? tdoCategory, int? tdoPriority,
        //  int? tdoReminder, int? tdoReminderInterval, int? tdoReminderSms, int? tdoReminderEmail)

        var data = jsonservice.createToDo(tdoName, tdoDescription, tdoStatus, tdoCategory, tdoPriority,
           tdoReminder, tdoReminderInterval, tdoReminderSms, tdoReminderEmail);
        return Ok(data);
    }

    #endregion

    #region "FVE"
    //LoadRecSolarSystem
    [HttpGet("LoadRecSolarSystem/{reqdate:datetime}")]
    public ActionResult<List<TblSolarPowerSystem>> LoadRecSolarSystem(DateTime reqdate)
    {
        var data = jsonservice.LoadRecSolarSystem(reqdate);
        return Ok(data);
    }
    #endregion

    #region "Electricity"
    //LoadElectricityLastRec
    [HttpGet("LoadElectricityLastRec")]
    public ActionResult<TblElectricity> LoadElectricityLastRec()
    {
        var data = jsonservice.LoadElectricityLastRec();
        return Ok(data);

    }
    #endregion

    #region "Relays"
    [HttpGet("LoadRelayStatus")]
    public ActionResult<List<VwvRelayStatus>> LoadRelayStatus()
    {
        var data = jsonservice.LoadRelayStatus();
        //string test = string.Empty;
        return Ok(data);

    }

    [HttpGet("getRelaysMode")]
    public ActionResult<List<TblRelay>> getRelaysMode()
    {
        var data = jsonservice.getRelaysMode();
        string test = string.Empty;
        return Ok(data);
    }


    [HttpGet("getRelayMode/{id:int}")]
    public IActionResult getRelaysMode(int id)
    {
        int RelayMode = jsonservice.getRelayMode(id);
        return Ok(RelayMode);
    }

    [HttpGet("setRelayMode/{id:int}/{status:int}")]
    public IActionResult setRelayMode(int id, int status)
    {
        bool RelayMode = jsonservice.setRelayMode(id, status);
        return Ok(RelayMode);
    }
    #endregion

    #region "Temp"
    //loadAKUTempHistory/2024~02~08~09~30~2~30
    [HttpGet("loadAKUTempHistory/{year:int}~{month:int}~{day:int}~{hour:int}~{minute:int}~{TimeRange:int}~{Interval:int}")]
    public ActionResult<List<TblEquipmentHistory>> LoadAKUTempHistory(int year, int month, int day, int hour, int minute, int TimeRange, int Interval)
    {
        DateTime dateTime = new DateTime(year, month, day, hour, minute, 00);
        var data = jsonservice.LoadAKUTempHistory(dateTime, TimeRange, Interval);
        return Ok(data);
    }
    #endregion

    #region "Shopping list"
    //[HttpGet("uploadImage/{image:int}~{month:int}~{day:int}~{hour:int}~{minute:int}~{TimeRange:int}~{Interval:int}")]
    //public bool Upload([FromBody] string base64Image)
    //{

    //}

    [HttpGet("getShoppingList/{Status:int}")]
    public ActionResult<List<TblShoppingList>> getShoppingList(int Status)
    {
        var data = jsonservice.getShoppingList(Status);
        string test = string.Empty;
        return Ok(data);
    }

    // public bool createShoppingListNewItem(string ItemName, int ItemCount)
    [HttpGet("createShoppingListNewItem/{ItemName}~{ItemCount}~{Username}")]
    public ActionResult<string> createShoppingListNewItem(string ItemName, string ItemCount, string Username) //, string Image)
    {
        var data = jsonservice.createShoppingListNewItem(ItemName, ItemCount, Username); //, Image);
        return Ok(data);
    }

    // public bool closeShoppingListItem(int RecordID)
    [HttpGet("closeShoppingListItem/{RecordID:int}")]
    public ActionResult<bool> closeShoppingListItem(int RecordID)
    {
        var data = jsonservice.closeShoppingListItem(RecordID);
        string test = string.Empty;
        return Ok(data);
    }
    //deleteShoppingListItem
    [HttpGet("deleteShoppingListItem/{RecordID:int}")]
    public ActionResult<bool> deleteShoppingListItem(int RecordID)
    {
        var data = jsonservice.deleteShoppingListItem(RecordID);
        string test = string.Empty;
        return Ok(data);
    }

    [HttpPost("UploadBinaryData")]
    public async Task<IActionResult> UploadBinaryData()
    {
        using (var ms = new MemoryStream())
        {
            await Request.Body.CopyToAsync(ms);
            var fileBytes = ms.ToArray();
            // Process the binary data here (e.g., save to a file or database)

            return Ok("Binary data received successfully.");
        }
    }

    [HttpPost("UploadBinaryDataImg")]
    public async Task<IActionResult> UploadBinaryDataImg()
    {
        try
        {
            // Check if the request contains multipart/form-data.
            if (!Request.HasFormContentType)
            {
                return BadRequest("Not a multipart/form-data request");
            }

            var formCollection = await Request.ReadFormAsync();
            var files = formCollection.Files;
            var ItemName = formCollection["ItemName"];
            var Username = formCollection["Username"];
            //return Ok("form collection looks fine");

            // Read the additional 'count' parameter from the form data
            var countString = formCollection["ItemCount"];
            if (!int.TryParse(countString, out int count))
            {
                return BadRequest("Invalid count value");
            }
            //return Ok("int count looks fine");
            string retValueSQL = "-1";

            if (files.Count == 0)
            {
                //return BadRequest("No files uploaded");
                retValueSQL = await jsonservice.createShoppingListNewItemByteImg(ItemName, count, Username, null);
            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Process each file here
                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            var fileBytes = ms.ToArray();
                            // Now you have the fileBytes and fileName for each file
                            // You can save them to the database or process them as needed
                            //return Ok("calling json service");
                            retValueSQL = await jsonservice.createShoppingListNewItemByteImg(ItemName, count, Username, fileBytes);
                            //return Ok("result from service: " + xxx.ToString());
                        }
                    }
                }
            }

            return Ok(String.Format("Files uploaded successfully. Item name: {0}; Count: {1}; Status code: {2}", ItemName, count, retValueSQL));
            if (retValueSQL == "1" || retValueSQL == "-1")
            {
                return Ok(String.Format("Files uploaded successfully. Item name: {0}; Count: {1}", ItemName, count));
            }
            else
            {
                return BadRequest("Error in SQL: \r\n" + retValueSQL);
            }
        }
        catch(Exception ex)
        {
            return BadRequest("Error in UploadBinaryDataImg: \r\n" + ex.Message);
        }
    }

    #endregion

    #region "MulletHunter"
    // public bool createShoppingListNewItem(string ItemName, int ItemCount)
    [HttpGet("registerMulletHunterUser/{Username}~{Email}~{Password}")]
    public ActionResult<string> registerMulletHunterUser(string Username, string Email, string Password) //, string Image)
    {
        var data = jsonservice.registerMulletHunterUser(Username, Email, Password); //, Image);
        return Ok(data);
    }
    #endregion

    #region "NahlasMe"
    [HttpPost("NahlasMeUploadBinaryDataImg")]
    public async Task<IActionResult> NahlasMeUploadBinaryDataImg()
    {
        try
        {
            // Check if the request contains multipart/form-data.
            if (!Request.HasFormContentType)
            {
                return BadRequest("Not a multipart/form-data request");
            }

            var formCollection = await Request.ReadFormAsync();
            var files = formCollection.Files;
            var ItemName = formCollection["ItemName"];
            var Username = formCollection["Username"];
            //return Ok("form collection looks fine");

            // Read the additional 'count' parameter from the form data
            var countString = formCollection["ItemCount"];
            if (!int.TryParse(countString, out int count))
            {
                return BadRequest("Invalid count value");
            }
            //return Ok("int count looks fine");
            string retValueSQL = "-1";

            if (files.Count == 0)
            {
                //return BadRequest("No files uploaded");
                retValueSQL = await jsonservice.createShoppingListNewItemByteImg(ItemName, count, Username, null);
            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Process each file here
                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            var fileBytes = ms.ToArray();
                            // Now you have the fileBytes and fileName for each file
                            // You can save them to the database or process them as needed
                            //return Ok("calling json service");
                            retValueSQL = await jsonservice.createShoppingListNewItemByteImg(ItemName, count, Username, fileBytes);
                            //return Ok("result from service: " + xxx.ToString());
                        }
                    }
                }
            }

            return Ok(String.Format("Files uploaded successfully. Item name: {0}; Count: {1}; Status code: {2}", ItemName, count, retValueSQL));
            if (retValueSQL == "1" || retValueSQL == "-1")
            {
                return Ok(String.Format("Files uploaded successfully. Item name: {0}; Count: {1}", ItemName, count));
            }
            else
            {
                return BadRequest("Error in SQL: \r\n" + retValueSQL);
            }
        }
        catch (Exception ex)
        {
            return BadRequest("Error in UploadBinaryDataImg: \r\n" + ex.Message);
        }
    }

    #endregion


}



//using Microsoft.AspNetCore.Mvc;

//namespace HomeControlBlazor.Contollers
//{
//    public class JSONController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}