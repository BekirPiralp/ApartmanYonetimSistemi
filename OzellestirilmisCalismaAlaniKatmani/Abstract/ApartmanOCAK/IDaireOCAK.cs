using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK
{
    public interface IDaireOCAK
    {
        /**
         * Atalı daire sakini var ise onu silinmiş durumuna geçirecek ve yeni daire sakinini atayacak.
         * (apartmana yeni eklene kişi için)Eğerki Daire Sakinin TC sinde kayıtlı bir daire sakini daha önce sistemde mevcut ise
         *  o daire sakininin apartman, daire ve sildurumu yeniden düzenlenecek.
         */
        void DaireTanimla(int apartman, DaireSakini daireSakini,Daire daire);
        
        void DaireTanimla(int apartman, DaireSakini daireSakini, int daireSNO);
    }
}
