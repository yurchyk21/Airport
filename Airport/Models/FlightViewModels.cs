using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public record GetFlightViewModel
    {
        public string Id { get; init; }
        public string Number { get; init; }
        public string DepartureFrom { get; init; }
        public string ArrivalTo { get; init; }
        public DateTime DepartureDate { get; init; }
        public DateTime ArrivalDate { get; init; }
    }
    public record UpdateFlightViewModel
    {
        public int Id { get; init; }
        public string Number { get; init; }
        public string DepartureFrom { get; init; }
        public string ArrivalTo { get; init; }
        public DateTime? DepartureDate { get; init; }
        public DateTime? ArrivalDate { get; init; }
    }
    public record AddFlightViewModel
    {
        public string Number { get; init; }
        public string DepartureFrom { get; init; }
        public string ArrivalTo { get; init; }
        public DateTime DepartureDate { get; init; }
        public DateTime ArrivalDate { get; init; }
    }

    public record GetTicketsQuantityFlight
    {
        public int TicketsQuantity { get; init; }
        public string Number { get; init; }
        public string DepartureFrom { get; init; }
        public string ArrivalTo { get; init; }
        public DateTime DepartureDate { get; init; }
        public DateTime ArrivalDate { get; init; }


    }

}
