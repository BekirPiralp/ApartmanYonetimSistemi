using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebUygulamaKatmani.Controllers
{
    [RoutePrefix("borc")]
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
        //return List<Borc>
        public IHttpActionResult OdenmemisBorclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            try
            {
                if (Apartman > 0 && DaireSakini > 0)
                    result = _borcOCAK.GecmisOdenmemisBorcuGetir(Apartman, DaireSakini);
                else
                    throw new ArgumentNullException("Lütfen parametreleri eksiksiz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("hepsi")]
        // return List<Borc>
        public IHttpActionResult Borclar(int Apartman, int DaireSakini)
        {
            List<Borc> result = null;
            try
            {
                if (Apartman > 0 && DaireSakini > 0)
                    result = _borcOCAK.GecmisBorcuGetir(Apartman, DaireSakini);
                else
                    throw new ArgumentNullException("Gerekli veriler eksik girilmiştir");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("borclular")]
        // return List<DaireSakini>
        public IHttpActionResult Borclular(int Apartman)
        {
            List<DaireSakini> result = null;
            try
            {
                if (Apartman > 0)
                    result = _borcOCAK.ToplamBorcluGetir(Apartman);
                else
                    throw new ArgumentNullException("gerekli parametreyi eksiksisz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("toplam")]
        // return decimal
        public IHttpActionResult ToplamBorc(int Apartman, int DaireSakini)
        {
            decimal result = 0;
            try
            {
                if (Apartman > 0 && DaireSakini > 0)
                    result = _borcOCAK.Borclumu(apartman: Apartman, daireSakini: DaireSakini);
                else
                    throw new ArgumentNullException("Parametreleri eksiksiz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpPost()]
        [Route("ode")]
        public IHttpActionResult BorcOde(decimal OdemeTutari, int Apartman, int DaireSakini)
        {
            try
            {
                if (OdemeTutari > 0 && Apartman > 0 && DaireSakini > 0)
                    _borcOCAK.BorcOde(OdemeTutari, Apartman, DaireSakini);
                else
                    throw new ArgumentNullException("lütfen verileri eksiksiz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}