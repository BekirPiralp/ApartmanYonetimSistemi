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
    [RoutePrefix("daire")]
    public class DaireController : ApiController
    {
        IDaireOCAK _daireOCAK;
        public DaireController()
        {
            _daireOCAK = OCAKOlusturucu.Olustur().DaireOCAK;
        }

        [HttpPost()]
        [Route("tanimla/nesne")]
        public IHttpActionResult DaireTanimla(int apartman, DaireSakini daireSakini, Daire daire)
        {
            try
            {
                if (apartman > 0 && daireSakini != null && daire != null)
                {
                    _daireOCAK.DaireTanimla(apartman, daireSakini, daire);
                }
                else
                    throw new ArgumentNullException("Eksik parametre");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpPost()]
        [Route("tanimla/sno")]
        public IHttpActionResult DaireTanimla(int apartman, DaireSakini daireSakini, int daireSNO)
        {
            try
            {
                if (apartman > 0 && daireSakini != null && daireSNO > 0)
                {
                    _daireOCAK.DaireTanimla(apartman, daireSakini, daireSNO);
                }
                else
                    throw new ArgumentNullException("Eksik parametre");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

    }
}
