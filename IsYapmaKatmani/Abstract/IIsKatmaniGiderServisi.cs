using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYapmaKatmani.Abstract
{
    public interface IIsKatmaniGiderServisi : IIsKatmaniTemelServisi<Gider>
    {
        List<Gider> GetirHepsi(int apartman);
        List<Gider> GetirSilinen(int apartman);
        List<Gider> GetirSilinmeyen(int apartman);

        List<Gider> GetirHepsi(int apartman, int ay, int yil);
        List<Gider> GetirSilinen(int apartman, int ay, int yil);
        List<Gider> GetirSilinmeyen(int apartman, int ay, int yil);
    }
}
