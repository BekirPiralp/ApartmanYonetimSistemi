using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Daire : Entity
    {
        public int Apartman { get; set; }
        public int KapiNo { get; set; }
    }
}
