using System.ComponentModel.DataAnnotations;

namespace Icaz.com.Validation
{
    public class Cinsiyet_Validation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Cinsiyet = value.ToString().ToLower();


            if ((Cinsiyet) == "erkek" || Cinsiyet == "kadın")
            {

                return ValidationResult.Success;

            }
            else
            {
                return new ValidationResult("Cinsiyet Kadın veya erkek Olmalıdır");
            }

        }
    }
}

