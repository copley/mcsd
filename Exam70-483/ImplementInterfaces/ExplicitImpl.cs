using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementInterfaces
{
    public interface ISpeakable1
    {
        void Speak();
    }

    public interface ISpeakable2
    {
        void Speak();
    }

    // It's not possible to set the Speak method to public!
    class ExplicitImpl
        : ISpeakable1, ISpeakable2
    {
        void ISpeakable1.Speak()
        {
            throw new NotImplementedException();
        }
        
        void ISpeakable2.Speak()
        {
            throw new NotImplementedException();
        }
    }
}
