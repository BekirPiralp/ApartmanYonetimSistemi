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
    public class IsKatmaniGiderServisi : IsKatmaniTemelServisi<Gider,IGiderVek>, IIsKatmaniGiderServisi
    {
        internal IsKatmaniGiderServisi(IGiderVek giderVek):base(giderVek)
        {

        }

        public List<Gider> GetirHepsi(int apartman)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p=>p.Apartman == apartman);
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<Gider> GetirSilinen(int apartman)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmis);
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<Gider> GetirSilinmeyen(int apartman)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmemis);
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<Gider> GetirHepsi(int apartman, int ay, int yil)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0 && ay <=0 && yil <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.Apartman.Equals(apartman) && p.Ay.Equals(ay) && p.Yil.Equals(yil));
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<Gider> GetirSilinen(int apartman, int ay, int yil)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0 && ay <= 0 && yil <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmis && p.Ay == ay && p.Yil == yil);
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<Gider> GetirSilinmeyen(int apartman, int ay, int yil)
        {
            List<Gider> donusDegeri = null;
            if (apartman <= 0 && ay <= 0 && yil <= 0)
                throw new ArgumentNullException("Lütfen gerekli bilgileri eksiksiz giriniz");
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmemis && p.Ay == ay && p.Yil == yil);
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }
    }
}
