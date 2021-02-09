using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {

        }

        public OperacaoFinanceiraException(string msg) : base(msg)
        {

        }

        public OperacaoFinanceiraException(string msg, Exception exInterna) : base(msg, exInterna)
        {

        }
    }
}
