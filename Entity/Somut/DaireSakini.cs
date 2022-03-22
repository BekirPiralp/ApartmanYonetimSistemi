using EntityLayer.Oznitelik;
using MongoDB.Bson;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "DaireSakinleri")]
    public class DaireSakini : Entity
    {
        public int Apartman { get; set; }
        public int Daire { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
