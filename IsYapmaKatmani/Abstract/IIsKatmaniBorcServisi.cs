using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYapmaKatmani.Abstract
{
    public interface IIsKatmaniBorcServisi : IIsKatmaniTemelServisi<Borc>
    {
        List<Borc> GetirHepsi(int apartman,int daireSakini);
        List<Borc> GetirSilinmeyen(int apartman, int daireSakini);
        List<Borc> GetirSilinen(int apartman, int daireSakini);
        List<Borc> GetirHepsi(int apartman);
        List<Borc> GetirSilinmeyen(int apartman,int ay, int yil);
    }
}
