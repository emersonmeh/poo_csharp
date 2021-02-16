	> ORIENTAÇÃO A OBJETOS COM .NET/C# - Curso ALURA

	Métodos/Propriedades publicos (PUBLIC) são visíveis em toda a solution do projeto, podendo ser utilizados em 
	diversas partes do código.

	Métodos/Propriedades privados (PRIVATE) são visíveis somente para a classe à qual pertencem e só podem ser utilizados
	por sua classe pai.

	O uso de uma Classe como tipagem de uma propriedade é chamado de COMPOSIÇÃO.

	Métodos Get e Set proveem formas práticas para obtenção e alteração de valores das propriedades da Classe 
	quando estas são instânciadas para uso, fazendo com que não seja necessário escrever métodos repetitivos extensos e 
	permitindo que alterações posteriores, como por exemplo validações extras para cada tipo de propriedade da Classe não 
	quebre o código já existente.

	Propriedades estáticas (STATIC) são pertencentes à Classe e não ao objeto que está sendo instanciado, sendo assim, os valores
	atribuidos à estas propriedades são acrescentados (ou não) e não zerados cada vez que uma instância da Classe é criada, já que, 
	somente a classe pode modificá-lo.


	OOP com C# - Parte 3

	Por conversão, quando uma propriedade da Classe tem um custo de processamento(um calculo, por exemplo), é criado um Método para
	representar essa propriedade.
		Ex.:
			public double Bonificacao {get {Salario * 0.10}; set {}} --> possui um custo de processamento ;

			--> transforma em método para evitar o custo de processamento toda vez que a instancia da Classe for utilizada;
			public double GetBonificacao() 
			{
				return Salario * 0.10;
			}

	É possível ter mais de um método dentro da Classe com o mesmo nome, desde que os parametros do método sejam de tipos diferentes.
	Isso é chamado de SOBRECARGA DE MÉTODO.

	Classe que possuem Herença são também chamadas de Classe que derivam de outra Classe.

	Para que seja possível utilizar um método da Classe base dentro da Classe derivada porém com comportamento diferente é necessário
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

	Também é possível utilizar as palavras chaves VIRTUAL e OVERRIDE para propriedades da classe, diferente de quando temos
	campos públicos (inclusive, não é uma boa prática manter campos públicos no código), nestes casos o compilador vai acusar o erro.
	
		public string nome; ---> campo publico
		public string Nome {get; set;} --> propriedade

	A palavra chave BASE é utilizada quando há necessidade de fazer referência à algum método ou propriedade da classe pai
	da qual se esta herdando as características.

	POLIMORFISMO: Trata objetos instânciados de uma Classe derivada como que se fosse a Classe base, evitando repetições
	de código e várias sobrecargas iguais.
	( https://pt.wikipedia.org/wiki/Polimorfismo_(ci%C3%AAncia_da_computa%C3%A7%C3%A3o) )


	Ao inserir parametros no contrutor da Classe base, estes tornam-se obrigatórios na construção do objeto ao ser instanciado. Nas
	Classes derivadas (que herdam da Classe base) é necessário que o parametro tbm seja especificado em seu construtor, porém, o 
	contrutor da Classe base é sempre chamado primeiro. Sendo assim, é necessário passar o parametro recebido na Classe derivada
	para o construtor da Classe base afim de satisfazer a obrigatoriedade do parametro para a construção do objeto.
		Ex.: public Pessoa(string nome) : base(nome) {}

	O modificador de acesso PROTECTED torna a propriedade/método publico para a Classe que o criou e para as Classes que 
	herdam(derivadas) deste e privado para todas as demais Classes do programa.

	Métodos STATIC pertencem somente à Classe que os criou e não podem fazer chamadas de métodos de instância, a não ser que, o 
	método que está sendo chamado também seja do tipo STATIC.

	Classes ABSTRACT(Abstratas) servem como base para contrução de objetos derivados e não faz sentido que as mesmas possam ser 
	instânciadas diretamente, usando o modificador Abstract na Classe, impedimos que a mesma seja instância mesmo que por engano.

	Métodos ABSTRACT são assinaturas dentro da Classe que indicam que, assim que a Classe for instânciada os métodos devem 
	obrigatóriamente ser implementados. Funciona semelhante aos métodos VIRTUAL com a diferente de que não possuem corpo
	declarado com comportamento padrão e sua implementação é obrigatório para quem herda a Classa à qual pertecem.
	Métodos Abstratos SÓ PODEM PERTENCER A CLASSES ABSTRATAS.

	C# NÃO POSSUI HERANÇA MULTIPLA, quando há necessidades de que uma Classe derive de mais de uma Classe, uma delas deve 
	ser transformada em INTERFACE.
	INTERFACE não é uma classe. INTERFACE implementa uma assinatura de métodos que ela pode representar, assim como Classes e Métodos
	ABSTRACT, com a diferença que na INTERFACE não se utiliza modificadores de acesso (public, protect) na implementação dos 
	métodos. INTERFACE também pode ser chamada de Contrato, pois, quem implementa a interface deve garantir que todos os métodos
	dela sejam obrigatoriamente implementados.


	*** PARTE 04 - EXCEÇÕES

	Exceções são propagadas na pilha de chamadas do compilador (call stack) e podem ser capturadas para tratamento utilizando os 
	blocos TRY {} CATCH(){} ;
	Podem haver várias blocos Catch, desde que, tratando Exceções derivadas de Exception, pois, uma vez que um bloco Catch
	esteja tratando o nivel mais baixo de exceção (Exception) os blocos catch que vierem abaixo irão gerar um erro.


	THROW age como controle de fluxo e server para lançamento de excessões. O throw captura a excessão e passa adiante na
	stack para que outro método faça o tratamento.
	Quando se está fora do contexto de exceção - um bloco catch, por exemplo - é possível lançar uma exceção instânciando-a
	da seguinte forma: throw new Exception();


	PROPRIEDADES SOMENTE LEITURA : O modificador READONLY fazer com que a propriedade torne-se somente leitura, sendo assim,
	a mesma só pode ser alterada pelo construtor da Classe. Isso garante que o valor não seja alterado e sim, seja criada
	uma nova instância sempre que necessário.
	Para uso do READONLY a propriedade tem que ser PRIVATE e o set não deve existir na declaração publica.
		Ex.: 
			private readonly int _valor;
			public int Valor { get {return _valor} };

	O exemplo acim elucida a forma como por baixo dos panos o compilador cria as propriedades, então, para simplificar a 
	escrita da propriedade na Classe, somente é necessário remover o setter que automaticamente a propriedade passa a ser
	READONLY.
		Ex.: 
			public int Valor { get; };

	ARGUMENTEXCEPTION pode ser utilizado para construir exceções "personalizadas" para o tratamento de erros de argumeto
	específicos da aplicação que está sendo construída.

	O operador NAMEOF() transforma um parametro dentro do contexto em String.
		Ex.: nameof(numero);


	É possível criar Exceções personalizadas para suprir os problemas do domínio, porém, para que a execeção seja capturada
	dentro do bloco catch, a mesma deve herdar as caracteristicas da Classe Exception.

	INNEREXCEPTION serve para capturar exeções internas, não expondo os dados desta diretamenta no StackTrace caso um erro 
	ocorra, porém, preservando todo o Trace para que o desenvolvedor possa ter acesso ao Trace completo posteriormente.
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

	FINALLY executa uma ação independente de ter ocorrido ou não uma exceção na leitura dos blocos try/catch.

	USING é uma diretiva que "simula" os blocos try/catch/finally. Caso haja a necessidade de um bloco finally usar de um objeto
	instanciado dentro do bloco catch, para não haver a necessidade de que a variável de referência fique solta fora dos blocos
	de execução, usa-se o using(){} para intância e captura de exceção no lugar do try/catch/finally.
	O bloco USING é usado basicamente quando há a necessidade de liberação de recurso de um objecto recém criado. 
	Para que uma Classe seja instânciada dentro de um bloco USING, é necessário que a mesma implemente a interface IDisposable() que
	possui como assinatura um método responsável para encerrar possíveis conexões que tenham ficado ativas.
		Ex.:
			using(LeitorDeArquivo leitor = new LeitorDeArquivo("Arquivo.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }

	
	*** PARTE 05 - DLLs e Documentação

	Modificador de acesso INTERNAL fazer com que a Classe/Método seja acessível somente dentro do projeto que foi criada, por mais
	que o projeto seja compartilhado com outros projetos (Referência de Projeto) a Classe continua mantendo seu nível de
	acessibilidade somente para o projeto à qual foi criada.
		Ex.: internal class AutenticacaoHelper{ }

	*Obs.: Caso uma nova Classe seja criada sem o modificador de acesso (SOMENTE CLASSES) o compilador entende que o nível
	de acesso da Classe é INTERNAL.
		Ex.: class AutenticadorHelper{ }


	Modificador INTERNAL PROTECTED torna o Método visivel para Classes dentro do projeto e para Classes que derivam fora do projeto.
		Ex.: internal protected abstract double GetBonificacao(){ } 

	Para DOCUMENTAR Classes e Métodos Públicos basta utilizar as três barras /// em conjunto com a TAG XML <summary>;
		Ex.: 
			/// <summary>
			/// Defini uma conta corrente do banco ByteBank
			/// </summary>

	Uma vez habilitado no Visual Studio a geração de documentação, todos as Classes e Métodos publicos que não tiverem documentados
	ficaram marcados com uma mensagem de erro, porém, isso não impede a compilação e funcionamento do projeto.
	Também é possível documentar Exceções que serão lançadas em caso de algum erro. Para exceções utilizar a tag <exception cref="Nome_Exceção">.
	Para fazer referência ao parametro que esta sendo utilizado em métodos, utilizar a tag <paramref name="nome_parametro" />

	Para representar datas usa-se a Classe DATETIME() nativo do C#.
		Ex.: DateTime data = new DateTime();

	Para efetuar calculo com datas é necessário utilizar a Classe TIMESPAN(). NÃO é possível efetuar calculo de Datas utilizando a
	classe DateTime().
		Ex.: TimeSpan calculoData = data1 - data2;

	Para fácil tratamento dos calculos com Datas utilizar a bibliota HUMANIZER encontrada no NuGets;


	*** PARTE 06 - Strings, Expressões Regulares e a classe Object

	Manipulação de Strings:
		.string.Substring("index"); -> Substring é inclusivo, vai retornar a string a partir do index passado no paramentro
	incluindo o caractere contido no valor do index;
	
	Método INDEXOF() server para obter o index de uma string ou char;

	Método REMOVE() remove parte da string a partir de um valor de index;

	Para trabalhar com EXPRESSÕES REGULARES no C#, utilizar a Classe REGEX();
		Regex.IsMatch(); -> verifica um padrão em texto e retorna true/false;
		Regex.Match(); -> verifica um padrão e retorna um objeto com o resultado da busca. O retorno é um objeto do tipo Match e
		dentro dele é possível obter o Value.

		[0-9][a-Z][a-z] -> os valores entre colchetes são padrões de intervalo;
		{4}{10}{2} -> os valores entre chaves são quantificadores, ou seja, representa a quantidade de vezes que um padrão 
	irá se repetir;
		{0,1}{3,5} -> quantificadores podem conter intervalos com valores separados por vírgula;
		? -> quando quantificadores possuem intervalos de {0,1} é possível simplificar utilizando o caractere ? ;

		Ex.: string padrao = "[0-9]{4,5}-?[0-9]{4}" -> Regex para numeros de telefone 98762-9898 ou 2121-8765


	Classe OBJECT -> toda Classe dentro dentro do .NET/C# deriva (implícitamente) do tipo OBJECT;


	É possível executar CONVERSÃO EXPLÍCITA de Classes quando for necessário converter uma Classe de nível mais baixo
	em uma Classes de nível mais alto, para isso é necessário utilizar os parênteses (CAST).
		Ex.: 
			public override bool Equals(object obj)
			{
				Cliente novoCliente = (Cliente)obj; //** Conversão explícita de obj em Cliente
			}

	A conversão utilizando (Cliente)obj espera que o objeto recebido seja do tipo Cliente, caso contrário uma Exception vai ser 
	exibida informando que o tipo de referência não é compatível.
	É possível fazer o CAST de outra forma, sem que uma Exception seja lançada quando um tipo direferente for recebido. Para isso
	utiliza a palavra reservada AS que indica o tipo do objeto que espera receber, caso seja de um tipo diferente, a conversão
	irá retornar NULL;
		Ex.: 
			public override bool Equals(object obj)
			{
				Cliente novoCliente = obj as Cliente; // retorna NULL caso obj seja de tipo diferente
			}
	Com essa abordagem é possível fazer a verificação da variável novoCliente antes de prosseguir na execução do código.

	
	*** List, Lambda e LINQ

	MÉTODOS DE EXTENSÃO -> É possível extender Métodos do .NET/C# de forma a criar novos comportamentos para Classes já 
	pré-estabelecidas, o método extendido NÃO faz parte da Classe pai, porém, atribui novas funcionalidades(comportamento) à Classe.
	Para extender um método, é feito o uso da palavra reservada THIS antes do tipo(Classe) que está sendo extendido.

		Ex.: public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens){}


	Métodos / Classes GENÉRICAS -> Para criação de métodos genéricos, o tipo <T> deve ser especificado na definição da Classe afim
	de passar esse parametro genérico para os Métodos que ela contém.
		Ex.: public static class Teste<T>
		{
			public static void Mensagem(T mensagem)
			{
				Console.WriteLine(mensagem);
			}
		}

	Para MÉTODOS DE EXTENSÃO GENÉRICOS o tipo <T> NÃO DEVE ser passado na declaração da Classe e sim no método que será extendido.
		Ex.: public static void Mensagem<T>(T mensagem)
		{
			Console.WriteLine(mensagem);
		}

	
	No .NET/C# o uso de VAR para criação de váriáveis deve é possível desde que a variável seja inicializada, pois, por ser do tipo
	implícito, é necessário que o compilador saiba qual o tipo do valor que será atribuido.
		Ex.: var minhaLista = new List<int>();


	Sort(); -> Ordena crescente;
    Reverse(); -> Ordena do ultimo elemento para o primeiro (não segue ordem alfabética ou decrescente se os valores não tiverem
	sido previamente ordenados);

	IComparable -> Para fazer ordenação de conjuntos de objetos o simples uso do Sort() não vai funcionar, para isso é necessário um 
	método (especifico da interface IComparable) de comparação para que seja possível essa ordenação. O método CompareTo() da interface
	IComparable específica em seu contrato que deve ser recebido um object para comparação e deve retorna um INT.
		Ex.:
			public class ContaCorrente : IComparable 
			{
				public int CompareTo(object obj)
				{
					// Retorna negativo quando a instânca precede o obj;
					// Retorna zero quando nossa instância e obj forem equivalentes;
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
			
	IComparer<T> -> Para que seja possível ordenar um conjunto de objetos especificando um parametro específico, utiliza-se a 
	interfae IComparer, que é utilizada como parametro do método Sort(Icomparer<T>) e possibilita escrever um método para essa 
	ordenação, já que, o mesmo é genérico e recebe na implementação qual a Classe que vai ser utilizada.
		Ex.:
			public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>{}
	Assim como na interface IComparable a interface ICompare<T> possui em seu contrato um método Compare() que deve retornar um int.

	Para utilizar a Classe ComparadorContaCorrentePorAgencia em conjunto com o método Sort():
		Ex.: contas.Sort(new ComparadorContaCorrentePorAgencia()); //utiliza uma instância da Classe criada passada como parametro para o Sort();
	
	ORDERBY -> Uma forma mais simples de ordenação de lista utilizando LAMBDA. Varre uma lista e ordena os valores e retorna uma
	nova lista do tipo IOrderedEnumerable<T>;
		Ex.: var listaOrdenada = contas.OrderBy(x => x.Agencia);


	*** Entrada e Saída (I/O) com streams

	FILESTREAM() -> Classe do .NET/C# utilizada para leitura/gravação de arquivos em diversos formatos.
		Ex.:
			var enderecoDoArquivo = "contas.txt";
            var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

			// Espaço para armazenamento dos bytes do arquivo que vai ser lido;
            var buffer = new byte[1024]; // 1 kb

	O buffer é criado para que seja possível lhe dar com arquivos maiores do que a memória do computador e também para que
	o programa não seja sobrecarregado, pois, o buffer por ser reutilizado e o tamanho especificado vai sendo
	substituido conforme o arquivo vendo sendo lido (Desde que seja percorrido e substituido por um laço While, por exemplo).

	Para que os bytes sejam interpretados como texto é necessário um Codificador/Decodificador(Coder/Decoder) que faça
	a transformação do bytes em Texto seja seguindo a tabela ASCII ou UTF-8, UTF-16, UTF-32, etc.
	Para isso pode ser utilizada a Classe UTF8Encoding(), por exemplo, que é responsavél por fazer o papel de 
	traduzir os bytes. A Classe UTF8Enconding herda da Classe ENCODING() que é uma Classe Abstrata.
		Ex.:
			// Decoding dos bytes em texto
            var a = new UTF8Encoding();
            var texto = a.GetString(buffer);
	
	Quando o arquivo é gerado, por exemplo, em uma máquina Windows e o programa que vai fazer o Decoding também roda em
	uma máquina Windows, é possível utilizar uma propriedade estática da Classe ENCODING() para decodificar sem ter que
	explicitamente informar qual o tipo de codificação que foi utilizado.
		Ex.: var a = Encoding.Default;

	FILESTREAM.Close() -> Método que libera o arquivo para outros usos.

	Para que não seja necessária a utilização do método Close toda vez que formos trabalhar com IO podemos utilizar a 
	diretiva USING(), já que, a Classe FileStream em sua composição herda da interface IDisposable() que fica responsável
	por chamar implicitamente o método Close.
		Ex.: 
			using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
			{
				// implementação
			}

	É possível dividir os arquivos de uma mesma Classe em arquivos diferentes, que serão lidos pelo compilador como um
	arquivo único. Para isso basta antes da palavra reserva class utilizar o modificador PARTIAL;
		Ex.: partial class Program {}

	Para trabalhar com Stream de forma mais simples, sem ter que se preocupar tanto com Encoding/Decoding e tamanho do Buffer
	utiliza-se a Classe StreamReader() em conjunto com a Classe FileStream. A Classe StreamReader possui diversos
	métodos para leitura e conversão de bytes em texto.
		Ex.:
			using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDoArquivo);

				// Lê somente uma linha do arquivo
                var linha = leitor.ReadLine();

				// Lê todas as linhas de um arquivo (CUIDADO, pois se o arquivo for muito grande pode ocorrer um Overflow de memória)
				var linha2 = leitor.ReadToEnd();

                Console.WriteLine(linha);
            }

	Para percorrer todo o arquivo sem que tenha que carregar tudo de uma vez em memória utilizando o método ReadToEnd(), utiliza
	um laço While com o verificador que indica quando o arquivo foi percorrido até o final.
		Ex.:
			using (var leitor = new StreamReader(fluxoDoArquivo))
            {
				// EndOfStream indica a última linha do arquivo
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.Read();
                    Console.WriteLine(linha);
                }
            }

	StreamWriter -> utilizado para criar arquivos em um caminho pré definido. Recebe um FileStream como primeiro parametro
	contendo a informação de path e FileMode (Create(sobrescreve arquivos com o mesmo nome) ou CreateNew(se o arquivo tiver
	o mesmo nome será lançada uma exceção.)).
		Ex.:
			using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8)) 
            {
                escritor.Write("456, 456765, 4756.89, Emerson Santos");
            }
	Obs.: A Classe FileStream possui um método Write, porém, é necessário lhe dar com a conversão de bytes, tamanho do
	buffer e tipo de encoding.

	Em tempo de execução, toda a escrita no arquivo só vai estar disponível após finalizar o processamento, pois, enquanto
	o processo de gerar o arquivo esta em execução, os dados que serão gravados ficam armazenados em buffer de memória. Essa
	abordagem é mais rápida, porém, caso um erro ocorra no momento da gravação, os dados em memória serão perdidos.
	Para que os dados sejam gravados linha a linha no arquivo em tempo de execução, a Classe StreamWriter possui um método
	chamado Flush(), que libera o buffer para o Stream assim que a leitura da linha é realizada.
		Ex.:
			using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8)) 
            {
                escritor.Write("456, 456765, 4756.89, Emerson Ferreira Santos");
                escritor.Flush();
            }

	Quando não há necessidade que o arquivo gerado seja lido por um humano, é possível gerar arquivo com dados binários afim
	de economizar espaço, processamento, memório e ganhar maior desempenho na escrita e leitura desse arquivo.
	Para arquivos binários, tanto na escrita quanto na leitura do arquivo, existem as Classes BinaryWriter() e 
	BinaryReader().
	Para LEITURA do arquivo binário, os dados devem ser decodificados na ordem que foram gerados, caso o contrario, haverá
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


	CLASSE FILE -> forma mais fácil de leitura de arquivos, porém, deve tomar cuidado com seu uso, pois, o arquivo é lido
	completamente de uma vez, sem nenhum tipo de controle de buffer ou memória, sendo assim, caso seja feita a leitura de um
	arquivo muito grande, o uso do File pode deteriorar muito o desempenho do sistema ou causar estouro de memória.
		Ex.:
			var linhas = File.ReadAllLines("contas.txt");
			
			foreach (var linha in linhas)
			{
				Console.WriteLine(linha);
			}

	Além de leitura, a Classe File possui também métodos para escrita de arquivos.
		Ex.: File.WriteAllText("nome_arquivo.txt", "texto no arquivo");

