using HotelBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Validation
{
    public class HotelValidation
    {
        public bool IsHotelValid(Hotel hotel)
        {
            if (hotel == null)
            {
                return false;
            }

            return true;
        }
    }
}
