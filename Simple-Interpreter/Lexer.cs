﻿namespace Simple_Interpreter
{
    class Lexer
    {
        private string text;
        private int pos;
        private char currentChar;

        public Lexer(string text)
        {
            this.text = text;
            pos = 0;
            currentChar = text[pos];
        }

        public void Error()
        {
            throw new System.Exception("Error parsing input");
        }

        public void Advance()
        {
            pos++;
            if (pos > text.Length - 1)
            {
                currentChar = '\0';
            }
            else
            {
                currentChar = text[pos];
            }
        }

        public void SkipWhiteSpace()
        {
            while (currentChar != '\0' && char.IsWhiteSpace(currentChar))
            {
                Advance();
            }
        }

        public int Integer()
        {
            string result = string.Empty;
            while (currentChar != '\0' && char.IsDigit(currentChar))
            {
                result += currentChar;
                Advance();
            }
            return int.Parse(result);
        }

        public Token GetNextToken()
        {
            while (currentChar != '\0')
            {
                if (char.IsWhiteSpace(currentChar))
                {
                    SkipWhiteSpace();
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    return new Token(TokenType.Int, Integer());
                }

                if (currentChar == '+')
                {
                    Advance();
                    return new Token(TokenType.Plus, '+');
                }

                if (currentChar == '-')
                {
                    Advance();
                    return new Token(TokenType.Minus, '-');
                }

                if(currentChar == '*')
                {
                    Advance();
                    return new Token(TokenType.Mul, '*');
                }

                if(currentChar == '/')
                {
                    Advance();
                    return new Token(TokenType.Div, '/');
                }

                if(currentChar == '(')
                {
                    Advance();
                    return new Token(TokenType.LParen, '(');
                }

                if(currentChar == ')')
                {
                    Advance();
                    return new Token(TokenType.RParen, ')');
                }

                Error();
            }

            return new Token(TokenType.EOF, null);
        }

    }
}
