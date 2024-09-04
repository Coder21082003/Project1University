using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.DTO
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class DescAttribute : Attribute
    {
        public DescAttribute(string v) => Description = v;

        public string Description { set; get; }
    }
}
