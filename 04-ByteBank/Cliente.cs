using System;
using System.Collections.Generic;
using System.Text;

namespace _04_ByteBank
{
    public class Cliente
    {
        public string Nome { get; set; }
        private string _cpf;
        public string CPF { 
            get 
            {
                return _cpf; 
            } 
            set 
            {
                //Aqui vem a lógica para validação do CPF.
                _cpf =  value;
            } 
        }
        public string Profissao { get; set; }

    }
}
