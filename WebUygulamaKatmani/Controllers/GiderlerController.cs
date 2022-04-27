using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUygulamaKatmani.Controllers
{
    [RoutePrefix("gider")]
    public class GiderlerController : ApiController
    {
        IGiderlerOCAK _giderlerOCAK;
        public GiderlerController()
        {
            _giderlerOCAK = OCAKOlusturucu.Olustur().GiderlerOCAK;
        }

        [HttpPost()]
        [Route("olustur")]
        public IHttpActionResult GiderOlustur(int apartman, decimal tutar, int tip)
        {
            try
            {
                if (apartman > 0 && tutar >= 0 && tip >= 0)
                {
                    _giderlerOCAK.GiderOlustur(apartman, tutar, tip);
                }
                else
                    throw new ArgumentNullException("parametreleri eksik siz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpPost()]
        [Route("olustur_ozel")]
        public IHttpActionResult GiderOlusturOzel(int apartman, decimal tutar, String aciklama)
        {
            try
            {
                if (apartman > 0 && tutar > 0 && aciklama.Trim().Length > 0)
                {
                    _giderlerOCAK.GiderOlustur(apartman, tutar, aciklama);
                }
                else
                    throw new ArgumentNullException("parametreleri eksik siz giriniz");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpGet()]
        [Route("getir")]
        // return List<Gider>
        public IHttpActionResult GiderGetir(int apartman)
        {
            List<Gider> result = null;
            try
            {
                if (apartman > 0)
                    result = _giderlerOCAK.GiderGetir(apartman);
                if (result != null && result.Count == 0)
                    result = null;
                if (result == null)
                    throw new Exception("nesne bulunumadı");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("donem_getir")]
        //return List<Gider>
        public IHttpActionResult DonemGiderGetir(int apartman, int ay, int yil)
        {
            List<Gider> result = null;
            try
            {
                if (apartman > 0 && ay > 0 && yil > 0)
                    result = _giderlerOCAK.GiderGetir(apartman, ay, yil);
                if (result != null && result.Count == 0)
                    result = null;
                if (result == null)
                    throw new Exception("nesne bulunamadı");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }
    }
}
