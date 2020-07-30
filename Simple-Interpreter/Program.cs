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
                Lexer lexer = new Lexer(text);
                Interpreter interpreter = new Interpreter(lexer);
                int result = interpreter.Expr();
                Console.WriteLine(result);
            }
        }
    }
}
