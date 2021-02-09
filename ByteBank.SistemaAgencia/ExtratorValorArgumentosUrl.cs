using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorArgumentosUrl
    {
        private readonly string _argumentos;
        public string Url { get; }

        public ExtratorValorArgumentosUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("O argumento não pode ser nulo ou vazio", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            Url = url;
        }

        public string GetValor(string nomeParametro)
        {
            if (String.IsNullOrEmpty(nomeParametro))
            {
                throw new ArgumentNullException("O argumento não pode ser nulo ou vazio", nameof(nomeParametro));
            }

            int tamanhoParamentro = nomeParametro.Length;
            int index = _argumentos.IndexOf(nomeParametro);

            string resultado = _argumentos.Substring(index + tamanhoParamentro + 1);
            int indexRemove = resultado.IndexOf('&');

            if(indexRemove == -1)
            {
                return resultado;
            }

            return resultado.Remove(indexRemove);
        }
    }
}
