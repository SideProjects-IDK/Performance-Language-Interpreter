﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perf_Lang_Master.models.markup
{
    public class model
    {
        public class InterpreterDesignPattern
        {
            //Expression Interface: This will be our primary interpretative unit.
            public interface IExpression
            {
                string Interpret(string context);
            }

            //Concrete Expressions: These will handle specific patterns in our markup.
            public class HeaderExpression : IExpression
            {
                public string Interpret(string context)
                {
                    return context.Replace("# ", "<h1>") + "</h1>";
                }
            }

            public class BoldExpression : IExpression
            {
                public string Interpret(string context)
                {
                    return context.Replace("*", "<b>");
                }
            }

            public class ItalicExpression : IExpression
            {
                public string Interpret(string context)
                {
                    return context.Replace("_", "<i>");
                }
            }

            //Interpreter: This class will utilize our expressions to interpret the entire context.
            public class MarkupInterpreter
            {
                private List<IExpression> expressions;

                public MarkupInterpreter()
                {
                    expressions = new List<IExpression>
            {
                new HeaderExpression(),
                new BoldExpression(),
                new ItalicExpression()
            };
                }

                public string Interpret(string context)
                {
                    foreach (var expression in expressions)
                    {
                        context = expression.Interpret(context);
                    }
                    return context;
                }
            }
        }
    }
}
