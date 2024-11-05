using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Perf_Lang_Master.models.roman.model.InterpreterDesignPattern;

namespace Perf_Lang_Master.controller
{
    public class roman
    {
        public class Tests
        {
            public static bool RunTests()
            {
                bool IsAllOkay = true;

                string roman = "MCMXXVIII"; //1928
                Context context = new Context { Input = roman };

                // Build the 'parse tree'
                List<Expression> tree = new List<Expression>
                {
                    new ThousandExpression(),
                    new HundredExpression(),
                    new TenExpression(),
                    new OneExpression()
                };

                // Interpret
                foreach (Expression exp in tree)
                {
                    exp.Interpret(context);
                }

                Console.WriteLine($"{roman} = {context.Output}");

                return IsAllOkay;
            }
        }
    }
}
