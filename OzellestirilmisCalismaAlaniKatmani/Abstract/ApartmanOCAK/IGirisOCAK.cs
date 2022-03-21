using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK
{
    public interface IGirisOCAK
    {
        /**
         * Silinmemiş durumda olan lar getirilecek
         * Silinmiş olarak işaretlenmiş ise null dödürülecek
         *      Genel NOT: burada benden istenen temel işlemler istendiği için yönetici atamma veya 
         *      yöneticinin taşınması durumları için bir işlem yapılmayıp bunları
         *      sistem üzerinden ayarlanacak yani veri tabanı
         */
        Yonetici YoneticiGetir(string TC);//Daire sakini olarak sildurumu silinmiş ise null dönecek

        DaireSakini DaireSakiniGetir(string TC);
    }
}
