using HotelBooking.Domain.Models;

namespace HotelBooking.API.DTO
{
    public class ReservationGetDTO
    {
        public int ReservationId { get; set; }
        public RoomGetDTO Room { get; set; }
        public HotelGetDTO Hotel { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Customer { get; set; }
    }
}
