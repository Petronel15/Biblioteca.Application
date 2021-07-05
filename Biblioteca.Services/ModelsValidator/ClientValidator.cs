using Biblioteca.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.ModelsValidator
{
    public class ClientValidator : AbstractValidator<ClientModel>
    {
		public ClientValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.FirstName).Length(0, 50);
			RuleFor(x => x.LastName).Length(0, 50);
			RuleFor(x => x.Phone).Length(0, 10);
			RuleFor(x => x.Adress).Length(0, 100);
		}
	}
}
