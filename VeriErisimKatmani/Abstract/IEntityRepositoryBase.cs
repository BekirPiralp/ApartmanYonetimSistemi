using EntityLayer.Somut;
using EntityLayer.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.Abstract
{
    public interface IEntityRepositoryBase<TEntity>:IEntityBase<TEntity>
         where TEntity : Entity, IEntity,new()
    {
    }
}
