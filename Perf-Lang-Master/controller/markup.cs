using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Perf_Lang_Master.models.markup.model.InterpreterDesignPattern;
using static Perf_Lang_Master.models.math.model.InterpreterDesignPattern;

namespace Perf_Lang_Master.controller
{
    public class markup
    {
        public class Tests
        {
            public static bool RunTests()
            {
                bool IsAllOkay = true;

                string markup = @"
                        # This is a header
                        This is a regular paragraph.
                        *This is a bold text.*
                        _This is an italic text._";

                var interpreter = new MarkupInterpreter();
                var html = interpreter.Interpret(markup);

                Console.WriteLine(html);

                return IsAllOkay;
            }

        }
    }
}
