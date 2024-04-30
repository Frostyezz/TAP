using DataLayer.Models;

namespace WebAPI.Dto;

public class LaptopDto
{
    public Guid LaptopId { get; set; }
    public string ModelName { get; set; }
    public Guid SpecificationsId { get; set; }
}
