using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Data.Entities;
using Airport.Models;
using AutoMapper;

namespace Airport.Controllers
{
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public FlightsController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Flights
        //Список усіх Flights
        [Route("api/Flights")]
        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            try
            {
                List<GetFlightViewModel> flights
                    = await _context
                    .Flights
                    .OrderBy(x => x.Id)
                    .Select(x => _mapper.Map<GetFlightViewModel>(x))
                    .ToListAsync();
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        // PUT: api/Flights
        //оновлення Flight. Оновлюються лише поля які прийшли з UI.
        //Id приходить в моделі.
        //Усі перевірки на валідаторі.
        [Route("api/Flights/UpdateFlight")]
        [HttpPut]
        public async Task<IActionResult> PutFlight([FromForm] UpdateFlightViewModel model)
        {
           
            try
            {
                Flight foundFlight = await _context.Flights.FindAsync(model.Id);
                if (foundFlight == null)
                {
                    return BadRequest(new { error = $"Flight with id {model.Id} does not exist." });
                }
                
                foundFlight.Number = model.Number?? foundFlight.Number;
                foundFlight.DepartureFrom = model.DepartureFrom?? foundFlight.DepartureFrom;
                foundFlight.DepartureDate = model.DepartureDate?? foundFlight.DepartureDate;
                foundFlight.ArrivalTo = model.ArrivalTo ?? foundFlight.ArrivalTo;
                foundFlight.ArrivalDate = model.ArrivalDate ?? foundFlight.ArrivalDate;

                await _context.SaveChangesAsync();
                return Ok($"Flight with id: {model.Id} updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with updating record. Exception Type:\n" + ex.GetType() });
            }

        }

        // POST: api/Flights
        //Додавання Flight
        //Номер, дата вильоту, місто вильоту. Повинні бути унікальними в сукупності(не кожне окремо унікальне, а разом).
        //Усі перевірки на валідаторі.
        [Route("api/Flights/AddFlight")]
        [HttpPost]
        public async Task<IActionResult> PostFlight([FromForm] AddFlightViewModel model)
        {
            try
            {
                Flight flight = _mapper.Map<Flight>(model);
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();
                return Ok("Flight is added to database");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with record creation. Exception Type:\n" + ex.GetType() });
            }

        }

        // DELETE: api/Flights/5
        //Видалення Flight
        //Можливе лише якщо політ не має квитків.
        [Route("api/Flights/DeleteFlight/id:{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            try
            {
                Flight flight = await _context.Flights.FindAsync(id);
                if (flight == null)
                {
                    return NotFound(new { error = "Flight with such Id not found" });
                }
                if (flight.FlightTickets != null)
                {
                    if (flight.FlightTickets.Any())
                    {
                        return BadRequest(new { error = "Flight has sold tickets and cannot be deleted" });
                    }
                }

                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();

                return Ok($"Flight with id: {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with deleting record from DB. Exception Type:\n" + ex.GetType() });
            }

        }
    }
}
