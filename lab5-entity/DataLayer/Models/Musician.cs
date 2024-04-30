namespace DataLayer.Models
{
    public class Musician
    {
        public Musician(Guid musicianId, string musicianName)
        {
            MusicianId = musicianId;
            MusicianName = musicianName;
            Instruments = new List<Instrument>();
        }
        public Guid MusicianId { get; set; }
        public string MusicianName { get; set; }
        public ICollection<Instrument> Instruments { get; set; } // 2. iii
    }
}
