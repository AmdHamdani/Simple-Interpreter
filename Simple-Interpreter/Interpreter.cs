namespace Simple_Interpreter
{
    class Interpreter
    {

        private string text;
        private int pos;
        private Token currentToken;
        private char currentChar;
        public Interpreter(string text)
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

                Error();
            }

            return new Token(TokenType.EOF, null);
        }

        public void Eat(TokenType type)
        {
            if (currentToken.Type == type)
            {
                currentToken = GetNextToken();
            }
            else
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

            if (op.Type == TokenType.Plus)
                Eat(TokenType.Plus);
            else
                Eat(TokenType.Minus);

            Token right = currentToken;
            Eat(TokenType.Int);

            int result;
            if (op.Type == TokenType.Plus)
                result = (int)left.Value + (int)right.Value;
            else
                result = (int)left.Value - (int)right.Value;

            return result;
        }
    }
}
