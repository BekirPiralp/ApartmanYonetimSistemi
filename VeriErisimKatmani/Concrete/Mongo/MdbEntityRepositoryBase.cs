using EntityLayer.Oznitelik;
using EntityLayer.Somut;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Abstract.Mongo;
using VeriErisimKatmani.Abstract;
using EntityLayer.EntityDurum;

namespace VeriErisimKatmani.Concrete.Mongo
{
    public class MdbEntityRepositoryBase<TEntity> : IMdbRepositoryBase<TEntity>
        where TEntity : Entity, new ()
    {
        private EntityAttribute oznitelikler;
        protected string _collectionName;

        private string connectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB+Compass&directConnection=true&ssl=false"; // varsayılan hali
        private string dataBaseName = "ApartmanYonet";
        private MongoClient _mongoClient;
        protected IMongoDatabase _mongoDatabase;
        IMongoCollection<TEntity> _mongoCollection = null;


        public MdbEntityRepositoryBase()
        {
            oznitelikler = (EntityAttribute)Attribute.GetCustomAttribute(typeof(TEntity),typeof(EntityAttribute));
            _collectionName = oznitelikler.CollectionName;

            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(dataBaseName);
            _mongoCollection = _mongoDatabase.GetCollection<TEntity>(_collectionName);
        }

        /// <summary>
        /// int olarak id yani SNO döndürür. 0 ise nesne kayıt edilememiştir.
        /// </summary>
        /// <returns></returns>
        public int Ekle(TEntity entity)
        {
            int resulbyID = 0;
            try
            {
                if (entity != null && entity.SNo == 0)
                {
                    entity.SNo = SiraNoAl();
                    entity.SilDurum = SilDurum.Silinmemis;
                    resulbyID = entity.SNo;
                    _mongoCollection.InsertOneAsync(entity);
                }
                else
                {
                    throw new Exception("Veri boştur.");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Ekleme işlemi sırasında hata oluştu."+$"\nDetay: \t{e.Message}");
            }
            return resulbyID;
        }

        public TEntity Getir(Expression<Func<TEntity, bool>> Filtre)
        {
            TEntity result = null;
            try
            {
                if (_mongoCollection.CountDocuments("{}") > (long)0)
                    result = _mongoCollection.Find(Filtre).FirstOrDefaultAsync().Result;
                else
                    result = null;
                    //throw new Exception("Sistemde kayıtlı veri bulunamadı...");
            }
            catch (Exception e)
            {
                throw new Exception("Getirme işleminde hata oluştu." + $"\nDetay: \t{e.Message}");
            }
            
            return result;
        }

        public void Guncelle(TEntity entity)
        {
            try
            {
                if (entity != null && entity.SNo > 0)
                {
                    TEntity entity1 = null;
                    entity1 = _mongoCollection.Find(p => p.SNo == entity.SNo).FirstOrDefaultAsync().Result; //object id için önlem
                    if (entity1 != null & entity.SNo == entity1.SNo)
                        entity._id = entity1._id;
                    _mongoCollection.FindOneAndUpdateAsync(p => p.SNo == entity.SNo, entity.ToJson()); //aramaya uygun olan ilk üye için
                                                                                                       //_mongoCollection.UpdateOneAsync<TEntity>(p => p.SNo == entity.SNo, entity.ToJson()); //tekil olalanlar için
                }
                else
                    throw new Exception("Güncellenmek istenen veri gelmedi");
            }
            catch (Exception e)
            {

                throw new Exception("Güncellenmeişleminde hata oluştu.\n"+$"Detay : \t{e.Message}");
            }
        }

        public List<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> Filtre = null)
        {
            if (Filtre == null)
                Filtre = p => p.SNo > 0;
            List<TEntity> result= null;
            try
            {
                if (_mongoCollection.Find(Filtre).CountDocuments() > 0)
                    result = _mongoCollection.Find(Filtre).ToListAsync<TEntity>().Result;
                else
                    result = null;
                    //throw new Exception("Boş veri");
            }
            catch (Exception e)
            {
                throw new Exception("Veriler getiriliken hata oluştu.\n" + $"Detay : \t{e.Message}");
            }
            return result;
        }

        public void Sil(TEntity entity)
        {
            try
            {
                if (entity != null && entity.SNo > 0)
                {
                    //_mongoCollection.FindOneAndDeleteAsync<TEntity>(p => p.SNo == entity.SNo);
                    entity.SilDurum = SilDurum.Silinmis;
                    Guncelle(entity);
                }
                else
                    throw new Exception("Boş veri");
            }
            catch (Exception e)
            {

                throw new Exception("Silme işleminde hata oluştu." + $"\nDetay : \t{e.Message}"); ;
            }
        }

        public int SiraNoAl()
        {
            int result = 0;
            List<TEntity> entities = HepsiniGetir();
            if (entities != null && entities.Count > 0)
            {
                result = (from entity in entities orderby entity.SNo descending select entity).FirstOrDefault<TEntity>().SNo; 
            }
            result++;
            return result;
        }
        
    }
}
