using System;
namespace CarDealershipProject.Models
{
    public class Car
    {
        public string _id { get; set; }
        public string make { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public decimal price { get; set; }
        public bool hasSunRoof { get; set; }
        public bool isFourWheelDrive { get; set; }
        public bool hasLowMiles { get; set; }
        public bool hasPowerWindows { get; set; }
        public bool hasNavigation { get; set; }
        public bool hasHeatedSeats { get; set; }
        public int miles { get; set; }
    }
}
