using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Presenters.Common
{
    public class ModelValidation
    {
        public void Validate(object model)
        {
            string errorMessage = "";
            List<ValidationResult> result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, result, true);
            if (!isValid)
            {
                foreach (var item in result)
                    errorMessage += "- " + item.ErrorMessage + "\n";
                throw new Exception(errorMessage);
            }
        }
    }
}
