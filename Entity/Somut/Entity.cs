using EntityLayer.Soyut;
using MongoDB.Bson;

namespace EntityLayer.Somut
{
    public class Entity : IEntity
    {
        public ObjectId _id { get; set; }
        /// <summary>
        /// SNo = Sıra numarası
        /// </summary>
        public int SNo { get; set; }
        public bool SilDurum { get; set; }
    }
}
