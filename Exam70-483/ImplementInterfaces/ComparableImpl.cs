using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementInterfaces
{
    class ComparableImpl : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        // Also always override Equals and GetHashCode
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
