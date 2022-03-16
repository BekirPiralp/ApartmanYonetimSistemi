using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Oznitelik
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,AllowMultiple = true,Inherited = true)]
    public class EntityAttribute : Attribute
    {
        public string CollectionName { get; set; }
    }
}
