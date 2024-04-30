namespace DataLayer.Models
{
    public class Instrument
    {
        public Instrument(Guid instrumentId, string instrumentName)
        {
            InstrumentId = instrumentId;
            InstrumentName = instrumentName;
            Musicians = new List<Musician>();
        }
        public Guid InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public ICollection<Musician> Musicians { get; set; } // 2. iii
    }
}
