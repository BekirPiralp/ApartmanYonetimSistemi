using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Gider : Entity
    {
        public int Apartman { get; set; }
        public decimal Tutar { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public int Tip { get; set; }
    }
}
