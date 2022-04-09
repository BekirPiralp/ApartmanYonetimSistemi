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
    public class TahakkukOCAK : ITahakkukOCAK
    {
        private IIsKatmaniAidatServisi _aidatServisi;
        private IIsKatmaniGiderServisi _giderServisi;
        private IIsKatmaniDaireSakiniServisi _daireSakiniServisi;
        private IIsKatmaniBorcServisi _borcServisi;

        public TahakkukOCAK()
        {
            _aidatServisi = IsKatmaniNesneOlusturucu.Olusturucu().AidatServisi;
            _giderServisi = IsKatmaniNesneOlusturucu.Olusturucu().GiderServisi;
            _daireSakiniServisi = IsKatmaniNesneOlusturucu.Olusturucu().DaireSakiniServisi;
            _borcServisi = IsKatmaniNesneOlusturucu.Olusturucu().BorcServisi;
        }

        public Aidat AidatGetir(int apartman)
        {
            Aidat result = null;
            if (apartman > 0)
            {
                try
                {
                    result = _aidatServisi.GetirSilinmeyenSonAidat(apartman);
                }
                catch (Exception)
                {
                    throw new Exception("Aidat bilgisi getiriliken hata oluştu.");
                }
                
            }
            else
                throw new ArgumentNullException("Geçerli bir apartman bilgisi veriniz");

            return result;
        }
  
        public void AidatTanimla(int apartman, decimal tutar)
        {
            if (apartman > 0 && tutar > 0)
            {
                try
                {
                    Aidat aidat = null;
                    aidat = _aidatServisi.Getir(p => p.Yil == DateTime.Now.Year && p.Ay == DateTime.Now.Month && p.Apartman == apartman);
                    if (aidat != null)
                    {
                        aidat.Tutar = tutar;
                        _aidatServisi.Guncelle(aidat);
                    }
                    else
                    {
                        aidat = new Aidat
                        {
                            Apartman = apartman,
                            Tutar = tutar,
                            Ay = DateTime.Now.Month,
                            Yil = DateTime.Now.Year
                        };
                        _aidatServisi.Ekle(aidat);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Aidat tanımlama sırasında hata ile karşılaşıldı.");
                }
            }
            else
                throw new ArgumentNullException("Paremetrelerde eksiklik var");
        }

        public void TahakkukOlustur(int apartman)
        {
            if (apartman > 0)
            {
                Aidat aidat = null;
                List<Gider> giderler = null;
                List<DaireSakini> daireSakinleri = null;
                List<Borc> borclar = null;

                try
                {
                    aidat = _aidatServisi.GetirSilinmeyenSonAidat(apartman);
                    giderler = _giderServisi.GetirSilinmeyen(apartman, DateTime.Now.Month, DateTime.Now.Year);
                    daireSakinleri = _daireSakiniServisi.GetirSilinmeyen(apartman);
                    borclar = _borcServisi.GetirSilinmeyen(apartman, DateTime.Now.Month, DateTime.Now.Year);
                }
                catch (Exception)
                {
                    throw new ArgumentNullException("Gerekli bilgiler getirilirken hata oluştu");
                }

                if (aidat != null && (borclar == null||borclar.Count ==0) && daireSakinleri != null && daireSakinleri.Count>0)
                {
                    decimal tutar = 0;
                    if(giderler != null && giderler.Count >0)
                    {
                        foreach (var gider in giderler)
                        {
                            tutar += gider.Tutar;
                        }
                    }
                    tutar = tutar / daireSakinleri.Count;

                    tutar += aidat.Tutar;

                    try
                    {
                        foreach (DaireSakini daireSakini in daireSakinleri)
                        {
                            _borcServisi.Ekle(new Borc
                            {
                                Apartman = apartman,
                                OdemeMiktari = 0,
                                DaireSakini = daireSakini.SNo,
                                BorcMiktari = tutar,
                                Kalan = tutar,
                                Ay = DateTime.Now.Month,
                                Yil = DateTime.Now.Year
                            });
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("İşleminiz gerçekleştirilemedi.");
                    }
                }
                else
                    throw new Exception("Apartmana ait aidatbilgi olmadığı için işleminizi gerçekleştiremiyoruz.");
            }
            else
                throw new ArgumentNullException("Lütfen geçerli bir arguman giriniz.");
        }
    }
}
