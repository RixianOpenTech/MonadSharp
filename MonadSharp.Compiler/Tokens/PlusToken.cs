﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class PlusToken : Token
    {
        public const string TokenName = "Plus";

        public PlusToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}