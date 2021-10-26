using Bogus;
using Airport.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Data
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            int fakeFlightsQuantity = 20; //кількість фейкових польотів для сідера
            int fakeTicketsQuantity = 100; //кількість фейкових квитків для сідера
            int fakeFlightId = 1; //індекс для ІД польоту
            int fakeTicketId = 1; // індекс для ІД квитка

            Faker<Flight> fakerFlight = new Faker<Flight>("en_US")
             .RuleFor(a => a.Id, f => fakeFlightId++)
             .RuleFor(a => a.Number, f => f.Random.String(3, 'A', 'Z') +f.UniqueIndex)
             .RuleFor(a => a.DepartureFrom, f => f.Address.City())
             .RuleFor(a => a.ArrivalTo, f => f.Address.City())
             .RuleFor(a => a.DepartureDate, f => f.Date.Between(f.Date.Past(1), f.Date.Future(1)))
             .RuleFor(a => a.ArrivalDate, (f,fl) => fl.DepartureDate.AddHours(f.Random.Double(0.5,240)));

            List<Flight> fakeFlights = fakerFlight.Generate(fakeFlightsQuantity);
           

            modelBuilder.Entity<Flight>().HasData(fakeFlights);

            Faker<Ticket> fakerTicket = new Faker<Ticket>("en_US")
             .RuleFor(a => a.Id, f => fakeTicketId++)
             .RuleFor(a => a.Number, f => f.Random.String(5,'A','Z') + f.UniqueIndex)
             .RuleFor(a => a.IsActive, f => true)
             .RuleFor(a => a.PassengerFullName, f => f.Person.FullName)
             .RuleFor(a => a.BuyDate, f => f.Date.Past(1))
             .RuleFor(a => a.PassengerPassport, f => f.Random.String(7, 'A', 'Z') + f.UniqueIndex)
             .RuleFor(a => a.Place, f => f.Random.Char('A','L').ToString()+ f.UniqueIndex)
             .RuleFor(a => a.Price, f => decimal.Parse(f.Commerce.Price()));

            List<Ticket> fakeTickets = fakerTicket.Generate(fakeTicketsQuantity);

            modelBuilder.Entity<Ticket>().HasData(fakeTickets);


            List<FlightTicket> flightTickets = new();
            Random random = new ();
            for (int i = 0; i < fakeTickets.Count; i++)
            {
                var randomFakeFlight = fakeFlights[random.Next(0, fakeFlights.Count - 1)];
                if(randomFakeFlight.DepartureDate < DateTime.Now)
                {
                    fakeTickets[i].IsActive = false;
                }
                flightTickets.Add(
                 new FlightTicket
                 {
                     Id = i+1,
                     TicketId = fakeTickets[i].Id,
                     FlightId = randomFakeFlight.Id,
                 });
            }
            modelBuilder.Entity<FlightTicket>().HasData(flightTickets);

        }
    }
}
