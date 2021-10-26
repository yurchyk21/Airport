using Airport.Constants;
using Airport.Data;
using Airport.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Validators
{
    public class AddFlightViewModelValidator : AbstractValidator<AddFlightViewModel>
    {
        private readonly AppEFContext _context;


        public AddFlightViewModelValidator(AppEFContext context)
        {
            _context = context;

            RuleFor(x => x)
                .Must(BeUniqueFlight).WithMessage("Flight with such number, departure from & departure date already exist")
                .Must(BeArrivalDateMoreThanDepartureDate).WithMessage("Arrival Date has to be more than Departure Date");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number is required!")
                .MaximumLength(ValidationConstants.FlightNumberMaxLength).WithMessage($"Maximum Length of Number is {ValidationConstants.FlightNumberMaxLength}");
            RuleFor(x => x.DepartureFrom)
                .NotEmpty().WithMessage("DepartureFrom is required")
                .MaximumLength(ValidationConstants.CityNameMaxLength).WithMessage($"Maximum Length of DepartureFrom is {ValidationConstants.CityNameMaxLength}");
            RuleFor(x => x.ArrivalTo)
                .NotEmpty().WithMessage("ArrivalTo is required")
                .MaximumLength(ValidationConstants.CityNameMaxLength).WithMessage($"Maximum Length of ArrivalTo is {ValidationConstants.CityNameMaxLength}");
            RuleFor(x => x.DepartureDate)
                .NotEmpty().WithMessage("DepartureDate is required")
                .Must(BeAValidDate).WithMessage("DepartureDate date is wrong");
            RuleFor(x => x.ArrivalDate)
                .NotEmpty().WithMessage("ArrivalDate is required")
                .Must(BeAValidDate).WithMessage("ArrivalDate date is wrong");


        }
        private bool BeUniqueFlight(AddFlightViewModel flight)
        {
            try
            {
                var foundFlight = _context
                    .Flights
                    .FirstOrDefault
                    (x => x.Number == flight.Number
                    && x.DepartureDate == flight.DepartureDate
                    && x.DepartureFrom == flight.DepartureFrom);
                return foundFlight == null;
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

        private bool BeArrivalDateMoreThanDepartureDate(AddFlightViewModel flight)
        {
            return flight.ArrivalDate > flight.DepartureDate;
        }

    }
}
