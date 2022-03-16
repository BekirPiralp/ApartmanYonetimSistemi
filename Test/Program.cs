using EntityLayer.Oznitelik;
using EntityLayer.Somut;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            foreach(var aidat in aidats)
            {
                Console.WriteLine($"id : {aidat.SNo}\nApartman : {aidat.Apartman}\nTutar : {aidat.Tutar}\nAy : {aidat.Ay}" +
                    $"\nYıl : {aidat.Yil}");
                Console.WriteLine();
            }
            Console.WriteLine($"gelen veri sayısı: {aidats.Count}");
            #endregion

            #region En yüksek sıra no  yani özel Id nin tesi
            int enYuksek =(from entity in aidats orderby entity.SNo descending select entity).FirstOrDefault<Aidat>().SNo;

            Console.WriteLine($"En yüksek id = {enYuksek}");
            #endregion

            

            Console.ReadLine();
        }
    }
}
