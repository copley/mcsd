using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementInterfaces
{
    class EnumerableImpl : IEnumerable
    {
        private List<object> objects = new List<object>();

        public IEnumerator GetEnumerator()
        {
            return new EnumeratorImpl(objects.ToArray());
        }
    }

    class EnumeratorImpl : IEnumerator
    {
        private object[] objects;
        private int position = -1;

        public EnumeratorImpl(object[] objects)
        {
            this.objects = objects;
        }

        public object Current
        {
            get
            {
                try
                {
                    return objects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < objects.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
