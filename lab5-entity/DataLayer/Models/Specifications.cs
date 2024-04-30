namespace DataLayer.Models
{
    public class Specifications
    {
        public Specifications(Guid specificationsId, string cpu, string gpu, int memory, Guid laptopId)
        {
            SpecificationsId = specificationsId;
            Cpu = cpu;
            Gpu = gpu;
            Memory = memory;
            LaptopId = laptopId;
        }
        public Guid SpecificationsId { get; set; }
        public Guid LaptopId { get; set; }
        public string Cpu {  get; set; }
        public string Gpu { get; set; }
        public int Memory { get; set; }
        public Laptop Laptop {  get; set; }
    }
}
