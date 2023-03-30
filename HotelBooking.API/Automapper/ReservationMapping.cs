using AutoMapper;
using HotelBooking.API.DTO;
using HotelBooking.Domain.Models;

namespace HotelBooking.API.Automapper
{
    public class ReservationMapping : Profile
    {
        public ReservationMapping() 
        {
            CreateMap<ReservationAddDTO, Reservations>();
            CreateMap<Reservations, ReservationGetDTO>();
        }
    }
}
