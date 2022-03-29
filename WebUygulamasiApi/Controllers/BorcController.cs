using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System.Collections.Generic;
using System.Web.Http;

namespace WebUygulamasiApi.Controllers
{
    [Route("BorcServisi")]
    public class BorcController : ApiController
    {
        IBorcOCAK _borcOCAK;
        public BorcController()
        {
            _borcOCAK = OCAKOlusturucu.Olustur().BorcOCAK;
        }
        //[HttpGet({apartman}{dairesakini})]
        [HttpGet()]
        [Route("odenmemis")]
        public List<Borc> OdenmemisBorclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            if (Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.GecmisOdenmemisBorcuGetir(Apartman, DaireSakini);
            return result;
        }

        [HttpGet()]
        [Route("hepsi")]
        public List<Borc> Borclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            if (Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.GecmisBorcuGetir(Apartman, DaireSakini);
            return result;
        }

        [HttpGet()]
        [Route("borclular")]
        public List<DaireSakini> Borclular(int Apartman)
        {
            List<DaireSakini> result = null;
            if (Apartman > 0)
                result = _borcOCAK.ToplamBorcluGetir(Apartman);
            return result;
        }

        [HttpGet()]
        [Route("toplam")]
        public decimal ToplamBorc(int Apartman, int DaireSakini)
        {
            decimal result = 0;
            if (Apartman > 0 && DaireSakini > 0)
                result = _borcOCAK.Borclumu(apartman: Apartman, daireSakini: DaireSakini);
            else
                result = -1;
            return result;
        }

        [HttpPost()]
        [Route("ode")]
        public void BorcOde(decimal OdemeTutari, int Apartman, int DaireSakini)
        {
            if (OdemeTutari > 0 && Apartman > 0 && DaireSakini > 0)
                _borcOCAK.BorcOde(OdemeTutari, Apartman, DaireSakini);

        }
    }
}