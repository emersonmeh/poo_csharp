using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            //CalcularBonificacao();
            UsarSistema();

            Console.ReadLine();

        }

        public static void UsarSistema()
        {
            SistemaInterno sistema = new SistemaInterno(); 

            Diretor roberta = new Diretor(5000, "541.331.214-98");
            roberta.Nome = "Roberta";
            roberta.Senha = "123";


            GerenteDeConta camila = new GerenteDeConta("341.566.998-0");
            camila.Nome = "Camila";
            camila.Senha = "abc";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "1234";

            sistema.Logar(parceiro, "1234");
            sistema.Logar(roberta, "123");

        }

        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            Designer pedro = new Designer("833.132.345-12");
            pedro.Nome = "Pedro";

            Diretor roberta = new Diretor(5000, "541.331.214-98");
            roberta.Nome = "Roberta";

            Auxiliar igor = new Auxiliar("541.311.541-x");
            igor.Nome = "Igor";

            GerenteDeConta camila = new GerenteDeConta("341.566.998-0");
            camila.Nome = "Camila";

            Desenvolvedor emerson = new Desenvolvedor("Emerson");

            gerenciador.Registrar(pedro);
            gerenciador.Registrar(roberta);
            gerenciador.Registrar(igor);
            gerenciador.Registrar(camila);
            gerenciador.Registrar(emerson);

            Console.WriteLine("Emerson Salario: " + emerson.Salario);
            Console.WriteLine("Total Bonificacao: " + gerenciador.GetTotalBonificacao());
        }
    }
}
