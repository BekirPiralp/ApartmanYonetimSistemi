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
    /**
     * Güncelleme yapılacak
     */
    public class GiderlerOCAK:IGiderlerOCAK
    {
        private IIsKatmaniGiderServisi _giderServisi = IsKatmaniNesneOlusturucu.Olusturucu().GiderServisi;
        private IIsKatmaniGiderTipServisi _giderTipServisi = IsKatmaniNesneOlusturucu.Olusturucu().GiderTipServisi;
        
        public void GiderOlustur(int apartman,decimal tutar,int tip)
        {
            if (tip <0 || apartman <= 0 || tutar <0)
                throw new ArgumentNullException("Lütfen parametleri eksiksiz yollayınız");
            try
            {
                //GiderTip giderTip = _giderTipServisi.Getir(tip);
               // if (giderTip != null)
                //{
                    _giderServisi.Ekle(new Gider
                    {
                        Apartman = apartman,
                        Tutar = tutar,
                        Tip = tip,
                        Ay = DateTime.Now.Month,
                        Yil = DateTime.Now.Year
                    });
               // }
               // else
                //    throw new Exception("İlgili gider bulunamadı");
            }
            catch (Exception)
            {
                throw new Exception("Gider oluşturma sırasında hata oluştu");
            }
        }

        public void GiderOlustur(int apartman,decimal tutar,String aciklama)
        {
            if (aciklama.Trim().Equals("") && apartman <= 0 && !(tutar>0))
                throw new ArgumentNullException("Lütfen parametleri eksiksiz yollayınız");

            try
            {
                int giderTipID = _giderTipServisi.Ekle(new GiderTip { Ad = "Diğer", Aciklama = aciklama.Trim() });
                _giderServisi.Ekle(new Gider
                {
                    Apartman = apartman,
                    Tutar = tutar,
                    Tip = giderTipID,
                    Ay = DateTime.Now.Month,
                    Yil = DateTime.Now.Year
                });
            }
            catch (Exception)
            {
                throw new Exception("Gider oluşturma sırasında hata oluştu");
            }
        }

        public List<Gider> GiderGetir(int apartman)
        {
            List<Gider> result = null;
            try
            {
                result = _giderServisi.GetirHepsi(apartman);
            }
            catch (Exception)
            {
                throw new Exception("Veriler getiriliken hata oluştu");
            }
            return result;
        }

        public List<Gider> GiderGetir(int apartman, int ay,int yil)
        {
            List<Gider> result = null;
            try
            {
                result = _giderServisi.GetirHepsi(apartman, ay, yil);
            }
            catch (Exception)
            {
                throw new Exception("Veriler getiriliken hata oluştu");
            }
            return result;
        }
        
    }
}
