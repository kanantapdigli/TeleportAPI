using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleportAPI.Application.Dtos.Teleport.Request;
using TeleportAPI.Application.Utilities;

namespace TeleportAPI.Application.Validators.Teleport
{
    public class TeleportGetMilesDifferenceDtoValidator : AbstractValidator<TeleportGetMilesDifferenceDto>
    {
        public TeleportGetMilesDifferenceDtoValidator()
        {
            RuleFor(x => x.FirstIata)
                .NotEmpty()
                .WithMessage(ErrorMessages.ShouldNotBeEmptyMessage("Iata"));

            RuleFor(x => x.SecondIata)
                .NotEmpty()
                .WithMessage(ErrorMessages.ShouldNotBeEmptyMessage("Iata"));

            RuleFor(x => x.FirstIata)
                .NotEqual(x => x.SecondIata)
                .WithMessage(ErrorMessages.ShouldNotBeTheSameMessage("Iatas"));

            RuleFor(x => x.FirstIata.Length)
                .Equal(3)
                .WithMessage(ErrorMessages.ShouldBeEqualMessage("First iata", 3))
                .When(x => x.FirstIata is not null);
            
            RuleFor(x => x.SecondIata.Length)
                .Equal(3)
                .WithMessage(ErrorMessages.ShouldBeEqualMessage("Second iata", 3))
                .When(x => x.SecondIata is not null);
        }
    }
}
