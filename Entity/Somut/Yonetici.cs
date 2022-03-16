using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Yonetici:Entity
    {
        public ObjectId Apartman { get; set; }
        public string DaireSakini { get; set; }
    }
}
