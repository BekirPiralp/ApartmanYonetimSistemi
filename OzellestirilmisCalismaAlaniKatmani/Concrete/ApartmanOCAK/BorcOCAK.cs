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
    public class BorcOCAK : IBorcOCAK
    {
        private IIsKatmaniBorcServisi _borcServisi;
        private IIsKatmaniDaireSakiniServisi _daireSakiniServisi;
        private List<DaireSakini> daireSakinleri=null;

        public BorcOCAK()
        {
            _borcServisi = IsKatmaniNesneOlusturucu.Olusturucu().BorcServisi;
            _daireSakiniServisi = IsKatmaniNesneOlusturucu.Olusturucu().DaireSakiniServisi;
        }
        //public void borclandir(int apartman)
        //{
        //    daireSakinleri=_daireSakiniServisi.GetirSilinmeyen(apartman);

        //}

        public decimal Borclumu(int apartman, int daireSakini)
        {
            decimal result = 0;
            if (apartman > 0 && daireSakini > 0)
            {
                DaireSakini dSakini = null;
                dSakini = _daireSakiniServisi.Getir(daireSakini);
                if (dSakini != null && dSakini.Apartman == apartman && dSakini.SilDurum == SilDurum.Silinmemis)
                {
                    List<Borc> borclar = null;
                    try
                    {
                        borclar = _borcServisi.GetirSilinmeyen(apartman, daireSakini);
                    }
                    catch (Exception)
                    {
                        throw new Exception("verileri getirme esnasında hata oluştu");
                    }

                    if(borclar != null && borclar.Count >0)
                        foreach (var borc in borclar)
                        {
                            result += borc.Kalan;
                        }
                }
                else
                    throw new Exception("Daire sakini bilgisinde hata oluştu veya sisteme ekli değil.");
            }
            else
                throw new ArgumentNullException();

            return result;
        }

        public List<Borc> GecmisBorcuGetir(int apartman, int daireSakini)
        {
            List<Borc> result = null;
            if (apartman > 0 && daireSakini > 0)
            {
                DaireSakini dSakini = null;
                dSakini = _daireSakiniServisi.Getir(daireSakini);
                if (dSakini != null && dSakini.Apartman == apartman && dSakini.SilDurum == SilDurum.Silinmemis)
                {
                    List<Borc> borclar = null;
                    try
                    {
                        borclar = _borcServisi.GetirSilinmeyen(apartman, daireSakini);
                    }
                    catch (Exception)
                    {
                        throw new Exception("verileri getirme esnasında hata oluştu");
                    }
                    result = borclar;
                }
                else
                    throw new Exception("Daire sakini bilgisinde hata oluştu veya sisteme ekli değil.");
            }
            else
                throw new ArgumentNullException();

            return result;
        }

        public List<Borc> GecmisOdenmemisBorcuGetir(int apartman, int daireSakini)
        {
            List<Borc> result = null;
            if (apartman > 0 && daireSakini > 0)
            {
                DaireSakini dSakini = null;
                dSakini = _daireSakiniServisi.Getir(daireSakini);
                if (dSakini != null && dSakini.Apartman == apartman && dSakini.SilDurum == SilDurum.Silinmemis)
                {
                    List<Borc> borclar = null;
                    try
                    {
                        borclar = _borcServisi.GetirSilinmeyen(apartman, daireSakini);
                    }
                    catch (Exception)
                    {
                        throw new Exception("verileri getirme esnasında hata oluştu");
                    }
                    if( borclar != null && borclar.Count > 0)
                    {
                        result = (from borc in borclar where borc.Kalan > 0 select borc).ToList<Borc>();
                    }

                }
                else
                    throw new Exception("Daire sakini bilgisinde hata oluştu veya sisteme ekli değil.");
            }
            else
                throw new ArgumentNullException();

            return result;
        }

        public List<DaireSakini> ToplamBorcluGetir(int apartman)
        {
            List<DaireSakini> result = null;

            if (apartman > 0)
            {
                List<Borc> borclar = null;

                try
                {
                    borclar = _borcServisi.GetirHepsi(apartman);
                }
                catch (Exception)
                {
                    throw new Exception("Verileri getiriken hata oluştu");
                }

                if (borclar != null && borclar.Count > 0)
                {
                    List<int> dsakinleri = null;
                    dsakinleri = (from borc in borclar
                              where borc.Kalan > 0 && borc.SilDurum == SilDurum.Silinmemis
                              group borc by borc.DaireSakini into dSakinGrup
                              where dSakinGrup.Count() > 0
                              orderby dSakinGrup.Key
                              select dSakinGrup.Key).ToList();
                    if( dsakinleri != null && dsakinleri.Count > 0)
                    {
                        result = new List<DaireSakini>();

                        try
                        {
                            foreach (var dsakini in dsakinleri)
                            {
                                result.Add(_daireSakiniServisi.Getir(dsakini));
                            }
                            if (result.Count == 0)
                                result = null;
                        }
                        catch (Exception)
                        {
                            throw new Exception("Veriler getirilirken bir hata oluştu");
                        }
                    }
                    
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }
    }
}
