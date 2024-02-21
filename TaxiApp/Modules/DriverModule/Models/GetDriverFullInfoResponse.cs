namespace TaxiApp.Modules.DriverModule.Models
{
    public record GetDriverFullInfoResponse
    {
        public string FullName { get; set; }
        public int? Age { get; set; }

        public IReadOnlyCollection<CarInfo> Cars { get; set; }

        public record CarInfo
        {
            public string BrandModel { get; set; }
            public string Number { get; set; }
        }
    }
}
