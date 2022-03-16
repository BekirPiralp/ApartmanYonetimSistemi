using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class DaireSakini : Entity
    {
        public ObjectId Apartman { get; set; }
        public ObjectId Daire { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
