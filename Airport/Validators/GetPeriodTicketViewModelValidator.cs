using Airport.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Airport.Models.TicketViewModels;

namespace Airport.Validators
{
    public class GetPeriodTicketViewModelValidator : AbstractValidator<GetPeriodTicketViewModel>
    {

        public GetPeriodTicketViewModelValidator()
        {

            RuleFor(x => x)
                .Must(BeToDateMoreThanFromDate).WithMessage("End Period Date has to be More Than Begin Period Date");
            RuleFor(x => x.From)
                .NotNull().WithMessage("Begin date is required")
                .Must(BeAValidDate).WithMessage("Begin date is wrong");
            RuleFor(x => x.To)
                .NotNull().WithMessage("End date is required")
                .Must(BeAValidDate).WithMessage("End date is wrong");


        }


        private bool BeAValidDate(DateTime? date)
        {
                return !date.Equals(default(DateTime));
        }
        private bool BeToDateMoreThanFromDate(GetPeriodTicketViewModel model)
        {
            if (model.From != null && model.To != null)
                return model.To > model.From;
            else
                return true;
        }   

    }
}
