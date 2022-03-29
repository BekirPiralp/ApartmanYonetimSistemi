using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System;
using System.Web.Http;
//using System.Web.Mvc;

namespace WebUygulamaKatmani.Controllers
{
    //[Route("TahakkukServisi")]
    [System.Web.Http.RoutePrefix("tahakkuk")]
    public class TahakkukController : ApiController
    {
        ITahakkukOCAK tahakkukOCAK;
        public TahakkukController()
        {
            tahakkukOCAK = OCAKOlusturucu.Olustur().TahakkukOCAK;
        }

        [HttpGet()]
        [Route("gerceklestir")]
        public IHttpActionResult Gerceklestir(int Apartman)
        {
            try
            {
                tahakkukOCAK.TahakkukOlustur(Apartman);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpGet()]
        [Route("aidat/tanimla")]
        public IHttpActionResult AidatTanimla(int apartman, decimal tutar)
        {
            try
            {
                tahakkukOCAK.AidatTanimla(apartman, tutar);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }


        //[Route("aidat/getir")]
        [HttpGet()]
        [Route("aidat/getir")]
        public IHttpActionResult AidatGet(int apartman)
        {
            Aidat result = null;
            try
            {
                result = tahakkukOCAK.AidatGetir(apartman);
                if (result == null || result.SNo <= 0)
                    throw new Exception("Geçerli nesne bulunamadı");
            }
            catch (System.Exception e)
            {
                //return NotFound();
                return InternalServerError(e);
            }
            return Ok(result);
        }

        //[HttpGet()]
        //[Route("aidat/deneme")]
        //public string AidatGet(Aidat aidat,string mesaj)
        //{
        //    return $"mesaj = {mesaj}" +
        //        $"{aidat.Apartman}\n{aidat._id}\n{aidat.SNo}\n{aidat.Tutar}\n{aidat.Yil}\n{aidat.SilDurum}";
        //}

        /***
         * veri göderme örneği
         * https://localhost:44377/tahakkuk/aidat/deneme?Apartman=1&Tutar=120.55&Ay=3&Yil=2022&id=623d5bcc2b5d738905c10e58&SNo=1&SilDurum=false&mesaj=denemeverisi
         */

    }
}