using EntityLayer.EntityDurum;
using EntityLayer.Somut;
using IsYapmaKatmani.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Abstract;

namespace IsYapmaKatmani.Concrete
{
    public class IsKatmaniAidatServisi:IsKatmaniTemelServisi<Aidat,IAidatVek>,IIsKatmaniAidatServisi
    {
        internal IsKatmaniAidatServisi(IAidatVek aidatVek):base(aidatVek)
        {

        }

        public List<Aidat> GetirSilinmeyen(int Apartman)
        {
            List<Aidat> aidatlar = null;
            if (Apartman > 0)
            {
                try
                {
                    aidatlar = _entityVek.HepsiniGetir(p => p.Apartman == Apartman && p.SilDurum == SilDurum.Silinmemis);
                }
                catch (Exception)
                {
                    throw new Exception("Veriler getiriliken hata oluştu");
                }
            }
            else
                throw new ArgumentNullException("Geçerli bir parametre yollayınız.");
            if (aidatlar != null && aidatlar.Count <= 0)
                aidatlar = null;

            return aidatlar;
        }

        public Aidat GetirSilinmeyenSonAidat(int Apartman)
        {
            Aidat result = null;
            if(Apartman > 0)
            {
                List<Aidat> aidatlar = null;
                try
                {
                    aidatlar = GetirSilinmeyen(Apartman);
                    if (aidatlar != null && aidatlar.Count > 0)
                    {
                        result = (from aidat1 in aidatlar
                                  orderby aidat1.Yil descending, aidat1.Ay descending
                                  select aidat1).FirstOrDefault();
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Veriler getirrilirken hata oluştu");
                }
            }
            else
                throw new ArgumentNullException("Geçerli bir parametre yollayınız.");
            return result;
        }
    }
}
