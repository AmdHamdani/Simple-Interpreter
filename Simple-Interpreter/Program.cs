using System;

namespace Simple_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Calc > ");
                string text = Console.ReadLine();
                Interpreter interpreter = new Interpreter(text);
                int result = interpreter.Expr();
                Console.WriteLine(result);
            }
        }
    }
}
