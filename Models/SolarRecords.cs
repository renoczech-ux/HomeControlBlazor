namespace HomeControlBlazor.Models
{
    public class SolarRecords
    {
        public int Hour { get; set; }
        public double Power { get; set; }

        public double PowerHour { get; set; }

        public double PowerDay { get; set; }

        public double Temp { get; set; }
    }
}
