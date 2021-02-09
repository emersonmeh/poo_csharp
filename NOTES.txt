	OOP com C# - Parte 2

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