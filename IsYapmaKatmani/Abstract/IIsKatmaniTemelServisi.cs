using EntityLayer.Somut;
using EntityLayer.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsYapmaKatmani.Abstract
{
    public interface IIsKatmaniTemelServisi<TEntity>
        where TEntity:Entity,IEntity
    {
        /*------------------Hepsinde buluncak olaln temel işlemler ----------------------*/

        #region Getirme işlemleri
        //Silinenleri getir
        List<TEntity> GetirSilinen();
        //Silinmeyenleri Getir
        List<TEntity> GetirSilinmeyen();
        //Hepsini getir
        List<TEntity> GetirHepsi();

        //Sno ile getir
        /// <summary>
        /// SNO = Sıra numarası burada bilinen pozitif sayı olan id yerine kullanılmıştır.
        /// </summary>
        /// <param name="SNo"></param>
        TEntity Getir(int SNo);
        //Filtre ile getir
        /// <summary>
        /// ilk bulduğunu getirir
        /// </summary>
        /// <returns></returns>
        TEntity Getir(Expression<Func<TEntity, bool>> filtre);
        #endregion

        #region Silmeİşlemleri
        //Tekli silme
        void Sil(TEntity entity);
        /// <summary>
        /// SNO = Sıra numarası burada bilinen pozitif sayı olan id yerine kullanılmıştır.
        /// </summary>
        /// <param name="SNo"></param>
        void Sil(int sNo);
        //Çoklu Silme
        void Sil(List<TEntity> entities);
        // Şartlı silme
        void Sil(Expression<Func<TEntity, bool>> filtre);
        #endregion

        #region Güncelleme işlemleri
        void Guncelle(TEntity entity);
        #endregion

        #region Ekleme işlemleri
        int Ekle(TEntity entity); // int olarak id yani SNO döndürür. 0 ise nesne kayıt edilememiştir.
        void Ekle(List<TEntity> entities); 
        #endregion
    }
}
