using Biblioteca.Services.Models;
using Biblioteca.Services.Services.LoanService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Web.API.Controllers
{
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService loanService;

        public LoanController(ILogger<LoanController> logger, ILoanService loanService)
        {
            _logger = logger;
            this.loanService = loanService;
        }

        [Route("api/Loans")]
        [HttpGet]
        public IEnumerable<LoanModel> GetLoans()
        {
            return loanService.GetLoans();
        }

        [Route("api/Loans/{loanId}")]
        [HttpGet]
        public LoanModel GetLoanById([FromRoute] Guid loanId)
        {
            return loanService.GetLoanByID(loanId);
        }

        [Route("api/Loans")]
        [HttpPost]
        public LoanModel InsertLoans([FromBody] LoanModel loan)
        {
            return loanService.InsertLoan(loan);
        }

        [Route("api/Loans/{loanId}")]
        [HttpPut]
        public LoanModel UpdateLoan([FromBody] LoanModel loan, [FromRoute] Guid loanId)
        {
            return loanService.UpdateLoan(loanId, loan);
        }

        [Route("api/Loans/{loanId}")]
        [HttpDelete]
        public void DeleteLoan([FromRoute] Guid loanId)
        {
            loanService.DeleteLoan(loanId);
        }
    }
}
