namespace efcoreApp
{
    public class Kurs
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>();
    }
}