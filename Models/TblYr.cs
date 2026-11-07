using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblYr
{
    public int YrnId { get; set; }

    public DateTime? YrnTempDate { get; set; }

    public int? YrnTempHour { get; set; }

    public decimal? YrnAirPressureAtSeaLevel { get; set; }

    public decimal? YrnAirTemperature { get; set; }

    public decimal? YrnCloudAreaFraction { get; set; }

    public decimal? YrnCloudAreaFractionHigh { get; set; }

    public decimal? YrnCloudAreaFractionLow { get; set; }

    public decimal? YrnCloudAreaFractionMedium { get; set; }

    public decimal? YrnDewPointTemperature { get; set; }

    public decimal? YrnFogAreaFraction { get; set; }

    public decimal? YrnRelativeHumidity { get; set; }

    public decimal? YrnUltravioletIndexClearSky { get; set; }

    public decimal? YrnWindFromDirection { get; set; }

    public decimal? YrnWindSpeed { get; set; }

    public decimal? YrnPrecipitationAmount { get; set; }

    public decimal? YrnAirTemperatureMax { get; set; }

    public decimal? YrnAirTemperatureMin { get; set; }

    public DateTime? YrnLastUpdate { get; set; }
}
