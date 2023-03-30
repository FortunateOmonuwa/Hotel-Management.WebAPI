namespace HotelBooking.API.DTO
{
    public class RoomCreateDTO
    {
        public int RoomNumber { get; set; }
        public double Size { get; set; }
        public bool NeedsRepair { get; set; }
    }
}
