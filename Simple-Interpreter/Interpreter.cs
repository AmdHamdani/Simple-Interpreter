using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Simple_Interpreter
{
    class Interpreter
    {

        private string text;
        private int pos;
        private Token currentToken;

        public Interpreter(string text)
        {
            this.text = text;
            pos = 0;
        }

        public void Error()
        {
            throw new System.Exception("Error parsing input");
        }

        public Token GetNextToken()
        {
            string temp = text;

            if (pos > text.Length - 1)
                return new Token(TokenType.EOF, null);

            char currentChar = text[pos];

            if (Char.IsDigit(currentChar))
            {
                pos++;
                return new Token(TokenType.Int, int.Parse(currentChar.ToString()));
            }

            if(currentChar == '+')
            {
                pos++;
                return new Token(TokenType.Plus, currentChar);
            }

            Error();

            return null;
        }

        public void Eat(TokenType type)
        {
            if(currentToken.Type == type)
            {
                currentToken = GetNextToken();
            } else
            {
                Error();
            }
        }

        public int Expr()
        {
            currentToken = GetNextToken();

            Token left = currentToken;
            Eat(TokenType.Int);

            Token op = currentToken;
            Eat(TokenType.Plus);

            Token right = currentToken;
            Eat(TokenType.Int);

            int result = (int)left.Value + (int)right.Value;
            return result;
        }
    }
}
