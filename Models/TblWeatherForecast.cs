using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblWeatherForecast
{
    public int WfcId { get; set; }

    public DateTime WfcDate { get; set; }

    public int WfcHour { get; set; }

    public long WfcEpochDateTime { get; set; }

    public string? WfcIconPhrase { get; set; }

    public int? WfcHasPrecipition { get; set; }

    public int WfcIsDayLight { get; set; }

    public decimal? WfcTempValue { get; set; }

    public string? WfcTempUnit { get; set; }

    public decimal? WfcRealfeelTempValue { get; set; }

    public string? WfcRealfeelTempUnit { get; set; }

    public string? WfcRealfeelTempPhrase { get; set; }

    public decimal? WfcRealfeelTempShadeValue { get; set; }

    public string? WfcRealfeeltempShadeUnit { get; set; }

    public string? WfcRealfeeltempShadePhrase { get; set; }

    public decimal? WfcWetbulbTempValue { get; set; }

    public string? WfcWetbulbTempUnit { get; set; }

    public decimal? WfcWindSpeedValue { get; set; }

    public string? WfcWindSpeedUnit { get; set; }

    public int? WfcWindSpeedDirectionDegrees { get; set; }

    public string? WfcWindSpeedDirectionLocalized { get; set; }

    public string? WfcWindSpeedDirectionEnglish { get; set; }

    public decimal? WfcWindgustSpeedValue { get; set; }

    public string? WfcWindgustSpeedUnit { get; set; }

    public decimal? WfcVisibilityValue { get; set; }

    public string? WfcVisibilityUnit { get; set; }

    public decimal? WfcCeilingValue { get; set; }

    public string? WfcCeilingUnit { get; set; }

    public decimal? WfcTotalliquidValue { get; set; }

    public string? WfcTotalliquidUnit { get; set; }

    public decimal? WfcRainValue { get; set; }

    public string? WfcRainUnit { get; set; }

    public decimal? WfcSnowValue { get; set; }

    public string? WfcSnowUnit { get; set; }

    public decimal? WfcIceValue { get; set; }

    public string? WfcIceUnit { get; set; }

    public decimal? WfcEvapotranspirationValue { get; set; }

    public string? WfcEvapotranspirationUnit { get; set; }

    public decimal? WfcSolarirradianceValue { get; set; }

    public string? WfcSsolarirradianceUnit { get; set; }

    public int? WfcRelativeHumidity { get; set; }

    public int? WfcIndoorRelativeHumidity { get; set; }

    public int? WfcUvindex { get; set; }

    public string? WfcUvindexText { get; set; }

    public DateTime WfcLastUpdate { get; set; }
}
