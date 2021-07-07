using Biblioteca.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.ModelsValidator
{
    public class LoanValidator : AbstractValidator<LoanModel>
    {
		public LoanValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.ClientId).NotNull();
			RuleFor(x => x.BookId).NotNull();
			RuleFor(x => x.LoanDate).LessThanOrEqualTo(DateTime.UtcNow);
		}
	}
}
