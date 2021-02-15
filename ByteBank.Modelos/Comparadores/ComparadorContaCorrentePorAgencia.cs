using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if(x == null)
            {
                return 1;
            }

            if(y == null)
            {
                return -1;
            }

            if(x == y)
            {
                return 0;
            }

            return x.Agencia.CompareTo(y.Agencia);

            // ** O método CompareTo da da interface IComparable já é implementada por default nas classes String e Int, não 
            // precisando então que os métodos abaixo sejam reescritos **;

            //if(x.Agencia < y.Agencia)
            //{
            //    return -1;
            //}

            //if(x.Agencia == y.Agencia)
            //{
            //    return 0;
            //}

            //return 1;
        }
    }
}
