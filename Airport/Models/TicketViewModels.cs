using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class TicketViewModels
    {
        public record AddTicketViewModel
        {
            public int FlightId { get; init; }
            public string Number { get; init; }
            public string PassengerFullName { get; init; }
            public string PassengerPassport { get; init; }
            public decimal Price { get; init; }
            public string Place { get; init; }
            public DateTime BuyDate { get; init; }
            public bool IsActive { get; init; }

        }

        public record GetActiveTicketViewModel
        {
            public string Number { get; init; }
            public string PassengerFullName { get; init; }
            public string PassengerPassport { get; init; }
            public decimal Price { get; init; }
            public string Place { get; init; }
            public DateTime BuyDate { get; init; }
            public string FlightNumber { get; set; }
            public bool IsFlightFinished { get; set; }
        }

        public record GetPeriodTicketViewModel
        {
            public DateTime? From { get; init; }
            public DateTime? To { get; init; }
        }

        public record GetClientTicketsQuantityViewModel
        {
            public string SearchFor { get; init; }
        }

        public record GetMaximumTicketsClient
        {
            public string PassengerFullName { get; init; }
            public string PassengerPassport { get; init; }
            public int TicketsQuantity { get; init; }
        }

        public record GetCityMaxClientsDepartureFromViewModel
        {
            public string CityName { get; init; }
            public int ClientsQuantity { get; init; }
        }
    }
}
