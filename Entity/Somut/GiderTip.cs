using EntityLayer.Oznitelik;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "GiderTipleri")]
    public class GiderTip : Entity
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
    }
}
