using System;
namespace CarDealershipProject.Core.Domain.Content
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

        public bool IsEmpty
        {
            get
            {
                return color == null && hasSunRoof == null && isFourWheelDrive == null && hasLowMiles == null && hasPowerWindows == null && hasNavigation == null && hasHeatedSeats == null;
            }
        }
    }
}
