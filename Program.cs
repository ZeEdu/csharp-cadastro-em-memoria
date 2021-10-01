using System;


namespace DIO.Series
{
	class Program
	{

		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						// ListarSeries();
						ListarSeries();
						break;
					case "2":
						// InserirSerie();
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();

			}

			Console.WriteLine("Obrigado por utilizar nossos serviços");

		}

		private static void VisualizarSerie()
		{
			System.Console.WriteLine("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			var serie = repositorio.RetornaPorId(indiceSerie);
			System.Console.WriteLine(serie);
		}

		private static void ExcluirSerie()
		{
			System.Console.WriteLine("Digite o id da série: ");
			int indeceSerie = int.Parse(Console.ReadLine());
			repositorio.Exclui(indeceSerie);
		}

		private static void AtualizarSerie()
		{
			System.Console.WriteLine("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite a Descrição da Série");
			string entradaDescricao = Console.ReadLine();

			Serie atualizarSerie = new Serie(id: indiceSerie,
																	genero: (Genero)entradaGenero,
																	titulo: entradaTitulo,
																	descricao: entradaDescricao,
																	ano: entradaAno);
			repositorio.Atualiza(indiceSerie, atualizarSerie);
		}

		private static void ListarSeries()
		{
			System.Console.WriteLine("Listar séries");
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				System.Console.WriteLine("Nenhuma série cadastrada");
				return;
			}

			foreach (var serie in lista)
			{
				bool excluido = serie.retornaExcluido();
				System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
			}
		}

		private static void InserirSerie()
		{
			System.Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite a Descrição da Série");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
																	genero: (Genero)entradaGenero,
																	titulo: entradaTitulo,
																	descricao: entradaDescricao,
																	ano: entradaAno);
			repositorio.Insere(novaSerie);
		}

		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("DIO Série a seu dispor!!!");
			System.Console.WriteLine("Informe a opção desejada");
			System.Console.WriteLine("1 - Listar séries");
			System.Console.WriteLine("2 - Inserir nova série");
			System.Console.WriteLine("3 - Atualizar série");
			System.Console.WriteLine("4 - Excluir série");
			System.Console.WriteLine("5 - Visualizar série");
			System.Console.WriteLine("C - Limpar Tela");
			System.Console.WriteLine("X - Sair");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			System.Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
