using EntityLayer.Oznitelik;
using EntityLayer.Somut;
using IsYapmaKatmani.Abstract;
using IsYapmaKatmani.NesneOlustur;
using MongoDB.Driver;
using OzellestirilmisCalismaAlaniKatmani.Concrete.ApartmanOCAK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Concrete.Mongo;

namespace Test
{
    class Program
    {
        

        static void Main(string[] args)
        {
            EntityAttribute oznitelikler;
            string _collectionName;

            string connectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB+Compass&directConnection=true&ssl=false"; // varsayılan hali
            string dataBaseName = "ApartmanYonet";
            MongoClient _mongoClient;
            IMongoDatabase _mongoDatabase;

            oznitelikler = (EntityAttribute)Attribute.GetCustomAttribute(typeof(Aidat),typeof(EntityAttribute));
            _collectionName = oznitelikler.CollectionName;

            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(dataBaseName);
            var Dokumanlar = _mongoDatabase.GetCollection<Aidat>(_collectionName);

            #region verlerin gelme testi
            List<Aidat> aidats = Dokumanlar.Find("{}").ToList<Aidat>();

            EkranaBas(aidats);
            
            Console.WriteLine($"gelen veri sayısı: {aidats.Count}");
            #endregion

            #region En yüksek sıra no  yani özel Id nin tesi
            int enYuksek = 0;
            if (aidats != null && aidats.Count > 0)
                enYuksek = (from entity in aidats orderby entity.SNo descending select entity).FirstOrDefault<Aidat>().SNo;
            else
                Console.WriteLine("nesne bulunamadı");
            Console.WriteLine($"En yüksek id = {enYuksek}");
            #endregion

            #region Veri erişim katmanı testi
            MdbAidatVek AidatErisim = new MdbAidatVek();

            //// hepsini getirme testi
            //try
            //{
            //    Console.WriteLine("// hepsini getirme testi");
            //    EkranaBas(AidatErisim.HepsiniGetir());
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Hepsine getirme testinde hata oluştu.");
                
            //}


            //// Ekleme Testi 
            //Console.WriteLine("// Ekleme Testi ");
            //try
            //{
            //    AidatErisim.Ekle(new Aidat { Apartman = 2, Ay = 120, Yil = 2022, Tutar = (decimal)15.78 });
            //    EkranaBas(AidatErisim.HepsiniGetir());

            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Ekleme testinde hata oluştu");
            //}
            // Getirme Tesi
            Console.WriteLine("// Getirme Tesi");
            Aidat gelen = null;
            try
            {
                gelen = AidatErisim.Getir(p => p.Yil == 2022 && p.SilDurum != true);//&& p.Ay == 120);
                EkranaBas2(gelen);

            }
            catch (Exception)
            {
                Console.WriteLine("Getirme testinde hata oluştu");
            }
            //// Guncelle Testi
            //Console.WriteLine("// Guncelle Testi");
            //try
            //{
            //    if(gelen != null)
            //        gelen.Ay = 150;
            //    AidatErisim.Guncelle(gelen);
            //    gelen = AidatErisim.Getir(p => p.Yil == 2022 && p.Ay == 150);
            //    EkranaBas2(gelen);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Guncelleme testinde hata oluştu");
            //}

            // silme Testi
            Console.WriteLine("// silme Testi");
            try
            {
                Console.Write("Silinsinmi?:");
                Console.ReadLine();
                //AidatErisim.Sil(gelen);
                gelen = AidatErisim.Getir(p => p.Yil == 2022 && p.Ay == 120 );
                EkranaBas2(gelen);
                GirisOCAK girisOCAK = new GirisOCAK();
                var al =girisOCAK.DaireSakiniGetir("12345678910");
                Console.WriteLine(al.Ad + " " + al.Soyad);
                GiderlerOCAK giderlerOCAK = new GiderlerOCAK();
                giderlerOCAK.GiderGetir(1);
                giderlerOCAK.GiderGetir(apartman: 1, ay: 4, yil: 2022);
            }
            catch (Exception)
            {
                Console.WriteLine($"Silme testinde hata oluştu.");
            }

            EkranaBas(AidatErisim.HepsiniGetir());
            #endregion



            Console.ReadLine();

            void EkranaBas(List<Aidat> aidats1)
            {
                Console.WriteLine("----------------------------- Ekrana basılıyor Çoklu ------------------------");
                if(aidats1 != null && aidats1.Count > 0)
                foreach (var aidat in aidats1)
                {
                    Console.WriteLine($"id : {aidat.SNo}\nApartman : {aidat.Apartman}\nTutar : {aidat.Tutar}\nAy : {aidat.Ay}" +
                        $"\nYıl : {aidat.Yil}\nSilinme Durumu: {aidat.SilDurum}");
                    Console.WriteLine();
                }
                Console.WriteLine("----------------------------- Ekrana Basma Bitti Çoklu ----------------------");
            }

            void EkranaBas2(Aidat aidat)
            {
                Console.WriteLine("----------------------------- Ekrana basılıyor Tekli ------------------------");
                if(aidat != null )   
                Console.WriteLine($"id : {aidat.SNo}\nApartman : {aidat.Apartman}\nTutar : {aidat.Tutar}\nAy : {aidat.Ay}" +
                        $"\nYıl : {aidat.Yil}\nSilinme Durumu: {aidat.SilDurum}");
                    Console.WriteLine();               
                Console.WriteLine("----------------------------- Ekrana Basma Bitti Tekli----------------------");
            }

        }
    }
}
