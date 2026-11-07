using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Command> Commands { get; set; }

    public virtual DbSet<MessageLog> MessageLogs { get; set; }

    public virtual DbSet<SensorDatum> SensorData { get; set; }

    public virtual DbSet<TblAction> TblActions { get; set; }

    public virtual DbSet<TblAttendance> TblAttendances { get; set; }

    public virtual DbSet<TblAttendancePermission> TblAttendancePermissions { get; set; }

    public virtual DbSet<TblAttendanceSc> TblAttendanceScs { get; set; }

    public virtual DbSet<TblCamimage> TblCamimages { get; set; }

    public virtual DbSet<TblCez> TblCezs { get; set; }

    public virtual DbSet<TblCezdistribution> TblCezdistributions { get; set; }

    public virtual DbSet<TblCityPicture> TblCityPictures { get; set; }

    public virtual DbSet<TblElectricity> TblElectricities { get; set; }

    public virtual DbSet<TblElectricityConsumptionOverview> TblElectricityConsumptionOverviews { get; set; }

    public virtual DbSet<TblElectricityOld> TblElectricityOlds { get; set; }

    public virtual DbSet<TblElectricityOverview> TblElectricityOverviews { get; set; }

    public virtual DbSet<TblElectricityPriceInfo> TblElectricityPriceInfos { get; set; }

    public virtual DbSet<TblEquipment> TblEquipments { get; set; }

    public virtual DbSet<TblEquipmentActual> TblEquipmentActuals { get; set; }

    public virtual DbSet<TblEquipmentHistory> TblEquipmentHistories { get; set; }

    public virtual DbSet<TblEquipmentHistoryPower> TblEquipmentHistoryPowers { get; set; }

    public virtual DbSet<TblHome> TblHomes { get; set; }

    public virtual DbSet<TblInfo> TblInfos { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    public virtual DbSet<TblMulletHunterUser> TblMulletHunterUsers { get; set; }

    public virtual DbSet<TblOte> TblOtes { get; set; }

    public virtual DbSet<TblPowerSocket> TblPowerSockets { get; set; }

    public virtual DbSet<TblPvforecast> TblPvforecasts { get; set; }

    public virtual DbSet<TblRelay> TblRelays { get; set; }

    public virtual DbSet<TblRelayHistory> TblRelayHistories { get; set; }

    public virtual DbSet<TblReportMeRecord> TblReportMeRecords { get; set; }

    public virtual DbSet<TblSensor> TblSensors { get; set; }

    public virtual DbSet<TblSensorsHistory> TblSensorsHistories { get; set; }

    public virtual DbSet<TblSensorsHistoryOld> TblSensorsHistoryOlds { get; set; }

    public virtual DbSet<TblSensorsHistoryPower> TblSensorsHistoryPowers { get; set; }

    public virtual DbSet<TblShoppingList> TblShoppingLists { get; set; }

    public virtual DbSet<TblShoppingListImage> TblShoppingListImages { get; set; }

    public virtual DbSet<TblSolarPowerSystem> TblSolarPowerSystems { get; set; }

    public virtual DbSet<TblSolaxCloudOverview> TblSolaxCloudOverviews { get; set; }

    public virtual DbSet<TblSolaxCloudReport> TblSolaxCloudReports { get; set; }

    public virtual DbSet<TblSystemIpavailability> TblSystemIpavailabilities { get; set; }

    public virtual DbSet<TblThermometerDailyManagement> TblThermometerDailyManagements { get; set; }

    public virtual DbSet<TblThermoterDailyManagement> TblThermoterDailyManagements { get; set; }

    public virtual DbSet<TblToDo> TblToDos { get; set; }

    public virtual DbSet<TblToDoImage> TblToDoImages { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblWeatherForecast> TblWeatherForecasts { get; set; }

    public virtual DbSet<TblYr> TblYrs { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<VwvOtemwhPriceByProvider> VwvOtemwhPriceByProviders { get; set; }

    public virtual DbSet<VwvOtepriceByTarif> VwvOtepriceByTarifs { get; set; }

    public virtual DbSet<VwvRelayStatus> VwvRelayStatuses { get; set; }

    public virtual DbSet<OTEPricing> OTEPricings { get; set; }
    public virtual DbSet<PowerConsumptionModel> PowerConsumption { get; set; }
    public virtual DbSet<AKUTempHistoryModel> AKUTempHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mokos.bemalan.local;Database=Home;User ID=sa;Password=Abc.123;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Czech_CI_AS");

        modelBuilder.Entity<Command>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Commands__3214EC0773E139D5");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ClientId).HasMaxLength(50);
            entity.Property(e => e.DeviceId).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<MessageLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MessageL__3214EC074DD7DE99");

            entity.HasIndex(e => e.ClientEndpoint, "IX_MessageLogs_ClientEndpoint");

            entity.HasIndex(e => e.Timestamp, "IX_MessageLogs_Timestamp").IsDescending();

            entity.Property(e => e.ClientEndpoint).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SensorDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SensorDa__3214EC071D0FC0E9");

            entity.Property(e => e.ClientId).HasMaxLength(50);
            entity.Property(e => e.DeviceId).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblAction>(entity =>
        {
            entity.HasKey(e => e.ActId);

            entity.ToTable("tbl_Actions");

            entity.Property(e => e.ActId).HasColumnName("act_ID");
            entity.Property(e => e.ActActive).HasColumnName("act_Active");
            entity.Property(e => e.ActDefaultState).HasColumnName("act_DefaultState");
            entity.Property(e => e.ActHomeNr).HasColumnName("act_HomeNr");
            entity.Property(e => e.ActIoTid).HasColumnName("act_IoTID");
            entity.Property(e => e.ActTempMax)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("act_TempMax");
            entity.Property(e => e.ActTempMin)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("act_TempMin");
        });

        modelBuilder.Entity<TblAttendance>(entity =>
        {
            entity.HasKey(e => e.AtrId);

            entity.ToTable("tbl_Attendance");

            entity.Property(e => e.AtrId).HasColumnName("atr_ID");
            entity.Property(e => e.AtrDate)
                .HasColumnType("date")
                .HasColumnName("atr_Date");
            entity.Property(e => e.AtrDoorNr).HasColumnName("atr_DoorNr");
            entity.Property(e => e.AtrRfidnr)
                .HasMaxLength(10)
                .HasColumnName("atr_RFIDNr");
            entity.Property(e => e.AtrTime).HasColumnName("atr_Time");
        });

        modelBuilder.Entity<TblAttendancePermission>(entity =>
        {
            entity.HasKey(e => e.AtpId);

            entity.ToTable("tbl_AttendancePermission");

            entity.Property(e => e.AtpId).HasColumnName("atp_ID");
            entity.Property(e => e.AtpDoorNr).HasColumnName("atp_DoorNr");
            entity.Property(e => e.AtpRfidnr)
                .HasMaxLength(10)
                .HasColumnName("atp_RFIDNr");
        });

        modelBuilder.Entity<TblAttendanceSc>(entity =>
        {
            entity.HasKey(e => e.ScsId);

            entity.ToTable("tbl_AttendanceSCS");

            entity.Property(e => e.ScsId).HasColumnName("scs_ID");
            entity.Property(e => e.ScsCardId)
                .HasMaxLength(50)
                .HasColumnName("scs_CardID");
        });

        modelBuilder.Entity<TblCamimage>(entity =>
        {
            entity.HasKey(e => e.CpiId);

            entity.ToTable("tbl_CAMImages");

            entity.Property(e => e.CpiId).HasColumnName("cpi_ID");
            entity.Property(e => e.CpiCamid).HasColumnName("cpi_CAMID");
            entity.Property(e => e.CpiDate)
                .HasColumnType("date")
                .HasColumnName("cpi_Date");
            entity.Property(e => e.CpiImage).HasColumnName("cpi_Image");
            entity.Property(e => e.CpiTime).HasColumnName("cpi_Time");
        });

        modelBuilder.Entity<TblCez>(entity =>
        {
            entity.HasKey(e => e.CezId);

            entity.ToTable("tbl_CEZ");

            entity.Property(e => e.CezId).HasColumnName("cez_ID");
            entity.Property(e => e.CezDate)
                .HasColumnType("date")
                .HasColumnName("cez_Date");
            entity.Property(e => e.CezMeasurementMonth).HasColumnName("cez_MeasurementMonth");
            entity.Property(e => e.CezMeasurementYear).HasColumnName("cez_MeasurementYear");
            entity.Property(e => e.CezMonthlyConsumptionkWh).HasColumnName("cez_MonthlyConsumptionkWh");
            entity.Property(e => e.CezPrice).HasColumnName("cez_Price");
            entity.Property(e => e.CezT1).HasColumnName("cez_T1");
            entity.Property(e => e.CezT2).HasColumnName("cez_T2");
            entity.Property(e => e.CezTime).HasColumnName("cez_Time");
        });

        modelBuilder.Entity<TblCezdistribution>(entity =>
        {
            entity.HasKey(e => e.CdpDate);

            entity.ToTable("tbl_CEZDistribution");

            entity.Property(e => e.CdpDate)
                .HasColumnType("datetime")
                .HasColumnName("cdp_Date");
            entity.Property(e => e.CdpConsumption)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("cdp_Consumption");
        });

        modelBuilder.Entity<TblCityPicture>(entity =>
        {
            entity.HasKey(e => e.MupId);

            entity.ToTable("tbl_CityPictures");

            entity.Property(e => e.MupId).HasColumnName("mup_ID");
            entity.Property(e => e.MupDateTime)
                .HasColumnType("datetime")
                .HasColumnName("mup_DateTime");
            entity.Property(e => e.MupImage).HasColumnName("mup_Image");
            entity.Property(e => e.MupThumbnail).HasColumnName("mup_Thumbnail");
        });

        modelBuilder.Entity<TblElectricity>(entity =>
        {
            entity.HasKey(e => e.SelId);

            entity.ToTable("tbl_Electricity");

            entity.Property(e => e.SelId).HasColumnName("sel_ID");
            entity.Property(e => e.SelDateTime)
                .HasColumnType("datetime")
                .HasColumnName("sel_DateTime");
            entity.Property(e => e.SelHomeNr).HasColumnName("sel_HomeNr");
            entity.Property(e => e.SelIsValidA).HasColumnName("sel_IsValidA");
            entity.Property(e => e.SelIsValidB).HasColumnName("sel_IsValidB");
            entity.Property(e => e.SelIsValidC).HasColumnName("sel_IsValidC");
            entity.Property(e => e.SelMac)
                .HasMaxLength(20)
                .HasColumnName("sel_MAC");
            entity.Property(e => e.SelPowerA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerA");
            entity.Property(e => e.SelPowerB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerB");
            entity.Property(e => e.SelPowerC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerC");
            entity.Property(e => e.SelPowerFactorA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerFactorA");
            entity.Property(e => e.SelPowerFactorB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerFactorB");
            entity.Property(e => e.SelPowerFactorC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerFactorC");
            entity.Property(e => e.SelSn).HasColumnName("sel_SN");
            entity.Property(e => e.SelTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_Total");
            entity.Property(e => e.SelTotalA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalA");
            entity.Property(e => e.SelTotalB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalB");
            entity.Property(e => e.SelTotalC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalC");
            entity.Property(e => e.SelTotalPower)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_TotalPower");
            entity.Property(e => e.SelTotalReturnedA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedA");
            entity.Property(e => e.SelTotalReturnedB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedB");
            entity.Property(e => e.SelTotalReturnedC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedC");
            entity.Property(e => e.SelVoltageA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageA");
            entity.Property(e => e.SelVoltageB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageB");
            entity.Property(e => e.SelVoltageC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageC");
            entity.Property(e => e.SelWifiIp)
                .HasMaxLength(15)
                .HasColumnName("sel_WifiIP");
            entity.Property(e => e.SelWifiRssi).HasColumnName("sel_WifiRSSI");
            entity.Property(e => e.SelWifiSsid)
                .HasMaxLength(20)
                .HasColumnName("sel_WifiSSID");
            entity.Property(e => e.SelWifiStatus).HasColumnName("sel_WifiStatus");
        });

        modelBuilder.Entity<TblElectricityConsumptionOverview>(entity =>
        {
            entity.HasKey(e => e.EcoId);

            entity.ToTable("tbl_ElectricityConsumptionOverview");

            entity.Property(e => e.EcoId).HasColumnName("eco_ID");
            entity.Property(e => e.EcoConsumptionHt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("eco_ConsumptionHT");
            entity.Property(e => e.EcoConsumptionLt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("eco_ConsumptionLT");
            entity.Property(e => e.EcoConsumptionTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("eco_ConsumptionTotal");
            entity.Property(e => e.EcoDateFrom)
                .HasColumnType("date")
                .HasColumnName("eco_DateFrom");
            entity.Property(e => e.EcoDateTo)
                .HasColumnType("date")
                .HasColumnName("eco_DateTo");
            entity.Property(e => e.EcoPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("eco_Price");
            entity.Property(e => e.EcoSupplier)
                .HasMaxLength(50)
                .HasColumnName("eco_Supplier");
            entity.Property(e => e.EcoYear).HasColumnName("eco_Year");
        });

        modelBuilder.Entity<TblElectricityOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Electricity_old");

            entity.Property(e => e.SelDateTime)
                .HasColumnType("datetime")
                .HasColumnName("sel_DateTime");
            entity.Property(e => e.SelHomeNr).HasColumnName("sel_HomeNr");
            entity.Property(e => e.SelId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sel_ID");
            entity.Property(e => e.SelIsValidA).HasColumnName("sel_IsValidA");
            entity.Property(e => e.SelIsValidB).HasColumnName("sel_IsValidB");
            entity.Property(e => e.SelIsValidC).HasColumnName("sel_IsValidC");
            entity.Property(e => e.SelPowerA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerA");
            entity.Property(e => e.SelPowerB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerB");
            entity.Property(e => e.SelPowerC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_PowerC");
            entity.Property(e => e.SelReactiveA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_ReactiveA");
            entity.Property(e => e.SelReactiveB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_ReactiveB");
            entity.Property(e => e.SelReactiveC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_ReactiveC");
            entity.Property(e => e.SelTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_Total");
            entity.Property(e => e.SelTotalA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalA");
            entity.Property(e => e.SelTotalB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalB");
            entity.Property(e => e.SelTotalC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalC");
            entity.Property(e => e.SelTotalReturnedA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedA");
            entity.Property(e => e.SelTotalReturnedB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedB");
            entity.Property(e => e.SelTotalReturnedC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sel_TotalReturnedC");
            entity.Property(e => e.SelVoltageA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageA");
            entity.Property(e => e.SelVoltageB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageB");
            entity.Property(e => e.SelVoltageC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sel_VoltageC");
        });

        modelBuilder.Entity<TblElectricityOverview>(entity =>
        {
            entity.HasKey(e => e.EloDateTime);

            entity.ToTable("tbl_ElectricityOverview");

            entity.Property(e => e.EloDateTime)
                .HasColumnType("datetime")
                .HasColumnName("elo_DateTime");
            entity.Property(e => e.EloConsumption)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("elo_Consumption");
        });

        modelBuilder.Entity<TblElectricityPriceInfo>(entity =>
        {
            entity.HasKey(e => e.EpiId);

            entity.ToTable("tbl_ElectricityPriceInfo");

            entity.Property(e => e.EpiId).HasColumnName("epi_ID");
            entity.Property(e => e.EpiBreaker1x25with1x120)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker1x25with1x1_20");
            entity.Property(e => e.EpiBreaker3x100with3x12516)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x100with3x125_16");
            entity.Property(e => e.EpiBreaker3x10with3x167)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x10with3x16_7");
            entity.Property(e => e.EpiBreaker3x10with3x256)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x10with3x25_6");
            entity.Property(e => e.EpiBreaker3x125with3x16017)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x125with3x160_17");
            entity.Property(e => e.EpiBreaker3x160with1x118)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x160with1x1_18");
            entity.Property(e => e.EpiBreaker3x16with3x208)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x16with3x20_8");
            entity.Property(e => e.EpiBreaker3x20with3x259)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x20with3x25_9");
            entity.Property(e => e.EpiBreaker3x25with3x3210)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x25with3x32_10");
            entity.Property(e => e.EpiBreaker3x32with3x4011)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x32with3x40_11");
            entity.Property(e => e.EpiBreaker3x40with3x5012)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x40with3x50_12");
            entity.Property(e => e.EpiBreaker3x50with3x6313)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x50with3x63_13");
            entity.Property(e => e.EpiBreaker3x63with1x119)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x63with1x1_19");
            entity.Property(e => e.EpiBreaker3x63with3x8014)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x63with3x80_14");
            entity.Property(e => e.EpiBreaker3x80with3x10015)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_Breaker3x80with3x100_15");
            entity.Property(e => e.EpiDistributioPriceTarifHigh4)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_DistributioPriceTarifHigh_4");
            entity.Property(e => e.EpiDistributioPriceTarifLow5)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_DistributioPriceTarifLow_5");
            entity.Property(e => e.EpiDistributioPriceValidFrom)
                .HasColumnType("date")
                .HasColumnName("epi_DistributioPriceValidFrom");
            entity.Property(e => e.EpiDistributioPriceValidTo)
                .HasColumnType("date")
                .HasColumnName("epi_DistributioPriceValidTo");
            entity.Property(e => e.EpiDistribution)
                .HasMaxLength(50)
                .HasColumnName("epi_Distribution");
            entity.Property(e => e.EpiElectricityDph21)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_ElectricityDPH_21");
            entity.Property(e => e.EpiFinalPriceTarifHigh26)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_FinalPriceTarifHigh_26");
            entity.Property(e => e.EpiFinalPriceTarifLow27)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_FinalPriceTarifLow_27");
            entity.Property(e => e.EpiMonthlyFixedCosts28)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_MonthlyFixedCosts_28");
            entity.Property(e => e.EpiOteactivities23)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_OTEActivities_23");
            entity.Property(e => e.EpiPozebreaker24)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_POZEBreaker_24");
            entity.Property(e => e.EpiPozeconsumption25)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_POZEConsumption_25");
            entity.Property(e => e.EpiPozefinalPriceBreaker29)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_POZEFinalPriceBreaker_29");
            entity.Property(e => e.EpiPozefinalPriceConsumption30)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_POZEFinalPriceConsumption_30");
            entity.Property(e => e.EpiProvider)
                .HasMaxLength(50)
                .HasColumnName("epi_Provider");
            entity.Property(e => e.EpiProviderPriceFixedPayment3)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_ProviderPriceFixedPayment_3");
            entity.Property(e => e.EpiProviderPriceTarifHigh1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_ProviderPriceTarifHigh_1");
            entity.Property(e => e.EpiProviderPriceTarifLow2)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_ProviderPriceTarifLow_2");
            entity.Property(e => e.EpiProviderPriceValidFrom)
                .HasColumnType("date")
                .HasColumnName("epi_ProviderPriceValidFrom");
            entity.Property(e => e.EpiProviderPriceValidTo)
                .HasColumnType("date")
                .HasColumnName("epi_ProviderPriceValidTo");
            entity.Property(e => e.EpiServiceMarketPaymentMwh)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_ServiceMarketPaymentMWh");
            entity.Property(e => e.EpiSystemServicesPrice22)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("epi_SystemServicesPrice_22");
            entity.Property(e => e.EpiTarifName)
                .HasMaxLength(10)
                .HasColumnName("epi_TarifName");
            entity.Property(e => e.EpiYear).HasColumnName("epi_Year");
        });

        modelBuilder.Entity<TblEquipment>(entity =>
        {
            entity.HasKey(e => e.EquId);

            entity.ToTable("tbl_Equipment");

            entity.Property(e => e.EquId).HasColumnName("equ_ID");
            entity.Property(e => e.EquActive).HasColumnName("equ_Active");
            entity.Property(e => e.EquDescription)
                .HasMaxLength(50)
                .HasColumnName("equ_Description");
            entity.Property(e => e.EquFloor).HasColumnName("equ_Floor");
            entity.Property(e => e.EquHomeId).HasColumnName("equ_HomeID");
            entity.Property(e => e.EquIoTid).HasColumnName("equ_IoTID");
            entity.Property(e => e.EquPosition).HasColumnName("equ_Position");
            entity.Property(e => e.EquRelayNr).HasColumnName("equ_RelayNr");
            entity.Property(e => e.EquRoomNr).HasColumnName("equ_RoomNr");
            entity.Property(e => e.EquType)
                .HasMaxLength(50)
                .HasColumnName("equ_Type");
            entity.Property(e => e.EquZigbeeName)
                .HasMaxLength(100)
                .HasColumnName("equ_ZigbeeName");
        });

        modelBuilder.Entity<TblEquipmentActual>(entity =>
        {
            entity.HasKey(e => e.EquIoTid);

            entity.ToTable("tbl_EquipmentActual");

            entity.Property(e => e.EquIoTid)
                .ValueGeneratedNever()
                .HasColumnName("equ_IoTID");
            entity.Property(e => e.EquBattery).HasColumnName("equ_Battery");
            entity.Property(e => e.EquContact).HasColumnName("equ_Contact");
            entity.Property(e => e.EquCurrentHum)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("equ_CurrentHum");
            entity.Property(e => e.EquCurrentPressure)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("equ_CurrentPressure");
            entity.Property(e => e.EquCurrentTemp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("equ_CurrentTemp");
            entity.Property(e => e.EquDateTime)
                .HasColumnType("datetime")
                .HasColumnName("equ_DateTime");
            entity.Property(e => e.EquDescription)
                .HasMaxLength(50)
                .HasColumnName("equ_Description");
            entity.Property(e => e.EquHomeNr).HasColumnName("equ_HomeNr");
            entity.Property(e => e.EquIlluminance).HasColumnName("equ_Illuminance");
            entity.Property(e => e.EquIlluminanceLux).HasColumnName("equ_Illuminance_lux");
            entity.Property(e => e.EquIsValidA).HasColumnName("equ_IsValidA");
            entity.Property(e => e.EquIsValidB).HasColumnName("equ_IsValidB");
            entity.Property(e => e.EquIsValidC).HasColumnName("equ_IsValidC");
            entity.Property(e => e.EquLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("equ_LastUpdate");
            entity.Property(e => e.EquLinkQuality).HasColumnName("equ_LinkQuality");
            entity.Property(e => e.EquOccupancy).HasColumnName("equ_Occupancy");
            entity.Property(e => e.EquPower)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("equ_Power");
            entity.Property(e => e.EquPowerA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerA");
            entity.Property(e => e.EquPowerB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerB");
            entity.Property(e => e.EquPowerC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerC");
            entity.Property(e => e.EquReactiveA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveA");
            entity.Property(e => e.EquReactiveB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveB");
            entity.Property(e => e.EquReactiveC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveC");
            entity.Property(e => e.EquRelayStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("equ_RelayStatus");
            entity.Property(e => e.EquState)
                .HasMaxLength(5)
                .HasColumnName("equ_State");
            entity.Property(e => e.EquTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_Total");
            entity.Property(e => e.EquTotalA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalA");
            entity.Property(e => e.EquTotalB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalB");
            entity.Property(e => e.EquTotalC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalC");
            entity.Property(e => e.EquTotalReturnedA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedA");
            entity.Property(e => e.EquTotalReturnedB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedB");
            entity.Property(e => e.EquTotalReturnedC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedC");
            entity.Property(e => e.EquVoltage).HasColumnName("equ_Voltage");
            entity.Property(e => e.EquVoltageA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageA");
            entity.Property(e => e.EquVoltageB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageB");
            entity.Property(e => e.EquVoltageC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageC");
            entity.Property(e => e.EquZigbeeName)
                .HasMaxLength(100)
                .HasColumnName("equ_ZigbeeName");
        });

        modelBuilder.Entity<TblEquipmentHistory>(entity =>
        {
            entity.HasKey(e => e.EquIdhistory);

            entity.ToTable("tbl_EquipmentHistory");

            entity.Property(e => e.EquIdhistory).HasColumnName("equ_IDHistory");
            entity.Property(e => e.EquBattery).HasColumnName("equ_Battery");
            entity.Property(e => e.EquContact).HasColumnName("equ_Contact");
            entity.Property(e => e.EquCurrentHum)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("equ_CurrentHum");
            entity.Property(e => e.EquCurrentPressure)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("equ_CurrentPressure");
            entity.Property(e => e.EquCurrentTemp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("equ_CurrentTemp");
            entity.Property(e => e.EquDescription)
                .HasMaxLength(50)
                .HasColumnName("equ_Description");
            entity.Property(e => e.EquHomeNr).HasColumnName("equ_HomeNr");
            entity.Property(e => e.EquIlluminance).HasColumnName("equ_Illuminance");
            entity.Property(e => e.EquIlluminanceLux).HasColumnName("equ_Illuminance_lux");
            entity.Property(e => e.EquIoTid).HasColumnName("equ_IoTID");
            entity.Property(e => e.EquIsValidA).HasColumnName("equ_IsValidA");
            entity.Property(e => e.EquIsValidB).HasColumnName("equ_IsValidB");
            entity.Property(e => e.EquIsValidC).HasColumnName("equ_IsValidC");
            entity.Property(e => e.EquLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("equ_LastUpdate");
            entity.Property(e => e.EquLinkQuality).HasColumnName("equ_LinkQuality");
            entity.Property(e => e.EquOccupancy).HasColumnName("equ_Occupancy");
            entity.Property(e => e.EquPower)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("equ_Power");
            entity.Property(e => e.EquPowerA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerA");
            entity.Property(e => e.EquPowerB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerB");
            entity.Property(e => e.EquPowerC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_PowerC");
            entity.Property(e => e.EquReactiveA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveA");
            entity.Property(e => e.EquReactiveB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveB");
            entity.Property(e => e.EquReactiveC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_ReactiveC");
            entity.Property(e => e.EquState)
                .HasMaxLength(5)
                .HasColumnName("equ_State");
            entity.Property(e => e.EquTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_Total");
            entity.Property(e => e.EquTotalA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalA");
            entity.Property(e => e.EquTotalB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalB");
            entity.Property(e => e.EquTotalC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalC");
            entity.Property(e => e.EquTotalReturnedA)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedA");
            entity.Property(e => e.EquTotalReturnedB)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedB");
            entity.Property(e => e.EquTotalReturnedC)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equ_TotalReturnedC");
            entity.Property(e => e.EquVoltage).HasColumnName("equ_Voltage");
            entity.Property(e => e.EquVoltageA)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageA");
            entity.Property(e => e.EquVoltageB)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageB");
            entity.Property(e => e.EquVoltageC)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("equ_VoltageC");
            entity.Property(e => e.EquZigbeeName)
                .HasMaxLength(100)
                .HasColumnName("equ_ZigbeeName");
        });

        modelBuilder.Entity<TblEquipmentHistoryPower>(entity =>
        {
            entity.HasKey(e => e.EquIdhistory);

            entity.ToTable("tbl_EquipmentHistoryPower");

            entity.Property(e => e.EquIdhistory).HasColumnName("equ_IDHistory");
            entity.Property(e => e.EquId).HasColumnName("equ_ID");
            entity.Property(e => e.EquLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("equ_LastUpdate");
            entity.Property(e => e.EquLinkQuality).HasColumnName("equ_LinkQuality");
            entity.Property(e => e.EquPower)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("equ_Power");
            entity.Property(e => e.EquState)
                .HasMaxLength(7)
                .HasColumnName("equ_State");
        });

        modelBuilder.Entity<TblHome>(entity =>
        {
            entity.HasKey(e => e.HomId);

            entity.ToTable("tbl_Home");

            entity.Property(e => e.HomId).HasColumnName("hom_ID");
            entity.Property(e => e.HomAction)
                .HasMaxLength(50)
                .HasColumnName("hom_Action");
            entity.Property(e => e.HomDefaultState).HasColumnName("hom_DefaultState");
            entity.Property(e => e.HomDescription)
                .HasMaxLength(500)
                .HasColumnName("hom_Description");
            entity.Property(e => e.HomHomeNr).HasColumnName("hom_HomeNR");
            entity.Property(e => e.HomPin).HasColumnName("hom_PIN");
            entity.Property(e => e.HomState).HasColumnName("hom_State");
        });

        modelBuilder.Entity<TblInfo>(entity =>
        {
            entity.HasKey(e => e.MsgId);

            entity.ToTable("tbl_Info");

            entity.Property(e => e.MsgId).HasColumnName("msg_ID");
            entity.Property(e => e.MsgBody)
                .HasMaxLength(1000)
                .HasColumnName("msg_Body");
            entity.Property(e => e.MsgDate)
                .HasColumnType("date")
                .HasColumnName("msg_Date");
            entity.Property(e => e.MsgTime).HasColumnName("msg_Time");
        });

        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("tbl_Log");

            entity.Property(e => e.LogId).HasColumnName("log_ID");
            entity.Property(e => e.LogClass)
                .HasMaxLength(50)
                .HasColumnName("log_Class");
            entity.Property(e => e.LogDateTime)
                .HasColumnType("datetime")
                .HasColumnName("log_DateTime");
            entity.Property(e => e.LogError).HasColumnName("log_Error");
            entity.Property(e => e.LogMethod)
                .HasMaxLength(50)
                .HasColumnName("log_Method");
        });

        modelBuilder.Entity<TblMulletHunterUser>(entity =>
        {
            entity.HasKey(e => e.MluId);

            entity.ToTable("tbl_MulletHunterUsers");

            entity.Property(e => e.MluId).HasColumnName("mlu_ID");
            entity.Property(e => e.MluDateTime)
                .HasColumnType("datetime")
                .HasColumnName("mlu_DateTime");
            entity.Property(e => e.MluEmail)
                .HasMaxLength(50)
                .HasColumnName("mlu_Email");
            entity.Property(e => e.MluPassword)
                .HasMaxLength(50)
                .HasColumnName("mlu_Password");
            entity.Property(e => e.MluUsername)
                .HasMaxLength(50)
                .HasColumnName("mlu_Username");
        });

        modelBuilder.Entity<TblOte>(entity =>
        {
            entity.HasKey(e => e.OteId);

            entity.ToTable("tbl_OTE");

            entity.Property(e => e.OteId).HasColumnName("ote_ID");
            entity.Property(e => e.OteDate)
                .HasColumnType("date")
                .HasColumnName("ote_Date");
            entity.Property(e => e.OteEur).HasColumnName("ote_EUR");
            entity.Property(e => e.OteExchangeRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ote_ExchangeRate");
            entity.Property(e => e.OteHour).HasColumnName("ote_Hour");
            entity.Property(e => e.OteInterval)
                .HasMaxLength(11)
                .HasColumnName("ote_Interval");
            entity.Property(e => e.OteLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("ote_LastUpdate");
            entity.Property(e => e.OtePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ote_Price");
            entity.Property(e => e.OtePriceInterval)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ote_PriceInterval");
            entity.Property(e => e.OteVolume)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ote_Volume");
            entity.Property(e => e.OteWeight).HasColumnName("ote_Weight");
        });

        modelBuilder.Entity<TblPowerSocket>(entity =>
        {
            entity.HasKey(e => e.PwsId);

            entity.ToTable("tbl_PowerSockets");

            entity.Property(e => e.PwsId).HasColumnName("pws_ID");
            entity.Property(e => e.PwsHomeId).HasColumnName("pws_HomeID");
            entity.Property(e => e.PwsIoTid).HasColumnName("pws_IoTID");
            entity.Property(e => e.PwsState)
                .HasMaxLength(10)
                .HasColumnName("pws_State");
        });

        modelBuilder.Entity<TblPvforecast>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_PVForecast");

            entity.Property(e => e.PvfDate)
                .HasColumnType("date")
                .HasColumnName("pvf_Date");
            entity.Property(e => e.PvfId)
                .ValueGeneratedOnAdd()
                .HasColumnName("pvf_ID");
            entity.Property(e => e.PvfLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("pvf_LastUpdate");
            entity.Property(e => e.PvfPower).HasColumnName("pvf_Power");
            entity.Property(e => e.PvfTime).HasColumnName("pvf_Time");
        });

        modelBuilder.Entity<TblRelay>(entity =>
        {
            entity.HasKey(e => e.RlyId);

            entity.ToTable("tbl_Relays");

            entity.Property(e => e.RlyId).HasColumnName("rly_ID");
            entity.Property(e => e.RlyHomeId).HasColumnName("rly_HomeID");
            entity.Property(e => e.RlyRelayNr).HasColumnName("rly_RelayNr");
            entity.Property(e => e.RlyState).HasColumnName("rly_State");
        });

        modelBuilder.Entity<TblRelayHistory>(entity =>
        {
            entity.HasKey(e => e.RlhId);

            entity.ToTable("tbl_RelayHistory");

            entity.Property(e => e.RlhId).HasColumnName("rlh_ID");
            entity.Property(e => e.RlhDateTime)
                .HasColumnType("datetime")
                .HasColumnName("rlh_DateTime");
            entity.Property(e => e.RlhRelayId).HasColumnName("rlh_RelayID");
            entity.Property(e => e.RlhStatusNew).HasColumnName("rlh_StatusNew");
            entity.Property(e => e.RlhStatusOld).HasColumnName("rlh_StatusOld");
        });

        modelBuilder.Entity<TblReportMeRecord>(entity =>
        {
            entity.HasKey(e => e.RmrId);

            entity.ToTable("tbl_ReportMeRecords");

            entity.Property(e => e.RmrId).HasColumnName("rmr_ID");
            entity.Property(e => e.RmrCity)
                .HasMaxLength(100)
                .HasColumnName("rmr_City");
            entity.Property(e => e.RmrDescription)
                .HasMaxLength(1000)
                .HasColumnName("rmr_Description");
            entity.Property(e => e.RmrGps)
                .HasMaxLength(100)
                .HasColumnName("rmr_GPS");
            entity.Property(e => e.RmrLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("rmr_LastUpdate");
            entity.Property(e => e.RmrName)
                .HasMaxLength(100)
                .HasColumnName("rmr_Name");
            entity.Property(e => e.RmrStreet)
                .HasMaxLength(100)
                .HasColumnName("rmr_Street");
        });

        modelBuilder.Entity<TblSensor>(entity =>
        {
            entity.HasKey(e => e.SnsId);

            entity.ToTable("tbl_Sensors", tb => tb.HasTrigger("trg_Sensors_AfterUpdate_LivingRoom"));

            entity.Property(e => e.SnsId)
                .ValueGeneratedNever()
                .HasColumnName("sns_ID");
            entity.Property(e => e.SnsBattery).HasColumnName("sns_Battery");
            entity.Property(e => e.SnsContact).HasColumnName("sns_Contact");
            entity.Property(e => e.SnsCurrentHum)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("sns_CurrentHum");
            entity.Property(e => e.SnsCurrentPressure)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("sns_CurrentPressure");
            entity.Property(e => e.SnsCurrentTemp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("sns_CurrentTemp");
            entity.Property(e => e.SnsDescription)
                .HasMaxLength(50)
                .HasColumnName("sns_Description");
            entity.Property(e => e.SnsIlluminance).HasColumnName("sns_Illuminance");
            entity.Property(e => e.SnsIlluminanceLux).HasColumnName("sns_Illuminance_lux");
            entity.Property(e => e.SnsLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("sns_LastUpdate");
            entity.Property(e => e.SnsLinkQuality).HasColumnName("sns_LinkQuality");
            entity.Property(e => e.SnsOccupancy).HasColumnName("sns_Occupancy");
            entity.Property(e => e.SnsPower)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("sns_Power");
            entity.Property(e => e.SnsState)
                .HasMaxLength(5)
                .HasColumnName("sns_State");
            entity.Property(e => e.SnsVoltage).HasColumnName("sns_Voltage");
            entity.Property(e => e.SnsZigbeeName)
                .HasMaxLength(100)
                .HasColumnName("sns_ZigbeeName");
        });

        modelBuilder.Entity<TblSensorsHistory>(entity =>
        {
            entity.HasKey(e => e.SnsIdhistory);

            entity.ToTable("tbl_SensorsHistory");

            entity.Property(e => e.SnsIdhistory).HasColumnName("sns_IDHistory");
            entity.Property(e => e.SnsBattery).HasColumnName("sns_Battery");
            entity.Property(e => e.SnsContact).HasColumnName("sns_Contact");
            entity.Property(e => e.SnsCurrentHum)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("sns_CurrentHum");
            entity.Property(e => e.SnsCurrentPressure)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("sns_CurrentPressure");
            entity.Property(e => e.SnsCurrentTemp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("sns_CurrentTemp");
            entity.Property(e => e.SnsDescription)
                .HasMaxLength(50)
                .HasColumnName("sns_Description");
            entity.Property(e => e.SnsId).HasColumnName("sns_ID");
            entity.Property(e => e.SnsIlluminance).HasColumnName("sns_Illuminance");
            entity.Property(e => e.SnsIlluminanceLux).HasColumnName("sns_Illuminance_lux");
            entity.Property(e => e.SnsLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("sns_LastUpdate");
            entity.Property(e => e.SnsLinkQuality).HasColumnName("sns_LinkQuality");
            entity.Property(e => e.SnsOccupancy).HasColumnName("sns_Occupancy");
            entity.Property(e => e.SnsState)
                .HasMaxLength(5)
                .HasColumnName("sns_State");
            entity.Property(e => e.SnsVoltage).HasColumnName("sns_Voltage");
        });

        modelBuilder.Entity<TblSensorsHistoryOld>(entity =>
        {
            entity.HasKey(e => e.SnsIdhistory);

            entity.ToTable("tbl_SensorsHistoryOld");

            entity.Property(e => e.SnsIdhistory).HasColumnName("sns_IDHistory");
            entity.Property(e => e.SnsCurrentTemp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("sns_CurrentTemp");
            entity.Property(e => e.SnsId).HasColumnName("sns_ID");
            entity.Property(e => e.SnsLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("sns_LastUpdate");
        });

        modelBuilder.Entity<TblSensorsHistoryPower>(entity =>
        {
            entity.HasKey(e => e.SnsIdhistory);

            entity.ToTable("tbl_SensorsHistoryPower");

            entity.Property(e => e.SnsIdhistory).HasColumnName("sns_IDHistory");
            entity.Property(e => e.SnsId).HasColumnName("sns_ID");
            entity.Property(e => e.SnsLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("sns_LastUpdate");
            entity.Property(e => e.SnsLinkQuality).HasColumnName("sns_LinkQuality");
            entity.Property(e => e.SnsPower)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("sns_Power");
            entity.Property(e => e.SnsState)
                .HasMaxLength(7)
                .HasColumnName("sns_State");
        });

        modelBuilder.Entity<TblShoppingList>(entity =>
        {
            entity.HasKey(e => e.ShlId);

            entity.ToTable("tbl_ShoppingList");

            entity.Property(e => e.ShlId).HasColumnName("shl_ID");
            entity.Property(e => e.ShlCount).HasColumnName("shl_Count");
            entity.Property(e => e.ShlDate)
                .HasColumnType("date")
                .HasColumnName("shl_Date");
            entity.Property(e => e.ShlDateUpdate)
                .HasColumnType("date")
                .HasColumnName("shl_DateUpdate");
            entity.Property(e => e.ShlName)
                .HasMaxLength(50)
                .HasColumnName("shl_Name");
            entity.Property(e => e.ShlStatus).HasColumnName("shl_Status");
            entity.Property(e => e.ShlTime).HasColumnName("shl_Time");
            entity.Property(e => e.ShlTimeUpdate).HasColumnName("shl_TimeUpdate");
            entity.Property(e => e.ShlUser)
                .HasMaxLength(20)
                .HasColumnName("shl_User");
        });

        modelBuilder.Entity<TblShoppingListImage>(entity =>
        {
            entity.HasKey(e => e.ShiId);

            entity.ToTable("tbl_ShoppingListImages");

            entity.Property(e => e.ShiId).HasColumnName("shi_ID");
            entity.Property(e => e.ShiImage).HasColumnName("shi_Image");
            entity.Property(e => e.ShiImageId).HasColumnName("shi_ImageID");
            entity.Property(e => e.ShiRecordId).HasColumnName("shi_RecordID");

            entity.HasOne(d => d.ShiRecord).WithMany(p => p.TblShoppingListImages)
                .HasForeignKey(d => d.ShiRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_ShoppingListImages_tbl_ShoppingList");
        });

        modelBuilder.Entity<TblSolarPowerSystem>(entity =>
        {
            entity.HasKey(e => e.SpsId);

            entity.ToTable("tbl_SolarPowerSystem");

            entity.Property(e => e.SpsId).HasColumnName("sps_ID");
            entity.Property(e => e.SpsCurrent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sps_Current");
            entity.Property(e => e.SpsDateTime)
                .HasColumnType("datetime")
                .HasColumnName("sps_DateTime");
            entity.Property(e => e.SpsEnergyDayAcc)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("sps_EnergyDayAcc");
            entity.Property(e => e.SpsEnergyHrAccWh)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sps_EnergyHrAccWh");
            entity.Property(e => e.SpsPower)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sps_Power");
            entity.Property(e => e.SpsTemperature)
                .HasDefaultValueSql("((-99))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sps_Temperature");
            entity.Property(e => e.SpsVoltage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sps_Voltage");
        });

        modelBuilder.Entity<TblSolaxCloudOverview>(entity =>
        {
            entity.HasKey(e => e.SxoDateTime);

            entity.ToTable("tbl_SolaxCloudOverview");

            entity.Property(e => e.SxoDateTime)
                .HasColumnType("datetime")
                .HasColumnName("sxo_DateTime");
            entity.Property(e => e.SxoBatteryPower)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxo_BatteryPower");
            entity.Property(e => e.SxoPowerDc1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxo_PowerDC1");
            entity.Property(e => e.SxoYieldToday)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxo_YieldToday");
        });

        modelBuilder.Entity<TblSolaxCloudReport>(entity =>
        {
            entity.HasKey(e => e.SxiId);

            entity.ToTable("tbl_SolaxCloudReport");

            entity.Property(e => e.SxiId).HasColumnName("sxi_ID");
            entity.Property(e => e.SxiAcpower).HasColumnName("sxi_ACPower");
            entity.Property(e => e.SxiBatteryPower)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxi_BatteryPower");
            entity.Property(e => e.SxiBatteryStatus)
                .HasMaxLength(10)
                .HasColumnName("sxi_BatteryStatus");
            entity.Property(e => e.SxiFeedInPower)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxi_FeedInPower");
            entity.Property(e => e.SxiInverterSn)
                .HasMaxLength(50)
                .HasColumnName("sxi_InverterSN");
            entity.Property(e => e.SxiInverterStatus)
                .HasMaxLength(4)
                .HasColumnName("sxi_InverterStatus");
            entity.Property(e => e.SxiInverterType)
                .HasMaxLength(2)
                .HasColumnName("sxi_InverterType");
            entity.Property(e => e.SxiLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("sxi_LastUpdate");
            entity.Property(e => e.SxiPowerDc1).HasColumnName("sxi_PowerDC1");
            entity.Property(e => e.SxiSn)
                .HasMaxLength(50)
                .HasColumnName("sxi_SN");
            entity.Property(e => e.SxiSoc).HasColumnName("sxi_SOC");
            entity.Property(e => e.SxiUploadTime)
                .HasColumnType("datetime")
                .HasColumnName("sxi_UploadTime");
            entity.Property(e => e.SxiYieldToday)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxi_YieldToday");
            entity.Property(e => e.SxiYieldTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sxi_YieldTotal");
        });

        modelBuilder.Entity<TblSystemIpavailability>(entity =>
        {
            entity.HasKey(e => e.SiaId);

            entity.ToTable("tbl_SystemIPAvailability");

            entity.Property(e => e.SiaId).HasColumnName("sia_ID");
            entity.Property(e => e.SiaAvailability).HasColumnName("sia_Availability");
            entity.Property(e => e.SiaDate)
                .HasColumnType("date")
                .HasColumnName("sia_Date");
            entity.Property(e => e.SiaDestinationIp)
                .HasMaxLength(20)
                .HasColumnName("sia_DestinationIP");
            entity.Property(e => e.SiaResponseTime).HasColumnName("sia_ResponseTime");
            entity.Property(e => e.SiaSourceIp)
                .HasMaxLength(20)
                .HasColumnName("sia_SourceIP");
            entity.Property(e => e.SiaTime).HasColumnName("sia_Time");
        });

        modelBuilder.Entity<TblThermometerDailyManagement>(entity =>
        {
            entity.HasKey(e => e.TdmId);

            entity.ToTable("tbl_ThermometerDailyManagement");

            entity.Property(e => e.TdmId).HasColumnName("tdm_ID");
            entity.Property(e => e.TdmDay).HasColumnName("tdm_Day");
            entity.Property(e => e.TdmHour).HasColumnName("tdm_Hour");
            entity.Property(e => e.TdmRoomNr).HasColumnName("tdm_RoomNr");
            entity.Property(e => e.TdmTemperature)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("tdm_Temperature");
        });

        modelBuilder.Entity<TblThermoterDailyManagement>(entity =>
        {
            entity.HasKey(e => e.TdmId);

            entity.ToTable("tbl_ThermoterDailyManagement");

            entity.Property(e => e.TdmId).HasColumnName("tdm_ID");
            entity.Property(e => e.TdmDay).HasColumnName("tdm_Day");
            entity.Property(e => e.TdmHour).HasColumnName("tdm_Hour");
            entity.Property(e => e.TdmSensorId).HasColumnName("tdm_SensorID");
            entity.Property(e => e.TdmTemperature).HasColumnName("tdm_Temperature");
        });

        modelBuilder.Entity<TblToDo>(entity =>
        {
            entity.HasKey(e => e.TdoId);

            entity.ToTable("tbl_ToDo");

            entity.Property(e => e.TdoId).HasColumnName("tdo_ID");
            entity.Property(e => e.TdoCategory)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_Category");
            entity.Property(e => e.TdoDescription)
                .HasMaxLength(1000)
                .HasColumnName("tdo_Description");
            entity.Property(e => e.TdoName)
                .HasMaxLength(100)
                .HasColumnName("tdo_Name");
            entity.Property(e => e.TdoPriority)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_Priority");
            entity.Property(e => e.TdoReminder)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_Reminder");
            entity.Property(e => e.TdoReminderEmail)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_ReminderEmail");
            entity.Property(e => e.TdoReminderInterval)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_ReminderInterval");
            entity.Property(e => e.TdoReminderSms)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_ReminderSMS");
            entity.Property(e => e.TdoStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tdo_Status");
        });

        modelBuilder.Entity<TblToDoImage>(entity =>
        {
            entity.HasKey(e => e.TdpId);

            entity.ToTable("tbl_ToDoImages");

            entity.Property(e => e.TdpId).HasColumnName("tdp_ID");
            entity.Property(e => e.TdpDescription)
                .HasMaxLength(500)
                .HasColumnName("tdp_Description");
            entity.Property(e => e.TdpImage).HasColumnName("tdp_Image");
            entity.Property(e => e.TdpToDoId).HasColumnName("tdp_ToDoID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UsrUsername);

            entity.ToTable("tbl_Users");

            entity.Property(e => e.UsrUsername)
                .HasMaxLength(50)
                .HasColumnName("usr_Username");
            entity.Property(e => e.UsrActiveAccount)
                .HasDefaultValueSql("((0))")
                .HasColumnName("usr_ActiveAccount");
            entity.Property(e => e.UsrEmail)
                .HasMaxLength(50)
                .HasColumnName("usr_Email");
            entity.Property(e => e.UsrId)
                .ValueGeneratedOnAdd()
                .HasColumnName("usr_ID");
            entity.Property(e => e.UsrPassword)
                .HasMaxLength(200)
                .HasColumnName("usr_Password");
            entity.Property(e => e.UsrPhoneNr)
                .HasMaxLength(15)
                .HasColumnName("usr_PhoneNr");
            entity.Property(e => e.UsrPin).HasColumnName("usr_Pin");
        });

        modelBuilder.Entity<TblWeatherForecast>(entity =>
        {
            entity.HasKey(e => e.WfcId);

            entity.ToTable("tbl_WeatherForecast");

            entity.Property(e => e.WfcId).HasColumnName("wfc_ID");
            entity.Property(e => e.WfcCeilingUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_CeilingUnit");
            entity.Property(e => e.WfcCeilingValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_CeilingValue");
            entity.Property(e => e.WfcDate)
                .HasColumnType("date")
                .HasColumnName("wfc_Date");
            entity.Property(e => e.WfcEpochDateTime).HasColumnName("wfc_EpochDateTime");
            entity.Property(e => e.WfcEvapotranspirationUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_EvapotranspirationUnit");
            entity.Property(e => e.WfcEvapotranspirationValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_EvapotranspirationValue");
            entity.Property(e => e.WfcHasPrecipition).HasColumnName("wfc_HasPrecipition");
            entity.Property(e => e.WfcHour).HasColumnName("wfc_Hour");
            entity.Property(e => e.WfcIceUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_IceUnit");
            entity.Property(e => e.WfcIceValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_IceValue");
            entity.Property(e => e.WfcIconPhrase)
                .HasMaxLength(50)
                .HasColumnName("wfc_IconPhrase");
            entity.Property(e => e.WfcIndoorRelativeHumidity).HasColumnName("wfc_IndoorRelativeHumidity");
            entity.Property(e => e.WfcIsDayLight).HasColumnName("wfc_IsDayLight");
            entity.Property(e => e.WfcLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("wfc_LastUpdate");
            entity.Property(e => e.WfcRainUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_RainUnit");
            entity.Property(e => e.WfcRainValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_RainValue");
            entity.Property(e => e.WfcRealfeelTempPhrase)
                .HasMaxLength(50)
                .HasColumnName("wfc_RealfeelTempPhrase");
            entity.Property(e => e.WfcRealfeelTempShadeValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_RealfeelTempShadeValue");
            entity.Property(e => e.WfcRealfeelTempUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_RealfeelTempUnit");
            entity.Property(e => e.WfcRealfeelTempValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_RealfeelTempValue");
            entity.Property(e => e.WfcRealfeeltempShadePhrase)
                .HasMaxLength(50)
                .HasColumnName("wfc_RealfeeltempShadePhrase");
            entity.Property(e => e.WfcRealfeeltempShadeUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_RealfeeltempShadeUnit");
            entity.Property(e => e.WfcRelativeHumidity).HasColumnName("wfc_RelativeHumidity");
            entity.Property(e => e.WfcSnowUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_SnowUnit");
            entity.Property(e => e.WfcSnowValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_SnowValue");
            entity.Property(e => e.WfcSolarirradianceValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_SolarirradianceValue");
            entity.Property(e => e.WfcSsolarirradianceUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_SsolarirradianceUnit");
            entity.Property(e => e.WfcTempUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_TempUnit");
            entity.Property(e => e.WfcTempValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_TempValue");
            entity.Property(e => e.WfcTotalliquidUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_TotalliquidUnit");
            entity.Property(e => e.WfcTotalliquidValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_TotalliquidValue");
            entity.Property(e => e.WfcUvindex).HasColumnName("wfc_UVIndex");
            entity.Property(e => e.WfcUvindexText)
                .HasMaxLength(50)
                .HasColumnName("wfc_UVIndexText");
            entity.Property(e => e.WfcVisibilityUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_VisibilityUnit");
            entity.Property(e => e.WfcVisibilityValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_VisibilityValue");
            entity.Property(e => e.WfcWetbulbTempUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_WetbulbTempUnit");
            entity.Property(e => e.WfcWetbulbTempValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_WetbulbTempValue");
            entity.Property(e => e.WfcWindSpeedDirectionDegrees).HasColumnName("wfc_WindSpeedDirectionDegrees");
            entity.Property(e => e.WfcWindSpeedDirectionEnglish)
                .HasMaxLength(50)
                .HasColumnName("wfc_WindSpeedDirectionEnglish");
            entity.Property(e => e.WfcWindSpeedDirectionLocalized)
                .HasMaxLength(50)
                .HasColumnName("wfc_WindSpeedDirectionLocalized");
            entity.Property(e => e.WfcWindSpeedUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_WindSpeedUnit");
            entity.Property(e => e.WfcWindSpeedValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_WindSpeedValue");
            entity.Property(e => e.WfcWindgustSpeedUnit)
                .HasMaxLength(10)
                .HasColumnName("wfc_WindgustSpeedUnit");
            entity.Property(e => e.WfcWindgustSpeedValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wfc_WindgustSpeedValue");
        });

        modelBuilder.Entity<TblYr>(entity =>
        {
            entity.HasKey(e => e.YrnId).HasName("PK__tbl_YR__8A849F8B6BA00C80");

            entity.ToTable("tbl_YR");

            entity.Property(e => e.YrnId).HasColumnName("yrn_ID");
            entity.Property(e => e.YrnAirPressureAtSeaLevel)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_AirPressureAtSeaLevel");
            entity.Property(e => e.YrnAirTemperature)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_AirTemperature");
            entity.Property(e => e.YrnAirTemperatureMax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_AirTemperatureMax");
            entity.Property(e => e.YrnAirTemperatureMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_AirTemperatureMin");
            entity.Property(e => e.YrnCloudAreaFraction)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_CloudAreaFraction");
            entity.Property(e => e.YrnCloudAreaFractionHigh)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_CloudAreaFractionHigh");
            entity.Property(e => e.YrnCloudAreaFractionLow)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_CloudAreaFractionLow");
            entity.Property(e => e.YrnCloudAreaFractionMedium)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_CloudAreaFractionMedium");
            entity.Property(e => e.YrnDewPointTemperature)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_DewPointTemperature");
            entity.Property(e => e.YrnFogAreaFraction)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_FogAreaFraction");
            entity.Property(e => e.YrnLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("yrn_LastUpdate");
            entity.Property(e => e.YrnPrecipitationAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_PrecipitationAmount");
            entity.Property(e => e.YrnRelativeHumidity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_RelativeHumidity");
            entity.Property(e => e.YrnTempDate)
                .HasColumnType("date")
                .HasColumnName("yrn_TempDate");
            entity.Property(e => e.YrnTempHour).HasColumnName("yrn_TempHour");
            entity.Property(e => e.YrnUltravioletIndexClearSky)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_UltravioletIndexClearSky");
            entity.Property(e => e.YrnWindFromDirection)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_WindFromDirection");
            entity.Property(e => e.YrnWindSpeed)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yrn_WindSpeed");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.A);

            entity.ToTable("_test");

            entity.Property(e => e.A).HasColumnName("a");
            entity.Property(e => e.B)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("b");
        });

        modelBuilder.Entity<VwvOtemwhPriceByProvider>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwv_OTEMWhPriceByProvider");

            entity.Property(e => e.OtePriceMwh)
                .HasColumnType("decimal(17, 2)")
                .HasColumnName("ote_PriceMWh");
        });

        modelBuilder.Entity<VwvOtepriceByTarif>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwv_OTEPriceByTarif");

            entity.Property(e => e.OtePriceMwh)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("ote_PriceMWh");
        });

        modelBuilder.Entity<VwvRelayStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwv_RelayStatus");

            entity.Property(e => e.RlyDescription)
                .HasMaxLength(50)
                .HasColumnName("rly_Description");
            entity.Property(e => e.RlyIoTid).HasColumnName("rly_IoTID");
            entity.Property(e => e.RlyMode).HasColumnName("rly_Mode");
            entity.Property(e => e.RlyRelayNr).HasColumnName("rly_RelayNr");
            entity.Property(e => e.RlyRelayStatus).HasColumnName("rly_RelayStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
