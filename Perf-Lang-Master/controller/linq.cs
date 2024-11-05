using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Perf_Lang_Master.models.linq.model.InterpreterDesignPattern;
using static Perf_Lang_Master.models.math.model.InterpreterDesignPattern;

namespace Perf_Lang_Master.controller
{
    public class linq
    {
        public class Tests
        {
            public static bool RunTests()
            {
                bool IsAllOkay = true;

                var products = new List<Product>
                {
                    new Product { Brand = "Nike", Color = "blue", Price = 150 },
                    new Product { Brand = "Adidas", Color = "red", Price = 90 },
                    new Product { Brand = "Nike", Color = "black", Price = 250 },
                    // ... other products
                };

                for (int i = 0; i < 120; i++)
                {
                    products.Add(new Product { Brand = "Nike", Color = "black", Price = 250*i });
                }

                var query = "brand:Nike; maxprice:300";
                var parser = new ProductFilterParser();
                var expression = parser.Parse(query);

                var filteredProducts = products.Where(p => expression.Interpret(p)).ToList();

                foreach (var product in filteredProducts)
                {
                    Console.WriteLine($"{product.Brand,-10}|{product.Color,-10}|{product.Price,-10}");
                    //Console.WriteLine($"Found: {product.Brand} {product.Color} priced at ${product.Price}");
                }

                return IsAllOkay;
            }

        }

        public static bool __main__(string Query)
        {
            bool IsAllOkay = true;

            List<string> Companies = ["Nike","Adidas","Target"];
            List<string> Colors = ["Red", "Red-Blue","Purple","Pink","Yellow","Yellow-Orange","Yellow-Green","Green","Lime","Lime-Green","Line-Yellow"];

            var products = new List<Product>
                {
                    //new Product { Brand = "Nike", Color = "blue", Price = 150 },
                    //new Product { Brand = "Adidas", Color = "red", Price = 90 },
                    //new Product { Brand = "Nike", Color = "black", Price = 250 },
                };

            int _constant_a = 1;
            int _constant_b = 1;
            int _constant_c = 1;

            foreach (var _x in Companies)
            {
                foreach (var _y in Colors)
                {
                    for (int i = 1; i < 120; i++)
                    {
                        products.Add(new Product { Brand = _x, Color = _y, Price = 250 * i + (_constant_a * _constant_b * (_constant_c/2)+1) });
                        _constant_c++;
                    }
                    _constant_c = 1;
                    _constant_b++;
                }
                _constant_a++;
            }

            var query = Query;
            var parser = new ProductFilterParser();
            var expression = parser.Parse(query);

            var filteredProducts = products.Where(p => expression.Interpret(p)).ToList();

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Brand,-10}|{product.Color,-10}|{product.Price,-10}");
                //Console.WriteLine($"Found: {product.Brand} {product.Color} priced at ${product.Price}");
            }

            return IsAllOkay;
        }
    }
}
