using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters
{
    public class Validation : ValidationAttribute
    {
        private int FirstNameLenght { get;}

        public Validation(int firstNameLenght)
        {
            FirstNameLenght = firstNameLenght;
        }

        private string GetErrorMessage() => "The lenght of the FirstName and LastName is less than 4 characters.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value.ToString()!.Length < FirstNameLenght ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }
    }
}
