using EntityLayer.Somut;

namespace VeriErisimKatmani.Abstract.Mongo
{
    public interface IMdbRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity: Entity
    {
        // Yeni geliştirmeler buraya eklenecek
    }
}
