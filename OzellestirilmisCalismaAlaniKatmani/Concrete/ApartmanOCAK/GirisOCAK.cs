using EntityLayer.EntityDurum;
using EntityLayer.Somut;
using IsYapmaKatmani.Abstract;
using IsYapmaKatmani.NesneOlustur;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.Concrete.ApartmanOCAK
{
    public class GirisOCAK : IGirisOCAK
    {
        private IIsKatmaniDaireSakiniServisi _daireSakiniServisi;
        private IIsKatmaniYoneticiServisi _yoneticiServisi;
        public GirisOCAK()
        {
            _daireSakiniServisi = IsKatmaniNesneOlusturucu.Olusturucu().DaireSakiniServisi;
        }
        public DaireSakini DaireSakiniGetir(string TC)
        {
            DaireSakini result = null;
            if (TC.Trim().Length != 11)
                throw new ArgumentNullException("Geçersiz Arguman lütfen geçerli bir tc yollayınız");
            else
            {
                try
                {
                    result = _daireSakiniServisi.Getir(TC);
                }
                catch (Exception)
                {
                    throw new Exception("Veriler getirilirken hata oluştu");
                }
            }
            return result;
        }

        public Yonetici YoneticiGetir(string TC)
        {
            Yonetici result = null;
            if(TC.Trim().Length!=11)
                throw new ArgumentNullException("Geçersiz Arguman lütfen geçerli bir tc yollayınız");
            else
            {
                DaireSakini daireSakini = null;
                daireSakini= _daireSakiniServisi.Getir(TC);
                if(daireSakini != null && daireSakini.SilDurum == SilDurum.Silinmemis)
                {
                    result = _yoneticiServisi.Getir(p => p.DaireSakini == daireSakini.SNo && p.Apartman == daireSakini.Apartman);
                }
            }
            return result;
        }
    }
}
