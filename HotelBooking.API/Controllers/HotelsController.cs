using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain.Models;
using HotelBooking.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Controllers
{
    /// <summary>
    /// When a request comes in for hotels, the IActionResult GetRooms method is triggered. 
    /// This route tells the api to look through this code and set any class inheriting from controller class as the controller for the resource/Model/Entity 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : Controller
    {
       
        private readonly ILogger<HotelsController> _logger;
        private readonly HotelContext _hotelContext;
        public HotelsController(ILogger<HotelsController>logger, HotelContext hotel)
        {
          
            _logger = logger;
            _hotelContext = hotel;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            try
            {
                if(await _hotelContext.Hotels.AnyAsync(x => x.Name == hotel.Name))
                {
                    return BadRequest("Hotel Already Exists");
                }
                else
                {
                    _hotelContext.Hotels.Add(hotel);
                    await _hotelContext.SaveChangesAsync();
                    return Ok();
                }
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new hotel");
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
         
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updateHotel, int id)
        {
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelContext.Hotels.ToListAsync();  
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelByID(int id)
        {
            var hotel = _hotelContext.Hotels.FirstOrDefaultAsync(x => x.HotelId== id);
        
            return Ok(hotel);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
           
            return NoContent();

        }

    }
}
