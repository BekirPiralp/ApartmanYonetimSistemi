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
    /// DaireServisi için özet açıklama
    /// </summary>
    [WebService(Namespace = "https://apartman.yon.sis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class DaireServisi : System.Web.Services.WebService
    {
        IDaireOCAK _daireOCAK;
        public DaireServisi()
        {
            _daireOCAK = OCAKOlusturucu.Olustur().DaireOCAK;
        }

        [WebMethod(MessageName ="Daire nesne olarak verilirse")]
        public void DaireTanimlaNesne(int Apartman, DaireSakini DaireSakini, Daire Daire)
        {
            if (Apartman > 0 && DaireSakini != null && Daire != null)
            {
                _daireOCAK.DaireTanimla(Apartman, DaireSakini, Daire);
            }
        }

        [WebMethod(MessageName = "Daire numarası verilirse")]
        public void DaireTanimlaSNo(int Apartman, DaireSakini DaireSakini, int DaireSNO)
        {
            if (Apartman > 0 && DaireSakini != null && DaireSNO > 0)
            {
                _daireOCAK.DaireTanimla(Apartman, DaireSakini, DaireSNO);
            }
        }
    }
}
