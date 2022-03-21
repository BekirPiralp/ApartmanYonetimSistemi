using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK
{
    public interface ITahakkukOCAK
    {
        /**
         * Apartman bilgisi sayesinde tüm kayıtlı (silinmemiş) 
         * daire sakinlerine borçlandırma yapacak
         * Dönem içi giderlerin hepsi tüm daire sakini (silinmemiş) sayısına bölünüp
         * her bir daire sakinine düşen miktarı ve aidat miktarı ile birlikte eklenecek
         */
        void TahakkukOlustur(int apartman); // aidat kontrol edilecek eğerki sistemde ekli aidat yok ise
                                            // aidat oluşturması istenecek

        void AidatTanimla(int apartman,Decimal tutar);

        Aidat AidatGetir(int apartman);//son girilmiş aidat yok ise null 
    }
}
