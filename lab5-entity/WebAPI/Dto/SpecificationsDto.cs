using DataLayer.Models;

namespace WebAPI.Dto;

public class SpecificationsDto
{
    public Guid SpecificationsId { get; set; }
    public Guid LaptopId { get; set; }
    public string Cpu { get; set; }
    public string Gpu { get; set; }
    public int Memory { get; set; }
}
