using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYapmaKatmani.Abstract
{
    public interface IIsKatmaniAidatServisi : IIsKatmaniTemelServisi<Aidat>
    {
        List<Aidat> GetirSilinmeyen(int Apartman);
        Aidat GetirSilinmeyenSonAidat(int Apartman); //List<Aidat> GetirSilinmeyen(int Apartman); methodunu da kendi içinde kullanır
    }
}
