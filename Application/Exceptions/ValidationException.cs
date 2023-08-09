using FluentValidation.Results;


namespace Application.Exceptions
{
 
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException (ValidationResult validationResults) 
        {
            ValidationErrors = new List<string>();
            foreach (var item in validationResults.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }
    }
}
