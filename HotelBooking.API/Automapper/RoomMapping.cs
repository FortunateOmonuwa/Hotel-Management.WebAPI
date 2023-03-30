using AutoMapper;
using HotelBooking.API.DTO;
using HotelBooking.Domain.Models;

namespace HotelBooking.API.Automapper
{
    public class RoomMapping : Profile
    {
        public RoomMapping()
        {
            CreateMap<RoomCreateDTO, Room>();
            CreateMap<Room, RoomGetDTO>();
        }
    }
}