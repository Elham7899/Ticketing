using System.ComponentModel.DataAnnotations;

namespace Ticketing.DTOModels.ValidationAttributes;

public class BirthDateValidationAttribute : ValidationAttribute
{
    public DateTime? MinDate { get; set; }
    public DateTime MaxDate { get; set; }

    public BirthDateValidationAttribute()
    {
        MinDate = new DateTime(1900, 01, 01);
        MaxDate = DateTime.Now;
    }

    public override bool IsValid(object? value)
    {
        if (MinDate.HasValue && (DateTime)value < MinDate)
        {
            return false;
        }

        if ((DateTime)value > MaxDate)
        {
            return false;
        }

        return true;
    }
}
