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
    public class IsKatmaniBorcServisi : IsKatmaniTemelServisi<Borc, IBorcVek>, IIsKatmaniBorcServisi
    {
        internal IsKatmaniBorcServisi(IBorcVek borcVek) : base(borcVek)
        { }
        public new int Ekle(Borc borc)
        {
            int resultById = 0;
            try
            {
                borc.Kalan = borc.BorcMiktari;
                if (borc != null && borc.SNo == 0)
                    resultById = _entityVek.Ekle(borc);
                else
                    throw new Exception("Eklemek için gelen veri eksik");
            }
            catch (Exception)
            {
                throw new Exception("Ekleme işlemi sırasında hata oluştu");
            }
            return resultById;
        }

        public List<Borc> GetirHepsi(int apartman, int daireSakini)
        {
            List<Borc> result = null;
            if (apartman > 0 && daireSakini > 0)
            {
                try
                {
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.DaireSakini == daireSakini);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }

        public List<Borc> GetirHepsi(int apartman)
        {
            List<Borc> result = null;
            if (apartman > 0 )
            {
                try
                {
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }

        public List<Borc> GetirSilinen(int apartman, int daireSakini)
        {
            List<Borc> result = null;
            if (apartman > 0 && daireSakini > 0)
            {
                try
                {
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.DaireSakini == daireSakini && p.SilDurum == SilDurum.Silinmis);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }

        public List<Borc> GetirSilinmeyen(int apartman, int daireSakini)
        {
            List<Borc> result = null;
            if (apartman > 0 && daireSakini > 0)
            {
                try
                {
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.DaireSakini == daireSakini && p.SilDurum == SilDurum.Silinmemis);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }

        public List<Borc> GetirSilinmeyen(int apartman,int ay ,int yil)
        {
            List<Borc> result = null;
            if (apartman > 0 && ay > 0 && yil>0)
            {
                try
                {
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmemis
                    && p.Ay == ay && p.Yil == yil);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new ArgumentNullException();
            return result;
        }
    }

}
