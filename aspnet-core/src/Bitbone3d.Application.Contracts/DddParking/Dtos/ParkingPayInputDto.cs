using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingPayInputDto : IValidatableObject
{
    [Required]
    [StringLength(ParkingConsts.MaxLicensePlateNoLength)]
    public string LicensePlateNo { get; set; } = default!;

    [Required] public decimal Amount { get; set; }

    /// <summary>Determines whether the specified object is valid.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection that holds failed-validation information.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Amount <= 0)
        {
            yield return new ValidationResult("支付金额必须大于0", new[] { nameof(Amount) });
        }
    }
}