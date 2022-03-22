using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebUygulamaKatmani
{
    /// <summary>
    /// BorcServisi için özet açıklama
    /// </summary>
    [WebService(Namespace = "https://apartman.yon.sis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class BorcServisi : System.Web.Services.WebService
    {
        IBorcOCAK _borcOCAK;
        
        public BorcServisi()
        {
            _borcOCAK = OCAKOlusturucu.Olustur().BorcOCAK;
        }

        [WebMethod]
        public List<Borc> OdenmemisBorclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            if(Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.GecmisOdenmemisBorcuGetir(Apartman, DaireSakini);
            return result;
        }

        [WebMethod]
        public List<Borc> Borclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            if (Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.GecmisBorcuGetir(Apartman, DaireSakini);
            return result;
        }

        [WebMethod]
        public List<DaireSakini> Borclular(int Apartman)
        {
            List<DaireSakini> result = null;
            if (Apartman > 0)
                result = _borcOCAK.ToplamBorcluGetir(Apartman);
            return result;
        }

        [WebMethod]
        public decimal ToplamBorc(int Apartman,int DaireSakini)
        {
            decimal result = 0;
            if (Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.Borclumu(apartman: Apartman, daireSakini: DaireSakini);
            else
                result = -1;
            return result;
        }

        [WebMethod]
        public void BorcOde(decimal OdemeTutari, int Apartman, int DaireSakini)
        {
            if (OdemeTutari > 0 && Apartman > 0 && DaireSakini > 0)
                _borcOCAK.BorcOde(OdemeTutari, Apartman, DaireSakini);

        }

        
    }
}
