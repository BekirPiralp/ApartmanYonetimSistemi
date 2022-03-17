using EntityLayer.EntityDurum;
using EntityLayer.Somut;
using IsYapmaKatmani.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.Abstract;

namespace IsYapmaKatmani.Concrete
{
    public class IsKatmaniTemelServisi<TEntity,TEntityVek> : IIsKatmaniTemelServisi<TEntity>
        where TEntity : Entity,new ()
        where TEntityVek : class,IEntityRepositoryBase<TEntity>
    {
        internal TEntityVek _entityVek;
        public IsKatmaniTemelServisi(TEntityVek entityVek)
        {
            _entityVek = entityVek;
        }

        #region Ekleme İşlemleri

        public void Ekle(TEntity entity)
        {
            try
            {
                if (entity != null && entity.SNo == 0)
                    _entityVek.Ekle(entity);
                else
                    throw new Exception("Eklemek için gelen veri eksik");
            }
            catch (Exception)
            {
                throw new Exception("Ekleme işlemi sırasında hata oluştu");
            }
        }

        public void Ekle(List<TEntity> entities)
        {
            try
            {
                if (entities != null && entities.Count > 0)
                {
                    List<Exception> exceptions = new List<Exception>();
                    foreach (var entity in entities)
                    {
                        try
                        {
                            if (entity.SNo == 0)
                                _entityVek.Ekle(entity);
                            else
                                throw new Exception("Eklemek için gelen veri eksik.");
                        }
                        catch (Exception e)
                        {
                            exceptions.Add(new Exception($"Ekleme işlemi sırasında hata oluştu. SNO: {entity.SNo}" +
                               $"\nDetay: \t\n{e.Message}"));
                        }
                    }
                    if (exceptions.Count > 0)
                        foreach (var exception in exceptions)
                        {
                            throw exception;
                        }
                }
                else
                    throw new Exception("Eklemek için gelen veri eksik");
            }
            catch (Exception)
            {
                throw new Exception("Ekleme işlemi sırasında hata oluştu");
            }
        } 

        #endregion

        #region Getirme İslemleri

        public TEntity Getir(int SNo)
        {
            TEntity result = null;
            try
            {
                if (SNo > 0)
                    result = _entityVek.Getir(p => p.SNo == SNo);
                else
                    result = null;
            }
            catch (Exception)
            {
                throw new Exception("Veri getirilmesi sırasında hata oluştu");
            }
            return result;
        }

        public TEntity Getir(Expression<Func<TEntity, bool>> filtre)
        {
            TEntity result = null;
            try
            {
                if (filtre != null)
                    result = _entityVek.Getir(filtre);
                else
                    result = null;
            }
            catch (Exception)
            {
                throw new Exception("Veri getirilmesi sırasında hata oluştu");
            }
            return result;
        }

        public List<TEntity> GetirHepsi()
        {
            List<TEntity> donusDegeri = null;
            try
            {
                donusDegeri = _entityVek.HepsiniGetir();
            }
            catch (Exception)
            {
                throw new Exception("Tüm değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<TEntity> GetirSilinen()
        {
            List<TEntity> donusDegeri = null;
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.SilDurum == SilDurum.Silinmis);
            }
            catch (Exception)
            {
                throw new Exception("Silinen değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        public List<TEntity> GetirSilinmeyen()
        {
            List<TEntity> donusDegeri = null;
            try
            {
                donusDegeri = _entityVek.HepsiniGetir(p => p.SilDurum == SilDurum.Silinmemis);
            }
            catch (Exception)
            {
                throw new Exception("Silinmemiş değerler getirilirken hata oluştu!");
            }
            return donusDegeri;
        }

        #endregion

        #region Güncelleme işlemleri
        
        public void Guncelle(TEntity entity)
        {
            try
            {
                if (entity != null && entity.SNo > 0)
                    _entityVek.Guncelle(entity);
                else
                    throw new Exception("Boş veri");
            }
            catch (Exception)
            {
                throw new Exception("Güncelleme sırasında hata oluştu.");
            }
        }

        #endregion

        #region Silme işlemleri

        public void Sil(TEntity entity)
        {
            try
            {
                if (entity != null && entity.SNo > 0)
                    _entityVek.Sil(entity);
                else
                    throw new Exception("silinmek için yollanan veri eksik");
            }
            catch (Exception)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu");
            }
        }

        public void Sil(int sNo)
        {
            try
            {
                if (sNo > 0)
                {
                    TEntity entity = null;
                    // yukarıdaki method içerisinde değişiklik olsa dahi burayı etkilemesin diye tekrar yazdım
                    entity = _entityVek.Getir(p => p.SNo == sNo);

                    if (entity != null)
                        _entityVek.Sil(entity);
                    else
                        throw new Exception("Silinmek için yollana veri eksik");
                }
                else
                    throw new Exception("silinmek için yollanan veri eksik");
            }
            catch (Exception)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu");
            }
        }

        public void Sil(List<TEntity> entities)
        {
            try
            {
                if (entities != null && entities.Count > 0)
                {
                    List<Exception> exceptions = new List<Exception>();
                    foreach (var entity in entities)
                    {
                        if (entity.SNo > 0)
                        {
                            try
                            {
                                _entityVek.Sil(entity);
                            }
                            catch (Exception e)
                            {
                                exceptions.Add(new Exception($"Silme işleminde hata! SNO:{entity.SNo}\n" +
                                    $"Detay:\n\t{e.Message}"));
                            }
                        }
                        else
                            exceptions.Add(new Exception("silmek için yollanan veri eksik"));
                    }
                    if (exceptions.Count > 0)
                        foreach (var exeption in exceptions)
                        {
                            throw exeption;
                        }
                }
                else
                    throw new Exception("silinmek için yollanan veriler eksik");
            }
            catch (Exception)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu");
            }
        }
        /// <summary>
        /// Not:Sadece Bir Veriyi siler
        /// </summary>
        public void Sil(Expression<Func<TEntity, bool>> filtre)
        {
            try
            {
                if (filtre != null)
                {
                    TEntity entity = null;
                    entity = _entityVek.Getir(filtre);
                    if (entity != null)
                        _entityVek.Sil(entity);
                    else
                        throw new Exception("istenen filtreye uygun bir veri bulunamadığı için silinemedi");
                }
                else
                    throw new Exception("Lütfen gerekli bir filtre giriniz");
            }
            catch (Exception)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu");
            }
        }

        #endregion
    }
}
