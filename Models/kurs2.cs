using efcoreApp.Models;

namespace efcoreApp
{
    public class Kurs2
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public int? OgretmenId { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>();
    }
}