using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Gider : Entity
    {
        public ObjectId Apartman { get; set; }
        public decimal Tutar { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public string Tip { get; set; }
    }
}
