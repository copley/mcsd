using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            TypedExceptions();
        }

        private static void TypedExceptions()
        {
            try
            {
                // Do something
            }
            catch (DivideByZeroException)
            {
                // specific exception
            }
            catch (Exception)
            {
                // generic exception
            }
            finally
            {
                // this will always occur
            }
        }
    }
}
