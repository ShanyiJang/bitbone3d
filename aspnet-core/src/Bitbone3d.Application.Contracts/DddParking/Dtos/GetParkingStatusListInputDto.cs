using Volo.Abp.Application.Dtos;

namespace Bitbone3d.DddParking.Dtos;

public class GetParkingStatusListInputDto:ISortedResultRequest
{
    public bool? IsAvailable { get; set; }

    /// <summary>
    /// Sorting information.
    /// Should include sorting field and optionally a direction (ASC or DESC)
    /// Can contain more than one field separated by comma (,).
    /// </summary>
    /// <example>
    /// Examples:
    /// "Name"
    /// "Name DESC"
    /// "Name ASC, Age DESC"
    /// </example>
    public string? Sorting { get; set; }
}