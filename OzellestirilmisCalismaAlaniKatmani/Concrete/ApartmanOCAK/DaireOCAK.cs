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
    public class DaireOCAK : IDaireOCAK
    {
        private IIsKatmaniDaireSakiniServisi _daireSakiniServisi;
        private IIsKatmaniDaireServisi _daireServisi;

        public DaireOCAK()
        {
            _daireSakiniServisi = IsKatmaniNesneOlusturucu.Olusturucu().DaireSakiniServisi;
            _daireServisi = IsKatmaniNesneOlusturucu.Olusturucu().DaireServisi;
        }

        public void DaireTanimla(int apartman, DaireSakini daireSakini, Daire daire)
        {
            if (apartman > 0 && daireSakini != null && daire != null && daireSakini.TC.Trim().Length == 11 && daire.Apartman == apartman)
            {
                DaireSakini kntrl = null;

                try
                {
                    kntrl = _daireSakiniServisi.Getir(daireSakini.TC.Trim());
                }
                catch
                {
                }

                if (kntrl == null)
                {
                    int dSakiniSNO = 0;
                    daireSakini.Apartman = apartman;
                    daireSakini.Daire = daire.SNo;
                    dSakiniSNO = _daireSakiniServisi.Ekle(daireSakini);
                    daireSakini = null;
                    if (dSakiniSNO > 0)
                        daireSakini = _daireSakiniServisi.Getir(dSakiniSNO);

                    EskiKontrol(apartman, daireSakini, daire);
                }
                else
                {
                    daireSakini = kntrl;
                    daireSakini.SilDurum = SilDurum.Silinmemis;
                    daireSakini.Apartman = apartman;
                    daireSakini.Daire = daire.SNo;

                    _daireSakiniServisi.Guncelle(daireSakini);

                    EskiKontrol(apartman, daireSakini, daire);
                }

            }
            else
                throw new ArgumentNullException();

            void EskiKontrol(int aprtmn, DaireSakini ds, Daire d)
            {
                List<DaireSakini> daireSakinleri = null;
                daireSakinleri = _daireSakiniServisi.GetirSilinmeyen(aprtmn);
                if (daireSakinleri != null && daireSakinleri.Count > 0)
                {
                    DaireSakini dsakini = null;
                    dsakini = (from dskni in daireSakinleri
                               where dskni.Daire == d.SNo && dskni.Apartman == aprtmn && dskni.SNo != ds.SNo
                               select dskni).FirstOrDefault();
                    if (dsakini != null)
                    {
                        dsakini.SilDurum = SilDurum.Silinmis;
                        _daireSakiniServisi.Guncelle(dsakini);
                    }

                }
            }
        }

        public void DaireTanimla(int apartman, DaireSakini daireSakini, int daireSNO)
        {
            if (apartman > 0 && daireSNO > 0)
            {
                Daire daire = _daireServisi.Getir(daireSNO);
                if (daire != null)
                {
                    DaireTanimla(apartman, daireSakini, daire);
                }
                else
                    throw new Exception("Eksik veya yanlış bilgi");
            }
            else
                throw new ArgumentNullException();
        }

        public List<DaireSakini> DaireSakinleriniGetir(int apartman)
        {
            List<DaireSakini> result=null;
            try
            {
                result = _daireSakiniServisi.GetirSilinmeyen(apartman);
            }
            catch(Exception hata)
            {
                throw new Exception("Daire sakinleri getirilirken hata oluştu.");
            }
            return result;
        }
    }
}
