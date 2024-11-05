using System;

namespace Perf_Lang_Master.models.math
{
    public class model
    {
        public class InterpreterDesignPattern
        {
            // Expression Interface: The primary unit of our interpreter.
            public interface IExpression
            {
                double Interpret();
            }

            // Terminal Expressions: These handle the basic units of our language, namely numbers.
            public class NumberExpression : IExpression
            {
                private double number;

                public NumberExpression(double number)
                {
                    this.number = number;
                }

                public double Interpret()
                {
                    return number;
                }
            }

            // Non-Terminal Expressions: These handle operations involving other expressions.
            public class AddExpression : IExpression
            {
                private IExpression leftExpression;
                private IExpression rightExpression;

                public AddExpression(IExpression left, IExpression right)
                {
                    leftExpression = left;
                    rightExpression = right;
                }

                public double Interpret()
                {
                    return leftExpression.Interpret() + rightExpression.Interpret();
                }
            }

            public class SubtractExpression : IExpression
            {
                private IExpression leftExpression;
                private IExpression rightExpression;

                public SubtractExpression(IExpression left, IExpression right)
                {
                    leftExpression = left;
                    rightExpression = right;
                }

                public double Interpret()
                {
                    return leftExpression.Interpret() - rightExpression.Interpret();
                }
            }

            public class MultiplyExpression : IExpression
            {
                private IExpression leftExpression;
                private IExpression rightExpression;

                public MultiplyExpression(IExpression left, IExpression right)
                {
                    leftExpression = left;
                    rightExpression = right;
                }

                public double Interpret()
                {
                    return leftExpression.Interpret() * rightExpression.Interpret();
                }
            }

            public class DivideExpression : IExpression
            {
                private IExpression leftExpression;
                private IExpression rightExpression;

                public DivideExpression(IExpression left, IExpression right)
                {
                    leftExpression = left;
                    rightExpression = right;
                }

                public double Interpret()
                {
                    double denominator = rightExpression.Interpret();
                    if (denominator == 0)
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    return leftExpression.Interpret() / denominator;
                }
            }

            public class ExponentiationExpression : IExpression
            {
                private IExpression baseExpression;
                private IExpression exponentExpression;

                public ExponentiationExpression(IExpression baseExpr, IExpression exponentExpr)
                {
                    baseExpression = baseExpr;
                    exponentExpression = exponentExpr;
                }

                public double Interpret()
                {
                    return Math.Pow(baseExpression.Interpret(), exponentExpression.Interpret());
                }
            }

            public class ModulusExpression : IExpression
            {
                private IExpression leftExpression;
                private IExpression rightExpression;

                public ModulusExpression(IExpression left, IExpression right)
                {
                    leftExpression = left;
                    rightExpression = right;
                }

                public double Interpret()
                {
                    return leftExpression.Interpret() % rightExpression.Interpret();
                }
            }

            public class SquareRootExpression : IExpression
            {
                private IExpression expression;

                public SquareRootExpression(IExpression expr)
                {
                    expression = expr;
                }

                public double Interpret()
                {
                    double value = expression.Interpret();
                    if (value < 0)
                        throw new InvalidOperationException("Cannot take the square root of a negative number.");
                    return Math.Sqrt(value);
                }
            }

            // Parser: We will create a simple parser to construct our expressions based on the input.
            public class Parser
            {
                public IExpression Parse(string expression)
                {
                    var tokens = expression.Split(' ');

                    IExpression leftExpression = new NumberExpression(double.Parse(tokens[0]));

                    for (int i = 1; i < tokens.Length; i += 2)
                    {
                        switch (tokens[i])
                        {
                            case "+":
                                leftExpression = new AddExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                            case "-":
                                leftExpression = new SubtractExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                            case "*":
                                leftExpression = new MultiplyExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                            case "/":
                                leftExpression = new DivideExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                            case "^":
                                leftExpression = new ExponentiationExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                            case "%":
                                leftExpression = new ModulusExpression(leftExpression, new NumberExpression(double.Parse(tokens[i + 1])));
                                break;
                        }
                    }

                    return leftExpression;
                }
            }

            //// Testing the Interpreter Design Pattern
            //// Client Code
            //public class Client
            //{
            //    public static void Main()
            //    {
            //        var parser = new Parser();
            //        var expression = parser.Parse("3 + 5 - 2 * 4 / 2 ^ 2 sqrt 16");

            //        Console.WriteLine($"Result: {expression.Interpret()}");

            //        Console.ReadKey();
            //    }
            //}
        }
    }
}
