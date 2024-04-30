namespace DataLayer.Models
{
    public class Laptop
    {
        public Laptop(Guid laptopId, string modelName, Guid specificationsId)
        {
            LaptopId = laptopId;
            ModelName = modelName;
            SpecificationsId = specificationsId;
        }

        public Guid LaptopId { get; set; }
        public string ModelName { get; set; }
        public Guid SpecificationsId { get; set; }
        public Specifications Specifications { get; set; } // 2. i
    }
}
