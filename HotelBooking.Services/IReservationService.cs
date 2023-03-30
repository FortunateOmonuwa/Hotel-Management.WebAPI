using HotelBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface IReservationService
    {
        Task<Reservations> AddReservationsAsync(Reservations reservations);
        Task<Reservations> UpdateReservationsAsync(int id);
        Task<Reservations> DeleteReservationsAsync(int id);
        Task<Reservations> GetReservationsByIDAsync(int id);
        Task<IEnumerable<Reservations>> GetAllReservationsAsync();
    }
}
