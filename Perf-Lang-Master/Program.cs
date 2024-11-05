namespace Perf_Lang_Master
{
    internal class Program
    {
        public static string _version = $"({DateTime.Now.ToString("yyyy.mm.dd")})";
        static void Main(string[] args)
        {
            Console.WriteLine($"Perf: Posix: :version{{{_version}}}");

            while (true)
            {
                Console.Write("pex> ");
                string _input = Console.ReadLine();
                List<string> _inputs = _input.Split(' ').ToList();

                bool IsALinqCondition   = false;
                bool IsARomanCondition  = false;
                bool IsAMathCondition   = false;
                bool IsAMarkupCondition = false;

                if (_inputs.Count > 0)
                {
                    if (_inputs[0].ToString().StartsWith(":linq"))
                    { 
                        IsALinqCondition=true;
                    }
                    else if (_inputs[0].ToString().StartsWith(":roman"))
                    {
                        IsARomanCondition = true;
                    }
                    else if (_inputs[0].ToString().StartsWith(":math"))
                    {
                        IsAMathCondition = true;
                    }
                    else if (_inputs[0].ToString().StartsWith(":markup"))
                    {
                        IsAMarkupCondition = true;
                    }
                    else if (_inputs[0].ToString().StartsWith("//"))
                    {
                        continue;
                    }
                    else 
                    { 
                        IsALinqCondition = true; 
                    }
                }
                else
                {
                    continue;
                }


                if (IsALinqCondition)
                {
                    _inputs[0] = _inputs[0].Replace(":linq","");

                    if (!controller.linq.__main__(_inputs.ToString()))
                    {
                        Console.WriteLine("Linq: BAD");
                    }
                    else
                    {
                        Console.WriteLine("Linq: OKAY");
                    }
                }


                IsALinqCondition = false;
                IsARomanCondition = false;
                IsAMathCondition = false;
                IsAMarkupCondition = false;

            }
            
        }
        static string GetIndent(int level)
        {
            return new string(' ', Math.Max(0, level * 2));
        }
    }
}
