using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Interpreter
{
    class Token
    {
        private TokenType type;
        private object value;

        public Token(TokenType type, object value)
        {
            this.type = type;
            this.value = value;
        }

        public object Value { get => value; set => this.value = value; }
        internal TokenType Type { get => type; set => type = value; }

        public override string ToString()
        {
            return $"Token({type}, {value})";
        }
    }
}
