using EntityLayer.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYapmaKatmani.Abstract
{
    public interface IIsKatmaniDaireSakiniServisi : IIsKatmaniTemelServisi<DaireSakini>
    {
        List<DaireSakini> GetirSilinmeyen(int apartman);
        List<DaireSakini> GetirSilinen(int apartman);
        List<DaireSakini> GetirHepsi(int apartman);

        DaireSakini Getir(string TC);
    }
}
