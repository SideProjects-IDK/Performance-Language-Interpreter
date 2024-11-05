using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Perf_Lang_Master.models.math.model.InterpreterDesignPattern;

namespace Perf_Lang_Master.controller
{
    public class math
    {
        public class Tests
        {
            public static bool RunTests()
            {
                bool IsAllOkay = true;

                var parser = new Parser();
                var expression = parser.Parse("123 * 123 / 123");

                Console.WriteLine($"Result: {expression.Interpret()}");

                return IsAllOkay;
            }

        }
    }
}
