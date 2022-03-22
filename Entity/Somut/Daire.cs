using EntityLayer.Oznitelik;
using MongoDB.Bson;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "Daireler")]
    public class Daire : Entity
    {
        public int Apartman { get; set; }
        public int KapiNo { get; set; }
    }
}
