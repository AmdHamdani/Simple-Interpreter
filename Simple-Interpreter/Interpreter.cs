﻿using System.Runtime.InteropServices;

namespace Simple_Interpreter
{
    class Interpreter
    {

        private Lexer lexer;
        private Token currentToken;

        public Interpreter(Lexer lexer)
        {
            this.lexer = lexer;
            currentToken = lexer.GetNextToken();
        }

        public void Error()
        {
            throw new System.Exception("Invalid Syntax");
        }

        public void Eat(TokenType type)
        {
            if (currentToken.Type == type)
            {
                currentToken = lexer.GetNextToken();
            }
            else
            {
                Error();
            }
        }

        public int Factor()
        {
            Token token = currentToken;
            int result = 0;

            if (token.Type == TokenType.Int)
            {
                Eat(TokenType.Int);
                return (int)token.Value;
            }
            else if (token.Type == TokenType.LParen)
            {
                Eat(TokenType.LParen);
                result = Expr();
                Eat(TokenType.RParen);
                return result;
            }

            return result;
        }

        public int Term()
        {
            int result = Factor();

            while (currentToken.Type == TokenType.Mul || currentToken.Type == TokenType.Div)
            {
                Token token = currentToken;
                if (token.Type == TokenType.Mul)
                {
                    Eat(TokenType.Mul);
                    result *= Factor();
                }
                else if (token.Type == TokenType.Div)
                {
                    Eat(TokenType.Div);
                    result /= Factor();
                }
            }

            return result;
        }

        public int Expr()
        {
            int result = Term();

            while (currentToken.Type == TokenType.Plus || currentToken.Type == TokenType.Minus)
            {
                Token token = currentToken;
                switch (token.Type)
                {
                    case TokenType.Plus:
                        Eat(TokenType.Plus);
                        result += Term();
                        break;
                    case TokenType.Minus:
                        Eat(TokenType.Minus);
                        result -= Term();
                        break;
                }
            }

            return result;
        }
    }
}
