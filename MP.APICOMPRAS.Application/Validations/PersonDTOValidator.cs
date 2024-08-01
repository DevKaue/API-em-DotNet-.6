using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MP.APICOMPRAS.Application.DTOs;

namespace MP.APICOMPRAS.Application.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name deve ser informado!");
            RuleFor(x => x.Cellphone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cellphone deve ser informado!");
        }
    }
}