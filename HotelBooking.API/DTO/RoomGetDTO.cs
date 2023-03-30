namespace HotelBooking.API.DTO
{
    public class RoomGetDTO
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double Size { get; set; }
        public bool NeedsRepair { get; set; }
        public HotelGetDTO Hotel { get; set; }
    }
}
