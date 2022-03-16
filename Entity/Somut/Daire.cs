using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Daire : Entity
    {
        public ObjectId Apartman { get; set; }
        public int KapiNo { get; set; }
    }
}
