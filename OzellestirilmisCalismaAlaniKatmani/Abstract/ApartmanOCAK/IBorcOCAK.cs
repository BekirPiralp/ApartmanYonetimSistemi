using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK
{
    public interface IBorcOCAK
    {
        //void borclandir(int apartman);// sil durumda olmayan tüm dairelere sakinlerine atayacak ve onların sayısına göre islem yapacak
        // geliştirme düşünülecek
        //List<Borc> BorcGetir(int apartman);

        List<Borc> GecmisOdenmemisBorcuGetir(int apartman,int daireSakini); // aparman ve daire sakinine tanımlı ödenmemiş

        List<Borc> GecmisBorcuGetir(int apartman, int daireSakini);//ödenmiş ve ödenmemiş

        //List<Borc,DaireSakini> ToplamBorcluGetir(int apratman, int ay, int yil);

        List<DaireSakini> ToplamBorcluGetir(int apartman);//hepsini tüm dönemler ödenmemiş

        decimal Borclumu(int apartman, int daireSakini);//borçlu değilse 0 diğer türlü >0 döner

        void BorcOde(decimal OdemeTutari, int Apartman, int DaireSakini); //Borç ödeme işlemi borcu var mı kontrol edilecek var ise zaman olarak en eski borcdan ödemeye başlanacak;



    }
}
