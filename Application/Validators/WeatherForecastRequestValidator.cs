using Application.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class WeatherForecastRequestValidator : AbstractValidator<WeatherForecastRequest>
    {
        public WeatherForecastRequestValidator()
        {
            RuleFor(x => x.Latitude)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Latitude required");

            RuleFor(x => x.Latitude)
               .Cascade(CascadeMode.Stop)
               .InclusiveBetween(-90, 90)
               .WithMessage("Latitude must be in rage -90 to 90");

            RuleFor(x => x.Longitude)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Longitude required");

            RuleFor(x => x.Longitude)
              .Cascade(CascadeMode.Stop)
              .InclusiveBetween(-180, 180)
              .WithMessage("Longitude must be in rage -180 to 180");


            RuleFor(x => x).Custom(CustomValidation);
        }

        private void CustomValidation(WeatherForecastRequest request, ValidationContext<WeatherForecastRequest> validationContext)
        {
            if (request.DailyDataSets?.Count > 0 && request.Timezone == null)
            {
                validationContext.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(request.Timezone), "Timezone is required if daily variables are selected."));
                return;
            }

        }
    }
}
