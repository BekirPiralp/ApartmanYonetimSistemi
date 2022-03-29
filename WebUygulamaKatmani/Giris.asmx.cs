using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System.Web.Services;

namespace WebUygulamaKatmani
{
    /// <summary>
    /// Giris için özet açıklama
    /// </summary>
    [WebService(Namespace = "https://apartman.yon.sis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class Giris : System.Web.Services.WebService
    {
        IGirisOCAK _girisOCAK;
        public Giris()
        {
            _girisOCAK = OCAKOlusturucu.Olustur().GirisOCAK;
        }

        [WebMethod]
        public Yonetici YoneticiGetir(string TC)
        {
            Yonetici result = null;
            if (TC.Trim().Length > 0)
                result = _girisOCAK.YoneticiGetir(TC);
            return result;
        }

        [WebMethod]
        public DaireSakini DaireSakiniGetir(string TC)
        {
            DaireSakini result = null;
            if (TC.Trim().Length > 0)
                result = _girisOCAK.DaireSakiniGetir(TC);
            return result;
        }
    }
}
