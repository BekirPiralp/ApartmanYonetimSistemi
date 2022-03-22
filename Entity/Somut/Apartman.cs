using EntityLayer.Oznitelik;

namespace EntityLayer.Somut
{
    [Entity(CollectionName = "Apartmanlar")]
    public class Apartman : Entity
    {
        string Ad { get; set; }
        string Ilce { get; set; }
        string Il { get; set; }
        string Ulke { get; set; }
    }
}
