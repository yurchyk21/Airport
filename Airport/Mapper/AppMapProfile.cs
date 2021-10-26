
using Airport.Data.Entities;
using Airport.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Airport.Models.TicketViewModels;

namespace Airport.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<AddFlightViewModel, Flight>();
            CreateMap<UpdateFlightViewModel, Flight>();
            CreateMap<Flight, GetFlightViewModel>();
            
            CreateMap<AddTicketViewModel, Ticket>();
            CreateMap<Ticket, GetActiveTicketViewModel>()
                .ForMember(x => x.FlightNumber, opt => opt.MapFrom(x=>x.FlightTicket.Flight.Number))
                .ForMember(x => x.IsFlightFinished, opt => opt.MapFrom(x => x.FlightTicket.Flight.ArrivalDate<DateTime.Now));

            CreateMap<Flight, GetTicketsQuantityFlight>()
                .ForMember(x => x.TicketsQuantity, opt => opt.MapFrom(x => x.FlightTickets.Count));


            
        }
    }
}
