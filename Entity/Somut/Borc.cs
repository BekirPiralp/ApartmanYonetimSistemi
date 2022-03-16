using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Borc : Entity
    {
        public ObjectId Apartman { get; set; }
        public ObjectId DaireSakini { get; set; }
        public decimal BorcMiktari { get; set; }
        public decimal OdemeMiktari { get; set; }
        public decimal Kalan { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
    }
}
