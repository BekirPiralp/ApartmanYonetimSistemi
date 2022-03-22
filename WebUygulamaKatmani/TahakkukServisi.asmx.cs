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
    /// TahakkukServisi için özet açıklama
    /// </summary>
    [WebService(Namespace = "https://apartman.yon.sis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class TahakkukServisi : System.Web.Services.WebService
    {
        private ITahakkukOCAK _tahakkukOCAK;
        public TahakkukServisi()
        {
            _tahakkukOCAK = OCAKOlusturucu.Olustur().TahakkukOCAK;
        }

        [WebMethod]
        public void TahakkukOlustur(int apartman)
        {
            if (apartman > 0)
                _tahakkukOCAK.TahakkukOlustur(apartman);
        }

        [WebMethod]
        public void AidatTanimla(int apartman, Decimal tutar)
        {
            if (apartman > 0 && tutar > 0)
                _tahakkukOCAK.AidatTanimla(apartman, tutar);
        }

        [WebMethod]
        public Aidat AidatGetir(int apartman)
        {
            Aidat result = null;
            if (apartman > 0)
                result = _tahakkukOCAK.AidatGetir(apartman);
            return result;
        }
    }
}
