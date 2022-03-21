using IsYapmaKatmani.Abstract;
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
        
        public IIsKatmaniAidatServisi AidatServisi { get; }
        public IIsKatmaniApartmanServisi ApartmanServisi { get; }
        public IIsKatmaniBorcServisi BorcServisi { get; }
        public IIsKatmaniDaireSakiniServisi DaireSakiniServisi { get; }
        public IIsKatmaniDaireServisi DaireServisi { get; }
        public IIsKatmaniGiderServisi GiderServisi { get; }
        public IIsKatmaniGiderTipServisi GiderTipServisi { get; }
        public IIsKatmaniYoneticiServisi YoneticiServisi { get; }

        private IsKatmaniNesneOlusturucu()
        {
            AidatServisi = new IsKatmaniAidatServisi(new MdbAidatVek());
            ApartmanServisi = new IsKatmaniApartmanServisi(new MdbApartmanVek());
            BorcServisi = new IsKatmaniBorcServisi(new MdbBorcVek());
            DaireSakiniServisi = new IsKatmaniDaireSakiniServisi(new MdbDaireSakiniVek());
            DaireServisi = new IsKatmaniDaireServisi(new MdbDaireVek());
            GiderServisi = new IsKatmaniGiderServisi(new MdbGiderVek());
            GiderTipServisi = new IsKatmaniGiderTipServisi(new MdbGiderTipVek());
            YoneticiServisi = new IsKatmaniYoneticiServisi(new MdbYoneticiVek());
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
