using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perf_Lang_Master.tests
{
    public class oo1
    {
        public static void RunTests()
        {
            if (!controller.math.Tests.RunTests())
            {
                Console.WriteLine("Posix: Math: BAD");
            }
            else
            {
                Console.WriteLine("Posix: Math: OKAY");
            }

            if (!controller.roman.Tests.RunTests())
            {
                Console.WriteLine("Posix: Roman: BAD");
            }
            else
            {
                Console.WriteLine("Posix: Roman: OKAY");
            }

            if (!controller.markup.Tests.RunTests())
            {
                Console.WriteLine("Posix: Markup: BAD");
            }
            else
            {
                Console.WriteLine("Posix: Markup: OKAY");
            }

            if (!controller.linq.Tests.RunTests())
            {
                Console.WriteLine("Posix: Linq: BAD");
            }
            else
            {
                Console.WriteLine("Posix: Linq: OKAY");
            }

        }
    }
}
