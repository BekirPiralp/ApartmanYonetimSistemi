using IsYapmaKatmani.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Concrete.Mongo;

namespace IsYapmaKatmani.NesneOlustur
{
    public class IsKatmaniNesneOlusturucu 
    {
        /*--- iş katmanı ile ilgili nesneleri oluşturmak ve ayarlamak için olan bölüm ---*/

        public IsKatmaniAidatServisi aidatServisi { get; }
        public IsKatmaniApartmanServisi apartmanServisi { get; }
        public IsKatmaniBorcServisi borcServisi { get; }
        public IsKatmaniDaireSakiniServisi daireSakiniServisi { get; }
        public IsKatmaniDaireServisi daireServisi { get; }
        public IsKatmaniGiderServisi giderServisi { get; }
        public IsKatmaniGiderTipServisi giderTipServisi { get; }
        public IsKatmaniYoneticiServisi yoneticiServisi { get; }

        private IsKatmaniNesneOlusturucu()
        {
            aidatServisi = new IsKatmaniAidatServisi(new MdbAidatVek());
            apartmanServisi = new IsKatmaniApartmanServisi(new MdbApartmanVek());
            borcServisi = new IsKatmaniBorcServisi(new MdbBorcVek());
            daireSakiniServisi = new IsKatmaniDaireSakiniServisi(new MdbDaireSakiniVek());
            daireServisi = new IsKatmaniDaireServisi(new MdbDaireVek());
            giderServisi = new IsKatmaniGiderServisi(new MdbGiderVek());
            giderTipServisi = new IsKatmaniGiderTipServisi(new MdbGiderTipVek());
            yoneticiServisi = new IsKatmaniYoneticiServisi(new MdbYoneticiVek());
        }

        private static IsKatmaniNesneOlusturucu nesneOlusturucu = null;
        private static Object kilitObje = new Object();
        public static IsKatmaniNesneOlusturucu Olusturucu()
        {
            if(nesneOlusturucu == null)
            {
                lock (kilitObje)
                {
                    if(nesneOlusturucu == null)
                        nesneOlusturucu = new IsKatmaniNesneOlusturucu();
                }
            }
            
            return nesneOlusturucu;
        }
        
        


    }
}
