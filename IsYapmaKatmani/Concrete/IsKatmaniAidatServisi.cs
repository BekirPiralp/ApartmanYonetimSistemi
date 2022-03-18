using EntityLayer.Somut;
using IsYapmaKatmani.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Abstract;

namespace IsYapmaKatmani.Concrete
{
    public class IsKatmaniAidatServisi:IsKatmaniTemelServisi<Aidat,IAidatVek>,IIsKatmaniAidatServisi
    {
        public IsKatmaniAidatServisi(IAidatVek aidatVek):base(aidatVek)
        {

        }
    }
}
