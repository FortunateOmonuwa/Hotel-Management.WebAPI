using AutoMapper;
using HotelBooking.API.DTO;
using HotelBooking.DataAccessLayer;
using HotelBooking.Domain.Models;
using HotelBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService= reservationService;
            _mapper=mapper;
           
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationAddDTO reservation)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var map = _mapper.Map<Reservations>(reservation);
                    if (reservation != null)
                    {
                        var addReservation = await _reservationService.AddReservationsAsync(map);
                        if (addReservation != null)
                        {
                            var mappedReservation = _mapper.Map<ReservationGetDTO>(map);
                            return CreatedAtAction(nameof(GetReservationById), new { Id = addReservation.ReservationId }, mappedReservation);
                        }
                        else
                        {
                            return BadRequest("Cannot create this reservation because room is currently unavailable");
                        }

                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
               
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationsByIDAsync(id);
                {
                    if (reservation != null)
                    {
                        var map = _mapper.Map<ReservationGetDTO>(reservation);
                        return Ok(map);
                    }
                    else
                    {
                        return NotFound($"No reservation with {id} exists");
                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();
                var map = _mapper.Map<List<ReservationGetDTO>>(reservations);
                return Ok(map);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> CancelReservation(int id)
        {
            var reservation = await _reservationService.DeleteReservationsAsync(id);
            if(reservation != null)
            {
                return Ok("This reservation has been cancelled successfully");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
