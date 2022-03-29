using EntityLayer.Somut;
using OzellestirilmisCalismaAlaniKatmani.Abstract.ApartmanOCAK;
using OzellestirilmisCalismaAlaniKatmani.NesneOlusturucu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUygulamasiApi.Controllers
{
    public class DenemeController : ApiController
    {
        ITahakkukOCAK tahakkukOCAK;
        

        //[HttpGet]
        //[Route("gerceklestir")]
        //public void Gerceklestir(int Apartman)
        //{
        //    tahakkukOCAK.TahakkukOlustur(Apartman);
        //}

        //[HttpGet]
        //[Route("aidat/tanimla")]
        //public void AidatTanimla(int apartman, decimal tutar)
        //{
        //    tahakkukOCAK.AidatTanimla(apartman, tutar);
        //}

        [HttpGet()]
        //[Route("aidat/get/{apartman}")]
        public Aidat AidatGet(int apartman)
        {
            tahakkukOCAK = OCAKOlusturucu.Olustur().TahakkukOCAK;
            return tahakkukOCAK.AidatGetir(apartman);
        }
    }
}