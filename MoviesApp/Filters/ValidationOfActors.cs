using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters
{
    public class ValidationOfActors:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Length < 4)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
