using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<User>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object");
                });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
               .NotEmpty().WithMessage("Is necessary to inform the BIRTH DATE.")
               .NotNull().WithMessage("Is necessary to inform the BIRTH DATE.");

            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("Is necessary to inform the NAME.")
               .NotNull().WithMessage("Is necessary to inform the BIRTH DATA.");
        }
    }
}
