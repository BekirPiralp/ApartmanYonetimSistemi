using EntityLayer.Somut;
using EntityLayer.Soyut;

namespace VeriErisimKatmani.Abstract.Mongo
{
    public interface IMdbRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity: Entity,IEntity,new ()
    {
        // Yeni geliştirmeler buraya eklenecek
    }
}
