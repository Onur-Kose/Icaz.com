using System.ComponentModel.DataAnnotations;

namespace Icaz.com.Validation
{
    public class Birthdate_Validation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime dogum = new DateTime();

            dogum = Convert.ToDateTime(value);
            if ((dogum.Date) < DateTime.Now.Date)
            {
                if ((DateTime.Now.Date - dogum.Date).Days > 6574)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("18 yaşından küçük olamazsınız");
                }


            }
            else
            {
                return new ValidationResult("dogum tarihiniz bu gün veya bu günden büyük olamaz");
            }

        }
    }
}
