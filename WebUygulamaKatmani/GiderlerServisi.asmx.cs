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
    /// GiderlerServisi için özet açıklama
    /// </summary>
    [WebService(Namespace = "https://apartman.yon.sis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class GiderlerServisi : System.Web.Services.WebService
    {
        IGiderlerOCAK _giderlerOCAK;
        public GiderlerServisi()
        {
            _giderlerOCAK = OCAKOlusturucu.Olustur().GiderlerOCAK;
        }
        [WebMethod]
        public void GiderOlustur(int apartman, decimal tutar, int tip)
        {
            if(apartman >0 && tutar > 0 && tip > 0)
            {
                _giderlerOCAK.GiderOlustur(apartman, tutar, tip);
            }
        }

        [WebMethod]
        public void GiderOlusturOzel(int apartman, decimal tutar, String aciklama)
        {
            if (apartman > 0 && tutar > 0 && aciklama.Trim().Length > 0)
            {
                _giderlerOCAK.GiderOlustur(apartman, tutar, aciklama);
            }
        }

        [WebMethod]
        public List<Gider> GiderGetir(int apartman)
        {
            List<Gider> result = null;
            if (apartman > 0)
                result = _giderlerOCAK.GiderGetir(apartman);
            if (result != null && result.Count == 0)
                result = null;
            return result;
        }

        [WebMethod]
        public List<Gider> DonemGiderGetir(int apartman, int ay, int yil)
        {
            List<Gider> result = null;
            if (apartman > 0 && ay > 0 && yil > 0)
                result = _giderlerOCAK.GiderGetir(apartman,ay,yil);
            if (result != null && result.Count == 0)
                result = null;
            return result;
        }
    }
}
