﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perf_Lang_Master.models.linq
{
    public class model
    {

        public class InterpreterDesignPattern
        {
            //Product Class: Represents a product in our e-commerce system.
            public class Product
            {
                public string Brand { get; set; }
                public string Color { get; set; }
                public decimal Price { get; set; }
                // ... other properties
            }

            //Expression Interface: The primary interface for our interpreter.
            public interface IExpression
            {
                bool Interpret(Product product);
            }

            //Concrete Expressions
            public class BrandExpression : IExpression
            {
                private readonly string brand;

                public BrandExpression(string brand)
                {
                    this.brand = brand;
                }

                public bool Interpret(Product product)
                {
                    return product.Brand == brand;
                }
            }

            public class ColorExpression : IExpression
            {
                private readonly string color;

                public ColorExpression(string color)
                {
                    this.color = color;
                }

                public bool Interpret(Product product)
                {
                    return product.Color == color;
                }
            }

            public class PriceRangeExpression : IExpression
            {
                private readonly decimal minPrice;
                private readonly decimal maxPrice;

                public PriceRangeExpression(decimal min, decimal max)
                {
                    minPrice = min;
                    maxPrice = max;
                }

                public bool Interpret(Product product)
                {
                    return product.Price >= minPrice && product.Price <= maxPrice;
                }
            }

            //Compound Expression (For combining our criteria)
            public class AndExpression : IExpression
            {
                private readonly List<IExpression> expressions;

                public AndExpression(params IExpression[] expressions)
                {
                    this.expressions = new List<IExpression>(expressions);
                }

                public bool Interpret(Product product)
                {
                    return expressions.All(expr => expr.Interpret(product));
                }
            }

            //Parser: Parser (to convert user's DSL to a compound expression)
            public class ProductFilterParser
            {
                public IExpression Parse(string input)
                {
                    var criteria = input.Split(';');
                    var expressions = new List<IExpression>();

                    foreach (var criterion in criteria)
                    {
                        var parts = criterion.Trim().Split(':');
                        if (parts[0] == "brand")
                        {
                            expressions.Add(new BrandExpression(parts[1].Trim()));
                        }
                        else if (parts[0] == "color")
                        {
                            expressions.Add(new ColorExpression(parts[1].Trim()));
                        }
                        else if (parts[0] == "minprice")
                        {
                            decimal minPrice = decimal.Parse(parts[1]);
                            expressions.Add(new PriceRangeExpression(minPrice, decimal.MaxValue));
                        }
                        else if (parts[0] == "maxprice")
                        {
                            decimal maxPrice = decimal.Parse(parts[1]);
                            expressions.Add(new PriceRangeExpression(decimal.MinValue, maxPrice));
                        }
                    }

                    return new AndExpression(expressions.ToArray());
                }
            }
        }
    }
}
