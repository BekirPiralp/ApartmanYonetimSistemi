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

namespace VeriErisimKatmani.Concrete.Mongo
{
    public class MdbEntityRepositoryBase<TEntity> : IMdbRepositoryBase<TEntity>
        where TEntity : Entity
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


        public void Ekle(TEntity entity)
        {
            if(entity != null && entity.SNo == 0)
            {
                entity.SNo = SiraNoAl(); 
                _mongoCollection.InsertOneAsync(entity);
            }
            else
            {
                throw new Exception("Veri boştur.");
            }

        }

        public TEntity Getir(Expression<Func<TEntity, bool>> Filtre)
        {
            TEntity result = null;
            if (_mongoCollection.CountDocuments("{}") > (long)0)
                result = _mongoCollection.Find(Filtre).FirstOrDefaultAsync().Result;
            else
                throw new Exception("Sistemde kayıtlı veri bulunamadı...");
            return result;
        }

        public void Guncelle(TEntity entity)
        {
            if (entity != null && entity.SNo > 0)
            {
                _mongoCollection.FindOneAndUpdateAsync(p => p.SNo == entity.SNo, entity.ToJson()); //aramaya uygun olan ilk üye için
                //_mongoCollection.UpdateOneAsync<TEntity>(p => p.SNo == entity.SNo, entity.ToJson()); //tekil olalanlar için
            }
            else
                throw new Exception("Güncellenmek istenen veri gelmedi");
        }

        public List<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> Filtre = null)
        {
            if (Filtre == null)
                Filtre = p => p.SNo > 0;
            List<TEntity> result= null;
            if (_mongoCollection.Find(Filtre).CountDocuments() > 0)
                result = _mongoCollection.Find(Filtre).ToList<TEntity>();
            else
                throw new Exception("Veriler getiriliken hata oluştu. Boş veri");
            return result;
        }

        public void Sil(TEntity entity)
        {
            if (entity != null && entity.SNo > 0)
            //_mongoCollection.DeleteOne<TEntity>(p => p.SNo == entity.SNo);
            {
                entity.SilDurum = true;
                Guncelle(entity);
            }
            else
                throw new Exception("Silmek için göderilen veride hata oluştu");
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
