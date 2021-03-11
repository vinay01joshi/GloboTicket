using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    class ValidationExecption : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationExecption(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach(var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
