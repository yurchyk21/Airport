using Airport.Constants;
using Airport.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Airport.Models.TicketViewModels;

namespace Airport.Validators
{
    public class AddTicketViewModelValidator : AbstractValidator<AddTicketViewModel>
    {
        private readonly AppEFContext _context;

        public AddTicketViewModelValidator(AppEFContext context)
        {
            _context = context;

            RuleFor(x => x)
                .Must(BeUniqueTicket).WithMessage("Ticket with place and flight already exist");
            RuleFor(x => x.IsActive)
              .NotEmpty().WithMessage("IsActive is required!");
            RuleFor(x => x.FlightId)
               .NotEmpty().WithMessage("FlightId is required!")
               .Must(BeExistFlight).WithMessage("Flight with such id does not exist");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number is required!")
                .Must(BeUniqueNameTicket).WithMessage("Ticket with such number already exist")
                .MaximumLength(ValidationConstants.TicketNumberMaxLength).WithMessage($"Maximum Length of Number is {ValidationConstants.TicketNumberMaxLength}");
            RuleFor(x => x.PassengerFullName)
                .NotEmpty().WithMessage("PassengerFullName is required")
                .MaximumLength(ValidationConstants.PassengerFullNameMaxLength).WithMessage($"Maximum Length of PassengerFullName is {ValidationConstants.PassengerFullNameMaxLength}");
            RuleFor(x => x.PassengerPassport)
                .NotEmpty().WithMessage("PassengerPassport is required")
                .MaximumLength(ValidationConstants.PassengerPassportMaxLength).WithMessage($"Maximum Length of ArrivalTo is {ValidationConstants.PassengerPassportMaxLength}");
            RuleFor(x => x.Place)
                 .NotEmpty().WithMessage("Place is required")
                 .MaximumLength(ValidationConstants.PlaceNumberMaxLength).WithMessage($"Maximum Length of ArrivalTo is {ValidationConstants.PlaceNumberMaxLength}");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0m);
            RuleFor(x => x.BuyDate)
                .NotEmpty().WithMessage("BuyDate is required")
                .Must(BeAValidDate).WithMessage("BuyDate date is wrong");


        }
        private bool BeUniqueTicket(AddTicketViewModel model)
        {
            try
            {
                var foundTicket = _context.FlightTickets
                .Include(x => x.Ticket)
                .FirstOrDefault(x =>
                    x.FlightId == model.FlightId
                    && x.Ticket.Place == model.Place);

                return foundTicket == null;
            }
            catch (ArgumentNullException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool BeUniqueNameTicket(string number)
        {
            try
            {
                var foundTicket = _context.Tickets
                .FirstOrDefault(x=>x.Number == number);
                return foundTicket == null;
            }
            catch (ArgumentNullException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool BeExistFlight(int id)
        {
            try
            {
                var foundFlight = _context.Flights.FirstOrDefault(x=>x.Id == id);
                return foundFlight != null;
            }
           
            catch (Exception)
            {
                return false;
            }
        }
    }
}
