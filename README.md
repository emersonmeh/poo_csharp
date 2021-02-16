	> ORIENTA��O A OBJETOS COM .NET/C# - Curso ALURA

	M�todos/Propriedades publicos (PUBLIC) s�o vis�veis em toda a solution do projeto, podendo ser utilizados em 
	diversas partes do c�digo.

	M�todos/Propriedades privados (PRIVATE) s�o vis�veis somente para a classe � qual pertencem e s� podem ser utilizados
	por sua classe pai.

	O uso de uma Classe como tipagem de uma propriedade � chamado de COMPOSI��O.

	M�todos Get e Set proveem formas pr�ticas para obten��o e altera��o de valores das propriedades da Classe 
	quando estas s�o inst�nciadas para uso, fazendo com que n�o seja necess�rio escrever m�todos repetitivos extensos e 
	permitindo que altera��es posteriores, como por exemplo valida��es extras para cada tipo de propriedade da Classe n�o 
	quebre o c�digo j� existente.

	Propriedades est�ticas (STATIC) s�o pertencentes � Classe e n�o ao objeto que est� sendo instanciado, sendo assim, os valores
	atribuidos � estas propriedades s�o acrescentados (ou n�o) e n�o zerados cada vez que uma inst�ncia da Classe � criada, j� que, 
	somente a classe pode modific�-lo.


	OOP com C# - Parte 3

	Por convers�o, quando uma propriedade da Classe tem um custo de processamento(um calculo, por exemplo), � criado um M�todo para
	representar essa propriedade.
		Ex.:
			public double Bonificacao {get {Salario * 0.10}; set {}} --> possui um custo de processamento ;

			--> transforma em m�todo para evitar o custo de processamento toda vez que a instancia da Classe for utilizada;
			public double GetBonificacao() 
			{
				return Salario * 0.10;
			}

	� poss�vel ter mais de um m�todo dentro da Classe com o mesmo nome, desde que os parametros do m�todo sejam de tipos diferentes.
	Isso � chamado de SOBRECARGA DE M�TODO.

	Classe que possuem Heren�a s�o tamb�m chamadas de Classe que derivam de outra Classe.

	Para que seja poss�vel utilizar um m�todo da Classe base dentro da Classe derivada por�m com comportamento diferente � necess�rio
	utilizar a palavra chave VIRTUAL na Classe base e OVERRIDE na Classe derivada para que a sobrecarga funcione cada uma com
	seu devido comportamento.
		Ex.:
			Class Animal 
			{
				public string Especie {get; set;}

				public virtual string Grupo()
				{
					if(Especie == "Gato")
					{
						return "Felino";
					}
				}
			}

			Class Dog : Animal 
			{
				public override string Grupo()
				{
					return "Canino";
				}
			}

	Tamb�m � poss�vel utilizar as palavras chaves VIRTUAL e OVERRIDE para propriedades da classe, diferente de quando temos
	campos p�blicos (inclusive, n�o � uma boa pr�tica manter campos p�blicos no c�digo), nestes casos o compilador vai acusar o erro.
	
		public string nome; ---> campo publico
		public string Nome {get; set;} --> propriedade

	A palavra chave BASE � utilizada quando h� necessidade de fazer refer�ncia � algum m�todo ou propriedade da classe pai
	da qual se esta herdando as caracter�sticas.

	POLIMORFISMO: Trata objetos inst�nciados de uma Classe derivada como que se fosse a Classe base, evitando repeti��es
	de c�digo e v�rias sobrecargas iguais.
	( https://pt.wikipedia.org/wiki/Polimorfismo_(ci%C3%AAncia_da_computa%C3%A7%C3%A3o) )


	Ao inserir parametros no contrutor da Classe base, estes tornam-se obrigat�rios na constru��o do objeto ao ser instanciado. Nas
	Classes derivadas (que herdam da Classe base) � necess�rio que o parametro tbm seja especificado em seu construtor, por�m, o 
	contrutor da Classe base � sempre chamado primeiro. Sendo assim, � necess�rio passar o parametro recebido na Classe derivada
	para o construtor da Classe base afim de satisfazer a obrigatoriedade do parametro para a constru��o do objeto.
		Ex.: public Pessoa(string nome) : base(nome) {}

	O modificador de acesso PROTECTED torna a propriedade/m�todo publico para a Classe que o criou e para as Classes que 
	herdam(derivadas) deste e privado para todas as demais Classes do programa.

	M�todos STATIC pertencem somente � Classe que os criou e n�o podem fazer chamadas de m�todos de inst�ncia, a n�o ser que, o 
	m�todo que est� sendo chamado tamb�m seja do tipo STATIC.

	Classes ABSTRACT(Abstratas) servem como base para contru��o de objetos derivados e n�o faz sentido que as mesmas possam ser 
	inst�nciadas diretamente, usando o modificador Abstract na Classe, impedimos que a mesma seja inst�ncia mesmo que por engano.

	M�todos ABSTRACT s�o assinaturas dentro da Classe que indicam que, assim que a Classe for inst�nciada os m�todos devem 
	obrigat�riamente ser implementados. Funciona semelhante aos m�todos VIRTUAL com a diferente de que n�o possuem corpo
	declarado com comportamento padr�o e sua implementa��o � obrigat�rio para quem herda a Classa � qual pertecem.
	M�todos Abstratos S� PODEM PERTENCER A CLASSES ABSTRATAS.

	C# N�O POSSUI HERAN�A MULTIPLA, quando h� necessidades de que uma Classe derive de mais de uma Classe, uma delas deve 
	ser transformada em INTERFACE.
	INTERFACE n�o � uma classe. INTERFACE implementa uma assinatura de m�todos que ela pode representar, assim como Classes e M�todos
	ABSTRACT, com a diferen�a que na INTERFACE n�o se utiliza modificadores de acesso (public, protect) na implementa��o dos 
	m�todos. INTERFACE tamb�m pode ser chamada de Contrato, pois, quem implementa a interface deve garantir que todos os m�todos
	dela sejam obrigatoriamente implementados.


	*** PARTE 04 - EXCE��ES

	Exce��es s�o propagadas na pilha de chamadas do compilador (call stack) e podem ser capturadas para tratamento utilizando os 
	blocos TRY {} CATCH(){} ;
	Podem haver v�rias blocos Catch, desde que, tratando Exce��es derivadas de Exception, pois, uma vez que um bloco Catch
	esteja tratando o nivel mais baixo de exce��o (Exception) os blocos catch que vierem abaixo ir�o gerar um erro.


	THROW age como controle de fluxo e server para lan�amento de excess�es. O throw captura a excess�o e passa adiante na
	stack para que outro m�todo fa�a o tratamento.
	Quando se est� fora do contexto de exce��o - um bloco catch, por exemplo - � poss�vel lan�ar uma exce��o inst�nciando-a
	da seguinte forma: throw new Exception();


	PROPRIEDADES SOMENTE LEITURA : O modificador READONLY fazer com que a propriedade torne-se somente leitura, sendo assim,
	a mesma s� pode ser alterada pelo construtor da Classe. Isso garante que o valor n�o seja alterado e sim, seja criada
	uma nova inst�ncia sempre que necess�rio.
	Para uso do READONLY a propriedade tem que ser PRIVATE e o set n�o deve existir na declara��o publica.
		Ex.: 
			private readonly int _valor;
			public int Valor { get {return _valor} };

	O exemplo acim elucida a forma como por baixo dos panos o compilador cria as propriedades, ent�o, para simplificar a 
	escrita da propriedade na Classe, somente � necess�rio remover o setter que automaticamente a propriedade passa a ser
	READONLY.
		Ex.: 
			public int Valor { get; };

	ARGUMENTEXCEPTION pode ser utilizado para construir exce��es "personalizadas" para o tratamento de erros de argumeto
	espec�ficos da aplica��o que est� sendo constru�da.

	O operador NAMEOF() transforma um parametro dentro do contexto em String.
		Ex.: nameof(numero);


	� poss�vel criar Exce��es personalizadas para suprir os problemas do dom�nio, por�m, para que a exece��o seja capturada
	dentro do bloco catch, a mesma deve herdar as caracteristicas da Classe Exception.

	INNEREXCEPTION serve para capturar exe��es internas, n�o expondo os dados desta diretamenta no StackTrace caso um erro 
	ocorra, por�m, preservando todo o Trace para que o desenvolvedor possa ter acesso ao Trace completo posteriormente.
		Ex.: 
			try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new Exception("Saldo insuficiente", ex); <-- Altera a mensagem e guarda o inner exception.
            }

	FINALLY executa uma a��o independente de ter ocorrido ou n�o uma exce��o na leitura dos blocos try/catch.

	USING � uma diretiva que "simula" os blocos try/catch/finally. Caso haja a necessidade de um bloco finally usar de um objeto
	instanciado dentro do bloco catch, para n�o haver a necessidade de que a vari�vel de refer�ncia fique solta fora dos blocos
	de execu��o, usa-se o using(){} para int�ncia e captura de exce��o no lugar do try/catch/finally.
	O bloco USING � usado basicamente quando h� a necessidade de libera��o de recurso de um objecto rec�m criado. 
	Para que uma Classe seja inst�nciada dentro de um bloco USING, � necess�rio que a mesma implemente a interface IDisposable() que
	possui como assinatura um m�todo respons�vel para encerrar poss�veis conex�es que tenham ficado ativas.
		Ex.:
			using(LeitorDeArquivo leitor = new LeitorDeArquivo("Arquivo.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }

	
	*** PARTE 05 - DLLs e Documenta��o

	Modificador de acesso INTERNAL fazer com que a Classe/M�todo seja acess�vel somente dentro do projeto que foi criada, por mais
	que o projeto seja compartilhado com outros projetos (Refer�ncia de Projeto) a Classe continua mantendo seu n�vel de
	acessibilidade somente para o projeto � qual foi criada.
		Ex.: internal class AutenticacaoHelper{ }

	*Obs.: Caso uma nova Classe seja criada sem o modificador de acesso (SOMENTE CLASSES) o compilador entende que o n�vel
	de acesso da Classe � INTERNAL.
		Ex.: class AutenticadorHelper{ }


	Modificador INTERNAL PROTECTED torna o M�todo visivel para Classes dentro do projeto e para Classes que derivam fora do projeto.
		Ex.: internal protected abstract double GetBonificacao(){ } 

	Para DOCUMENTAR Classes e M�todos P�blicos basta utilizar as tr�s barras /// em conjunto com a TAG XML <summary>;
		Ex.: 
			/// <summary>
			/// Defini uma conta corrente do banco ByteBank
			/// </summary>

	Uma vez habilitado no Visual Studio a gera��o de documenta��o, todos as Classes e M�todos publicos que n�o tiverem documentados
	ficaram marcados com uma mensagem de erro, por�m, isso n�o impede a compila��o e funcionamento do projeto.
	Tamb�m � poss�vel documentar Exce��es que ser�o lan�adas em caso de algum erro. Para exce��es utilizar a tag <exception cref="Nome_Exce��o">.
	Para fazer refer�ncia ao parametro que esta sendo utilizado em m�todos, utilizar a tag <paramref name="nome_parametro" />

	Para representar datas usa-se a Classe DATETIME() nativo do C#.
		Ex.: DateTime data = new DateTime();

	Para efetuar calculo com datas � necess�rio utilizar a Classe TIMESPAN(). N�O � poss�vel efetuar calculo de Datas utilizando a
	classe DateTime().
		Ex.: TimeSpan calculoData = data1 - data2;

	Para f�cil tratamento dos calculos com Datas utilizar a bibliota HUMANIZER encontrada no NuGets;


	*** PARTE 06 - Strings, Express�es Regulares e a classe Object

	Manipula��o de Strings:
		.string.Substring("index"); -> Substring � inclusivo, vai retornar a string a partir do index passado no paramentro
	incluindo o caractere contido no valor do index;
	
	M�todo INDEXOF() server para obter o index de uma string ou char;

	M�todo REMOVE() remove parte da string a partir de um valor de index;

	Para trabalhar com EXPRESS�ES REGULARES no C#, utilizar a Classe REGEX();
		Regex.IsMatch(); -> verifica um padr�o em texto e retorna true/false;
		Regex.Match(); -> verifica um padr�o e retorna um objeto com o resultado da busca. O retorno � um objeto do tipo Match e
		dentro dele � poss�vel obter o Value.

		[0-9][a-Z][a-z] -> os valores entre colchetes s�o padr�es de intervalo;
		{4}{10}{2} -> os valores entre chaves s�o quantificadores, ou seja, representa a quantidade de vezes que um padr�o 
	ir� se repetir;
		{0,1}{3,5} -> quantificadores podem conter intervalos com valores separados por v�rgula;
		? -> quando quantificadores possuem intervalos de {0,1} � poss�vel simplificar utilizando o caractere ? ;

		Ex.: string padrao = "[0-9]{4,5}-?[0-9]{4}" -> Regex para numeros de telefone 98762-9898 ou 2121-8765


	Classe OBJECT -> toda Classe dentro dentro do .NET/C# deriva (impl�citamente) do tipo OBJECT;


	� poss�vel executar CONVERS�O EXPL�CITA de Classes quando for necess�rio converter uma Classe de n�vel mais baixo
	em uma Classes de n�vel mais alto, para isso � necess�rio utilizar os par�nteses (CAST).
		Ex.: 
			public override bool Equals(object obj)
			{
				Cliente novoCliente = (Cliente)obj; //** Convers�o expl�cita de obj em Cliente
			}

	A convers�o utilizando (Cliente)obj espera que o objeto recebido seja do tipo Cliente, caso contr�rio uma Exception vai ser 
	exibida informando que o tipo de refer�ncia n�o � compat�vel.
	� poss�vel fazer o CAST de outra forma, sem que uma Exception seja lan�ada quando um tipo direferente for recebido. Para isso
	utiliza a palavra reservada AS que indica o tipo do objeto que espera receber, caso seja de um tipo diferente, a convers�o
	ir� retornar NULL;
		Ex.: 
			public override bool Equals(object obj)
			{
				Cliente novoCliente = obj as Cliente; // retorna NULL caso obj seja de tipo diferente
			}
	Com essa abordagem � poss�vel fazer a verifica��o da vari�vel novoCliente antes de prosseguir na execu��o do c�digo.

	
	*** List, Lambda e LINQ

	M�TODOS DE EXTENS�O -> � poss�vel extender M�todos do .NET/C# de forma a criar novos comportamentos para Classes j� 
	pr�-estabelecidas, o m�todo extendido N�O faz parte da Classe pai, por�m, atribui novas funcionalidades(comportamento) � Classe.
	Para extender um m�todo, � feito o uso da palavra reservada THIS antes do tipo(Classe) que est� sendo extendido.

		Ex.: public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens){}


	M�todos / Classes GEN�RICAS -> Para cria��o de m�todos gen�ricos, o tipo <T> deve ser especificado na defini��o da Classe afim
	de passar esse parametro gen�rico para os M�todos que ela cont�m.
		Ex.: public static class Teste<T>
		{
			public static void Mensagem(T mensagem)
			{
				Console.WriteLine(mensagem);
			}
		}

	Para M�TODOS DE EXTENS�O GEN�RICOS o tipo <T> N�O DEVE ser passado na declara��o da Classe e sim no m�todo que ser� extendido.
		Ex.: public static void Mensagem<T>(T mensagem)
		{
			Console.WriteLine(mensagem);
		}

	
	No .NET/C# o uso de VAR para cria��o de v�ri�veis deve � poss�vel desde que a vari�vel seja inicializada, pois, por ser do tipo
	impl�cito, � necess�rio que o compilador saiba qual o tipo do valor que ser� atribuido.
		Ex.: var minhaLista = new List<int>();


	Sort(); -> Ordena crescente;
    Reverse(); -> Ordena do ultimo elemento para o primeiro (n�o segue ordem alfab�tica ou decrescente se os valores n�o tiverem
	sido previamente ordenados);

	IComparable -> Para fazer ordena��o de conjuntos de objetos o simples uso do Sort() n�o vai funcionar, para isso � necess�rio um 
	m�todo (especifico da interface IComparable) de compara��o para que seja poss�vel essa ordena��o. O m�todo CompareTo() da interface
	IComparable espec�fica em seu contrato que deve ser recebido um object para compara��o e deve retorna um INT.
		Ex.:
			public class ContaCorrente : IComparable 
			{
				public int CompareTo(object obj)
				{
					// Retorna negativo quando a inst�nca precede o obj;
					// Retorna zero quando nossa inst�ncia e obj forem equivalentes;
					// Retorna positivo diferente de zero quando a precedencia for de obj;

					var outraConta = obj as ContaCorrente;

					if(outraConta == null)
					{
						return -1;
					}

					if(Numero < outraConta.Numero)
					{
						return -1;
					}

					if(Numero == outraConta.Numero)
					{
						return 0;
					}

					return 1;
				}
			}
			
	IComparer<T> -> Para que seja poss�vel ordenar um conjunto de objetos especificando um parametro espec�fico, utiliza-se a 
	interfae IComparer, que � utilizada como parametro do m�todo Sort(Icomparer<T>) e possibilita escrever um m�todo para essa 
	ordena��o, j� que, o mesmo � gen�rico e recebe na implementa��o qual a Classe que vai ser utilizada.
		Ex.:
			public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>{}
	Assim como na interface IComparable a interface ICompare<T> possui em seu contrato um m�todo Compare() que deve retornar um int.

	Para utilizar a Classe ComparadorContaCorrentePorAgencia em conjunto com o m�todo Sort():
		Ex.: contas.Sort(new ComparadorContaCorrentePorAgencia()); //utiliza uma inst�ncia da Classe criada passada como parametro para o Sort();
	
	ORDERBY -> Uma forma mais simples de ordena��o de lista utilizando LAMBDA. Varre uma lista e ordena os valores e retorna uma
	nova lista do tipo IOrderedEnumerable<T>;
		Ex.: var listaOrdenada = contas.OrderBy(x => x.Agencia);


	*** Entrada e Sa�da (I/O) com streams

	FILESTREAM() -> Classe do .NET/C# utilizada para leitura/grava��o de arquivos em diversos formatos.
		Ex.:
			var enderecoDoArquivo = "contas.txt";
            var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

			// Espa�o para armazenamento dos bytes do arquivo que vai ser lido;
            var buffer = new byte[1024]; // 1 kb

	O buffer � criado para que seja poss�vel lhe dar com arquivos maiores do que a mem�ria do computador e tamb�m para que
	o programa n�o seja sobrecarregado, pois, o buffer por ser reutilizado e o tamanho especificado vai sendo
	substituido conforme o arquivo vendo sendo lido (Desde que seja percorrido e substituido por um la�o While, por exemplo).

	Para que os bytes sejam interpretados como texto � necess�rio um Codificador/Decodificador(Coder/Decoder) que fa�a
	a transforma��o do bytes em Texto seja seguindo a tabela ASCII ou UTF-8, UTF-16, UTF-32, etc.
	Para isso pode ser utilizada a Classe UTF8Encoding(), por exemplo, que � responsav�l por fazer o papel de 
	traduzir os bytes. A Classe UTF8Enconding herda da Classe ENCODING() que � uma Classe Abstrata.
		Ex.:
			// Decoding dos bytes em texto
            var a = new UTF8Encoding();
            var texto = a.GetString(buffer);
	
	Quando o arquivo � gerado, por exemplo, em uma m�quina Windows e o programa que vai fazer o Decoding tamb�m roda em
	uma m�quina Windows, � poss�vel utilizar uma propriedade est�tica da Classe ENCODING() para decodificar sem ter que
	explicitamente informar qual o tipo de codifica��o que foi utilizado.
		Ex.: var a = Encoding.Default;

	FILESTREAM.Close() -> M�todo que libera o arquivo para outros usos.

	Para que n�o seja necess�ria a utiliza��o do m�todo Close toda vez que formos trabalhar com IO podemos utilizar a 
	diretiva USING(), j� que, a Classe FileStream em sua composi��o herda da interface IDisposable() que fica respons�vel
	por chamar implicitamente o m�todo Close.
		Ex.: 
			using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
			{
				// implementa��o
			}

	� poss�vel dividir os arquivos de uma mesma Classe em arquivos diferentes, que ser�o lidos pelo compilador como um
	arquivo �nico. Para isso basta antes da palavra reserva class utilizar o modificador PARTIAL;
		Ex.: partial class Program {}

	Para trabalhar com Stream de forma mais simples, sem ter que se preocupar tanto com Encoding/Decoding e tamanho do Buffer
	utiliza-se a Classe StreamReader() em conjunto com a Classe FileStream. A Classe StreamReader possui diversos
	m�todos para leitura e convers�o de bytes em texto.
		Ex.:
			using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDoArquivo);

				// L� somente uma linha do arquivo
                var linha = leitor.ReadLine();

				// L� todas as linhas de um arquivo (CUIDADO, pois se o arquivo for muito grande pode ocorrer um Overflow de mem�ria)
				var linha2 = leitor.ReadToEnd();

                Console.WriteLine(linha);
            }

	Para percorrer todo o arquivo sem que tenha que carregar tudo de uma vez em mem�ria utilizando o m�todo ReadToEnd(), utiliza
	um la�o While com o verificador que indica quando o arquivo foi percorrido at� o final.
		Ex.:
			using (var leitor = new StreamReader(fluxoDoArquivo))
            {
				// EndOfStream indica a �ltima linha do arquivo
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.Read();
                    Console.WriteLine(linha);
                }
            }

	StreamWriter -> utilizado para criar arquivos em um caminho pr� definido. Recebe um FileStream como primeiro parametro
	contendo a informa��o de path e FileMode (Create(sobrescreve arquivos com o mesmo nome) ou CreateNew(se o arquivo tiver
	o mesmo nome ser� lan�ada uma exce��o.)).
		Ex.:
			using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8)) 
            {
                escritor.Write("456, 456765, 4756.89, Emerson Santos");
            }
	Obs.: A Classe FileStream possui um m�todo Write, por�m, � necess�rio lhe dar com a convers�o de bytes, tamanho do
	buffer e tipo de encoding.

	Em tempo de execu��o, toda a escrita no arquivo s� vai estar dispon�vel ap�s finalizar o processamento, pois, enquanto
	o processo de gerar o arquivo esta em execu��o, os dados que ser�o gravados ficam armazenados em buffer de mem�ria. Essa
	abordagem � mais r�pida, por�m, caso um erro ocorra no momento da grava��o, os dados em mem�ria ser�o perdidos.
	Para que os dados sejam gravados linha a linha no arquivo em tempo de execu��o, a Classe StreamWriter possui um m�todo
	chamado Flush(), que libera o buffer para o Stream assim que a leitura da linha � realizada.
		Ex.:
			using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8)) 
            {
                escritor.Write("456, 456765, 4756.89, Emerson Ferreira Santos");
                escritor.Flush();
            }

	Quando n�o h� necessidade que o arquivo gerado seja lido por um humano, � poss�vel gerar arquivo com dados bin�rios afim
	de economizar espa�o, processamento, mem�rio e ganhar maior desempenho na escrita e leitura desse arquivo.
	Para arquivos bin�rios, tanto na escrita quanto na leitura do arquivo, existem as Classes BinaryWriter() e 
	BinaryReader().
	Para LEITURA do arquivo bin�rio, os dados devem ser decodificados na ordem que foram gerados, caso o contrario, haver�
	um problema de decoding.
		Ex.: 
			// escrita 
				using(var escritor = new BinaryWriter(fs))
				{
					escritor.Write(1234);
					escritor.Write("teste");
				}

			// leitura
				using(var leitor = new BinaryReader(fs))
				{
					var inteiro = leitor.ReadInt32();
					var texto = leitor.ReadString();
				}


	CLASSE FILE -> forma mais f�cil de leitura de arquivos, por�m, deve tomar cuidado com seu uso, pois, o arquivo � lido
	completamente de uma vez, sem nenhum tipo de controle de buffer ou mem�ria, sendo assim, caso seja feita a leitura de um
	arquivo muito grande, o uso do File pode deteriorar muito o desempenho do sistema ou causar estouro de mem�ria.
		Ex.:
			var linhas = File.ReadAllLines("contas.txt");
			
			foreach (var linha in linhas)
			{
				Console.WriteLine(linha);
			}

	Al�m de leitura, a Classe File possui tamb�m m�todos para escrita de arquivos.
		Ex.: File.WriteAllText("nome_arquivo.txt", "texto no arquivo");

