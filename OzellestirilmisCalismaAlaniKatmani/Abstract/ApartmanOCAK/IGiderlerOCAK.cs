using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK
{
    public interface IGiderlerOCAK
    {

        void GiderOlustur(int apartman, decimal tutar, int tip); // otomatik dönemi alır

        void GiderOlustur(int apartman, decimal tutar, String aciklama);//otomatik dönemi alır sistemden
        
        List<Gider> GiderGetir(int apartman); // apartmana ait tüm giderler
        
        List<Gider> GiderGetir(int apartman, int ay, int yil);

    }
}
