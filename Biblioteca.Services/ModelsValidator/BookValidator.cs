using Biblioteca.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.ModelsValidator
{
    public class BookValidator : AbstractValidator<BookModel>
	{
		public BookValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Title).Length(0, 50);
			RuleFor(x => x.Author).Length(0, 50);
			RuleFor(x => x.Publisher).Length(0, 10);
			RuleFor(x => x.Year).NotEmpty();
		}
	}
}
