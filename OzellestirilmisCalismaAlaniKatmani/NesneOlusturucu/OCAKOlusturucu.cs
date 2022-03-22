using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.Concrete.ApartmanOCAK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu
{
    public class OCAKOlusturucu
    {
        public IBorcOCAK BorcOCAK { get; }
        public IDaireOCAK DaireOCAK { get; }
        public IGiderlerOCAK GiderlerOCAK { get; }
        public IGirisOCAK GirisOCAK { get; }
        public ITahakkukOCAK TahakkukOCAK { get; }
        
        private OCAKOlusturucu()
        {
            BorcOCAK = new BorcOCAK();
            DaireOCAK = new DaireOCAK();
            GiderlerOCAK = new GiderlerOCAK();
            GirisOCAK = new GirisOCAK();
            TahakkukOCAK = new TahakkukOCAK();
        }
        private static OCAKOlusturucu olusturucu = null;
        private static Object kilitlemeObj = new Object();
        public static OCAKOlusturucu Olustur()
        {
            if(olusturucu == null)
            {
                lock (kilitlemeObj)
                {
                    if (olusturucu == null)
                        olusturucu = new OCAKOlusturucu();
                }
            }

            return olusturucu;
        }
    }
}
