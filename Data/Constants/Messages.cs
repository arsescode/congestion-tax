namespace congestion_tax_calculator_net_core.Data.Constants
{
    public class Messages
    {

        public static string NotOK { get; set; } = "The operation failed.";
        public static string OK { get; set; } = "The operation was successful.";
        public static string ExemptVehicle { get; set; } = "The vehicle is exempt.";
        public static string MaxTax { get; set; } = "The vehicle already reached Maximum of today tax.";
        public static string FreeTime { get; set; } = "Now is free time.";
    }
}
