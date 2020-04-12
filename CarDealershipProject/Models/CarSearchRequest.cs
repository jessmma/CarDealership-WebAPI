using System;
namespace CarDealershipProject.Models
{
    public class CarSearchRequest
    {
        public string? color { get; set; }
        public bool? hasSunRoof { get; set; }
        public bool? isFourWheelDrive { get; set; }
        public bool? hasLowMiles { get; set; }
        public bool? hasPowerWindows { get; set; }
        public bool? hasNavigation { get; set; }
        public bool? hasHeatedSeats { get; set; }
        public int? miles { get; set; }
    }
}
