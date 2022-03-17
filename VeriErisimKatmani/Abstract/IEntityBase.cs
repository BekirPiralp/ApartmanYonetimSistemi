using EntityLayer.Somut;
using EntityLayer.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.Abstract
{
    public interface IEntityBase<TEntity>
        where TEntity : Entity,IEntity ,new()
    {
        //Belirlernene en temel işlemler
        TEntity Getir(Expression<Func<TEntity, bool>> Filtre);
        List<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> Filtre = null);

        void Ekle(TEntity entity);

        void Guncelle(TEntity entity);

        void Sil(TEntity entity);

        int SiraNoAl();
    }
}
