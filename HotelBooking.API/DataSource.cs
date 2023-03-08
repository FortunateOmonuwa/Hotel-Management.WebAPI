using HotelBooking.Domain.Models;

namespace HotelBooking.API
{
    public class DataSource
    {
        public DataSource() 
        {
            Hotels = GetHotels();
        
        
        }

        public List<Hotel> Hotels {get; set;}

        private List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    HotelId = 1,
                    Name = "Radisson Blu",
                    StarRating = 5,
                    Address = "GRA Ikeja Lagos",
                    City = "Lagos",
                    Country = "Nigeria",
                    Description = "Easily One of the best hotels in Nigeria"

                },

                new Hotel
                {
                    HotelId = 2,
                    Name = "Sheraton Hotel",
                    StarRating = 5,
                    Address = "Lekki Phaase one Lagos",
                    City = "Lagos",
                    Country = "Nigeria",
                    Description = "One of the foremost hotels in Nigeria that offers some of the best services you can find anywhere "
                },

                new Hotel
                {
                    HotelId = 3,
                    Name = "Eko Hotels",
                    StarRating = 5,
                    Address = "Victoria Island Lagos",
                    City = "Lagos",
                    Country = "Nigeria",
                    Description = "Considered by many as the best hotel in Lagos"
                }
            };
        }
    }
}
