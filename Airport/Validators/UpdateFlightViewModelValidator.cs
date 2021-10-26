using Airport.Constants;
using Airport.Data;
using Airport.Data.Entities;
using Airport.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Airport.Validators
{
    public class UpdateFlightViewModelValidator : AbstractValidator<UpdateFlightViewModel>
    {
        private readonly AppEFContext _context;

        public UpdateFlightViewModelValidator(AppEFContext context)
        {
            _context = context;

            RuleFor(x => x)
                .Must(BeArrivalDateMoreThanDepartureDate).WithMessage("Arrival Date has to be more than Departure Date");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .Must(BeExistingId).WithMessage("Flight with such id does not exist");
            RuleFor(x => x.Number)
                .MaximumLength(ValidationConstants.FlightNumberMaxLength)
                    .WithMessage($"Maximum Length of Number is {ValidationConstants.FlightNumberMaxLength}");
            RuleFor(x => x.DepartureFrom)
                .MaximumLength(ValidationConstants.CityNameMaxLength)
                    .WithMessage($"Maximum Length of DepartureFrom is {ValidationConstants.CityNameMaxLength}");
            RuleFor(x => x.ArrivalTo)
                .MaximumLength(ValidationConstants.CityNameMaxLength)
                    .WithMessage($"Maximum Length of ArrivalTo is {ValidationConstants.CityNameMaxLength}");
            RuleFor(x => x.DepartureDate)
                .Must(BeAValidDate).WithMessage("DepartureDate date is wrong");
            RuleFor(x => x.ArrivalDate)
                .Must(BeAValidDate).WithMessage("ArrivalDate date is wrong");
        }

        private bool BeAValidDate(DateTime? date)
        {
            if (date == null)
                return true;
            else
                return !date.Equals(default(DateTime));
        }

        private bool BeArrivalDateMoreThanDepartureDate(UpdateFlightViewModel model)
        {
            try
            {
                Flight foundFlight = _context.Flights.Find(model.Id);
                if (foundFlight != null)
                {
                    if (model.ArrivalDate == null && model.DepartureDate == null)
                        return true;
                    else if (model.ArrivalDate == null)
                        return foundFlight.ArrivalDate > model.DepartureDate;
                    else if (model.DepartureDate == null)
                        return model.ArrivalDate > foundFlight.DepartureDate;
                    else
                        return model.ArrivalDate > model.DepartureDate;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool BeExistingId(int id)
        {
            try
            {
                Flight foundFlight = _context.Flights.Find(id);
                if (foundFlight == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
