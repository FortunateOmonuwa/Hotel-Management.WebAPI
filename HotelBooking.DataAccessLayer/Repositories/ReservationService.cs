using HotelBooking.Domain.Contracts;
using HotelBooking.Domain.Models;
using HotelBooking.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccessLayer.Repositories
{
    public class ReservationService : IReservationService
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly HotelContext _hotelContext;
        public ReservationService(IHotelsRepository hotelsRepository, HotelContext hotelContext)
        {
            _hotelsRepository = hotelsRepository;
            _hotelContext = hotelContext;
        }

        public async Task<Reservations> AddReservationsAsync(Reservations reservations)
        {
            try
            {
                
                var hotel = await _hotelsRepository.GetHotelByIdAsync(reservations.HotelId);
                if (hotel != null) 
                {
                    //1). Check the hotel rooms for the roomId passed in from the reservation object
                     var room = hotel.Rooms.Where(x => x.RoomId == reservations.RoomId).FirstOrDefault();
                     if(room != null)
                     {
                        //2). Check to see if room is busy and does not need repair
                        var busy = await _hotelContext.Reservations.AnyAsync(r => 
                        (reservations.CheckInDate >= r.CheckInDate && reservations.CheckInDate <= r.CheckOutDate) 
                        && (reservations.CheckOutDate >= r.CheckInDate && reservations.CheckOutDate <= r.CheckOutDate));
                        if(busy || room.NeedsRepair)
                        {
                            return null;
                        } 
                        else
                        {
                            //4). Store changes in the database..
                            _hotelContext.Update(room);
                            _hotelContext.Add(reservations);
                            await _hotelContext.SaveChangesAsync();
                            return reservations;
                        }
                }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<IEnumerable<Reservations>> GetAllReservationsAsync()
        {
            try
            {
                var reservations = await _hotelContext.Reservations
                    .Include(r => r.Room)
                    .Include(h => h.Hotel)
                    .ToListAsync();
                return reservations;
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
            
        }

        public async Task<Reservations> GetReservationsByIDAsync(int id)
        {
            try
            {
                var reservation = await _hotelContext.Reservations
                    .Include(r => r.Room)
                    .Include(h => h.Hotel)
                    .FirstOrDefaultAsync(r => r.ReservationId == id);
                if (reservation != null)
                {
                    return reservation;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
        }

        public Task<Reservations> UpdateReservationsAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Reservations> DeleteReservationsAsync(int id)
        {
            var reservation = await _hotelContext.Reservations.FirstOrDefaultAsync(r => r.ReservationId ==id);
            if(id != null)
            {
                _hotelContext.Remove(reservation);
                _hotelContext.SaveChanges();
                return reservation;
            }
            else
            {
                return null;
            }
        }
    }
}
