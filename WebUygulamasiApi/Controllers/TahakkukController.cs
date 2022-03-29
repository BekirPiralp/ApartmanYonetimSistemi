using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System.Web.Http;

namespace WebUygulamasiApi.Controllers
{
    //[Route("TahakkukServisi")]
    public class TahakkukController : ApiController
    {
        ITahakkukOCAK tahakkukOCAK;
        public TahakkukController()
        {
            tahakkukOCAK = OCAKOlusturucu.Olustur().TahakkukOCAK;
        }

        [HttpGet]
        [Route("gerceklestir")]
        public void Gerceklestir(int Apartman)
        {
            tahakkukOCAK.TahakkukOlustur(Apartman);
        }

        [HttpGet]
        [Route("aidat/tanimla")]
        public void AidatTanimla(int apartman, decimal tutar)
        {
            tahakkukOCAK.AidatTanimla(apartman, tutar);
        }

        [HttpGet]
        //[Route("aidat/get/{apartman}")]
        public Aidat AidatGet(int apartman)
        {
            return tahakkukOCAK.AidatGetir(apartman);
        }
    }
}