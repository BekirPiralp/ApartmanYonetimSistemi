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
    [RoutePrefix("giris")]
    public class GirisController : ApiController
    {
        IGirisOCAK _girisOCAK;
        public GirisController()
        {
            _girisOCAK = OCAKOlusturucu.Olustur().GirisOCAK;
        }

        [HttpGet()]
        [Route("getir/yonetici")]
        //return Yonetici
        public IHttpActionResult YoneticiGetir(string TC)
        {
            Yonetici result = null;
            try
            {
                if (TC.Trim().Length > 0)
                    result = _girisOCAK.YoneticiGetir(TC);
                if (result == null)
                    throw new Exception("istenilen kişi bulunamadı");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("getir/daire_sakini")]
        //return DaireSakini
        public IHttpActionResult DaireSakiniGetir(string TC)
        {
            DaireSakini result = null;
            try
            {
                if (TC.Trim().Length > 0)
                    result = _girisOCAK.DaireSakiniGetir(TC);
                if (result == null)
                    throw new Exception("Veri bulunamadı");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }
    }
}
