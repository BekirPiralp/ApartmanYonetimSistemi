using EntityLayer.Oznitelik;
using MongoDB.Bson;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "Borclar")]
    public class Borc : Entity
    {
        public int Apartman { get; set; }
        public int DaireSakini { get; set; }
        public decimal BorcMiktari { get; set; }
        public decimal OdemeMiktari { get; set; }
        public decimal Kalan { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
    }
}
