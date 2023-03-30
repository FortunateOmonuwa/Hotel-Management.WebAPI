using HotelBooking.Domain.Models;

namespace HotelBooking.API.DTO
{
    public class ReservationAddDTO
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Customer { get; set; }
    }
}
