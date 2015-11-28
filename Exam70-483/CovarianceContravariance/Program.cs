using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContravariance
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithout();
            TestWithCovariance();
            TestWithContravariance();
        }

        private static void TestWithout()
        {
            IBuffer1<string> b1 = new Buffer1<string>();
            IBuffer1<object> b2 = b1; // Error

            IBuffer1<object> b3 = new Buffer1<object>();
            IBuffer1<string> b4 = b3; // Error
        }

        private static void TestWithCovariance()
        {
            IBuffer2<string> b1 = new Buffer2<string>();
            IBuffer2<object> b2 = b1;
        }

        private static void TestWithContravariance()
        {
            IBuffer3<object> b1 = new Buffer3<object>();
            IBuffer3<string> b2 = b1;
        }
    }

    public interface IBuffer1<T> { } // Without
    public class Buffer1<T> : IBuffer1<T> { }

    public interface IBuffer2<out T> { } // Covariance
    public class Buffer2<T> : IBuffer2<T> { }

    public interface IBuffer3<in T> { } // Contravariance
    public class Buffer3<T> : IBuffer3<T> { }
}
