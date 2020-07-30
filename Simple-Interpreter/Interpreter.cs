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
            Eat(TokenType.Int);
            return (int)token.Value;
        }

        public int Term()
        {
            Token token = currentToken;
            Eat(TokenType.Int);
            return (int)token.Value;
        }

        public int Expr()
        {
            int result = Factor();

            while (currentToken.Type == TokenType.Plus || currentToken.Type == TokenType.Minus || currentToken.Type == TokenType.Mul || currentToken.Type == TokenType.Div)
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
                    case TokenType.Mul:
                        Eat(TokenType.Mul);
                        result *= Factor();
                        break;
                    case TokenType.Div:
                        Eat(TokenType.Div);
                        result /= Factor();
                        break;
                }
            }

            return result;
        }
    }
}
