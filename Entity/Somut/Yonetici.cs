using EntityLayer.Oznitelik;
using MongoDB.Bson;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "Yonetici")]
    public class Yonetici:Entity
    {
        public int Apartman { get; set; }
        public int DaireSakini { get; set; }
    }
}
