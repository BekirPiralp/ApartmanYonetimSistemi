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
    public class IsKatmaniDaireSakiniServisi : IsKatmaniTemelServisi<DaireSakini,IDaireSakiniVek>, IIsKatmaniDaireSakiniServisi
    {
        internal IsKatmaniDaireSakiniServisi(IDaireSakiniVek daireSakiniVek):base(daireSakiniVek)
        {

        }

        public DaireSakini Getir(string TC)
        {
            DaireSakini result = null;
            try
            {
                if (!TC.Trim().Equals("") && TC.Trim().Length == 11)
                    result = this._entityVek.Getir(p => p.TC.Equals(TC.Trim()));
                else
                    throw new ArgumentNullException();
            }
            catch (Exception )
            {
                throw new Exception("Hata ile karşılaşıldı.");
            }
            return result;
        }

        public List<DaireSakini> GetirHepsi(int apartman)
        {
            List<DaireSakini> result = null;

            try
            {
                if (apartman > 0)
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman);
                else
                    throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception("Getirme işlemi sırasında hata ile karşılaşıldı.");
            }
            return result;
        }

        public List<DaireSakini> GetirSilinen(int apartman)
        {
            List<DaireSakini> result = null;

            try
            {
                if (apartman > 0)
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmis);
                else
                    throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception("Getirme işlemi sırasında hata ile karşılaşıldı.");
            }
            return result;
        }

        public List<DaireSakini> GetirSilinmeyen(int apartman)
        {
            List<DaireSakini> result = null;

            try
            {
                if (apartman > 0)
                    result = _entityVek.HepsiniGetir(p => p.Apartman == apartman && p.SilDurum == SilDurum.Silinmemis);
                else
                    throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception("Getirme işlemi sırasında hata ile karşılaşıldı.");
            }
            return result;
        }
    }
}
