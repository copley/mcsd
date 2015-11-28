using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                Normally you want to release those unmanaged resources 
                before you lose all the references you have to the object 
                managing them. You do this by calling Dispose on that 
                object, or (in C#) using the using statement which will 
                handle calling Dispose for you.

                If you neglect to Dispose of your unmanaged resources correctly, 
                the garbage collector will eventually handle it for you when 
                the object containing that resource is garbage collected 
                (this is "finalization"). But because the garbage collector 
                doesn't know about the unmanaged resources, it can't tell how 
                badly it needs to release them - so it's possible for your program 
                to perform poorly or run out of resources entirely.
            */

            using (var disposable = new DisposableExample())
            {
                // Do something
                // After leaving this block, disposable.Dispose() is automatically called
            }
        }
    }
}
