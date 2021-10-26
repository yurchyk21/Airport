using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Data.Entities;
using static Airport.Models.TicketViewModels;
using AutoMapper;
using Airport.Models;

namespace Airport.Controllers
{
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public TicketsController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        //отримання кількості придбаних квитків за певний часовий проміжок (від...до)
        [Route("api/Tickets/PeriodTickets")]
        [HttpPost]
        public async Task<IActionResult> GetPeriodTickets([FromForm] GetPeriodTicketViewModel model)
        {
            try
            {
                List<GetActiveTicketViewModel> tickets
                    = await _context
                    .Tickets
                    .Where(x => x.BuyDate>=model.From && x.BuyDate <= model.To)
                    .OrderBy(x => x.BuyDate)
                    .Include(x => x.FlightTicket.Flight)
                    .Select(x => _mapper.Map<GetActiveTicketViewModel>(x))
                    .ToListAsync();

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        
        // - отримання списку всіх скасованих квитків
        [Route("api/Tickets/UnactiveTickets")]
        [HttpGet]
        public async Task<IActionResult> GetUnactiveTickets()
        {
            try
            {
                List<GetActiveTicketViewModel> tickets
                    = await _context
                    .Tickets
                    .Where(x => x.IsActive==false)
                    .OrderBy(x => x.Id)
                    .Include(x => x.FlightTicket.Flight)
                    .Select(x => _mapper.Map<GetActiveTicketViewModel>(x))
                    .ToListAsync();

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        //отримання списку всіх активних квитків із позначенням які мають відбутися, а які вже завершені. + пагінація
        [Route("api/Tickets/ActiveTickets/page:{page:int}")]
        [HttpGet]
        public async Task<IActionResult> GetActiveTickets(int page)
        {
            try
            {
                int pageSize = Constants.ValidationConstants.TicketsListPaginationSize;

                List<GetActiveTicketViewModel> tickets
                    = await _context
                    .Tickets
                    .Where(x=>x.IsActive==true)
                    .OrderBy(x=>x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.FlightTicket.Flight)
                    .Select(x => _mapper.Map<GetActiveTicketViewModel>(x))
                    .ToListAsync();

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }



        //отримання кількості придбаних квитків клієнтом(по номеру паспорту або по ПІБ)
        [Route("api/Tickets/ClientTicketsQuantity/find:{searchString}")]
        [HttpGet]
        public async Task<IActionResult> GetClientTicketsQuantity(string searchString)
        {
            try
            {
                if (String.IsNullOrEmpty(searchString))
                    return BadRequest(new { error = "searchString is Required"});
                int ticketsQuantity
                    = await _context
                    .Tickets
                    .Where(x =>
                        x.PassengerFullName.ToLower().Contains(searchString.ToLower())
                        || x.PassengerPassport.ToLower().Contains(searchString.ToLower()))
                    .CountAsync();

                return Ok(new {FoundTicketsQuantity = ticketsQuantity });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        // - визначення клієнта, що придбав найбільше квитків
        //Вірніше ліст клієнтів з урахуванням того що у декількох клієнтів може бути
        //однакова максимальна кількість квитків
        [Route("api/Tickets/MaximumTicketsClients")]
        [HttpGet]
        public async Task<IActionResult> GetMaximumTicketsClient()
        {
            try
            {
                List<GetMaximumTicketsClient> clients
                    = _context
                    .Tickets
                    .AsEnumerable()
                    .GroupBy(x => x.PassengerPassport)
                    .Select(group
                        => new GetMaximumTicketsClient
                        {
                            PassengerPassport = group.Key,
                            PassengerFullName = group.FirstOrDefault().PassengerFullName,
                            TicketsQuantity = group.Count()
                        })
                    .GroupBy(group => group.TicketsQuantity)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault()
                    .ToList();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        //  - визначення рейсу(ів) на який купили найбільше та найменше білетів 
        //Вірніше ліст клієнтів з урахуванням того що у декількох клієнтів може бути
        //однакова максимальна кількість квитків
        [Route("api/Tickets/MaxMinTicketsFlights")]
        [HttpGet]
        public async Task<IActionResult> GetMaxMinTicketsFlights()
        {
            try
            {
                var flights = _context
                    .Flights
                    .Include(x => x.FlightTickets)
                    .Select(x => _mapper.Map<GetTicketsQuantityFlight>(x))
                    .AsEnumerable()
                    .GroupBy(x => x.TicketsQuantity)
                    .OrderByDescending(x => x.Key);

                List<GetTicketsQuantityFlight> maxTicketsFlights
                    = flights
                    .FirstOrDefault()
                    .ToList();

                List<GetTicketsQuantityFlight> minTicketsFlights
                    = flights
                    .LastOrDefault()
                    .ToList();

                return Ok(new { maximumTicketsFlight=maxTicketsFlights , minimumTicketsFlight = minTicketsFlights });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }

        // - визначення міста з якого вилітає найбільше пасажирів (по кількості білетів)
        //  - визначення рейсу(ів) на який купили найбільше та найменше білетів 
        //Вірніше ліст клієнтів з урахуванням того що у декількох клієнтів може бути
        //однакова максимальна кількість квитків
        [Route("api/Tickets/MaxClientsDepartureFrom")]
        [HttpGet]
        public async Task<IActionResult> GetCityMaxClientsDepartureFrom()
        {
            try
            {
                List<GetCityMaxClientsDepartureFromViewModel> maxClientsDepartureCities
                    = _context
                    .Flights
                    .Include(x => x.FlightTickets)
                    .AsEnumerable()
                    .GroupBy(x=>x.FlightTickets.Count)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault()
                    .Select(x => new GetCityMaxClientsDepartureFromViewModel
                    {
                        ClientsQuantity = x.FlightTickets.Count,
                        CityName = x.DepartureFrom
                    })
                    .ToList();

            

                return Ok(maxClientsDepartureCities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with getting data from base. Exception Type:\n" + ex.GetType() });
            }
        }




        //створення квитка із прив'язкою до рейсу
        //Ticket має мати унікальне ім'я
        //Не може бути створено Ticket якщо бажане місце на цьому літаку вже зайнято.
        //Усі перевірки на Валідаторі.
        [Route("api/Tickets/AddTicket")]
        [HttpPost]
        public async Task<IActionResult> PostTicket([FromForm] AddTicketViewModel model)
        {
            try
            {
                Flight foundFlight = await _context.Flights.FindAsync(model.FlightId);
                Ticket ticket  = _mapper.Map<Ticket>(model);
                _context.Tickets.Add(ticket);
                FlightTicket flightTicket = new () { Flight = foundFlight, Ticket = ticket };
                _context.FlightTickets.Add(flightTicket);
                await _context.SaveChangesAsync();
                return Ok($"Ticket is added to database with id:{ticket.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with record creation. Exception Type:\n" + ex.GetType() });
            }
        }

        // скасування квитка (зробити квиток не активним)
        [Route("api/Tickets/DeActivateTicket/id:{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeActivateTicket(int id)
        {
            try
            {

                Ticket ticket = await _context.Tickets.FindAsync(id);
                if (ticket == null)
                {
                    return NotFound(new { error = "Flight with such Id not found" });
                }

                ticket.IsActive = false;
                await _context.SaveChangesAsync();
                return Ok($"Ticket with id: {id} is not active now.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Problem with deactivating ticket. Exception Type:\n" + ex.GetType() });
            }
        }

    }
}
