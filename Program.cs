using System;
using DIO.Series.Classes;
using DIO.Series.Models;

namespace DIO.Series
{
	class Program
	{
		static readonly SerieRepo serieRepo = new();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						ExcluirFilme();
						break;
					case "5":
						VisualizarFilme();
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

		private static void VisualizarFilme()
		{
			System.Console.WriteLine("Digite o id do filme: ");
			string indiceSerie = Console.ReadLine().ToLower();
			var serie = serieRepo.ReturnById(indiceSerie);
			System.Console.WriteLine(serie);
		}

		private static void ExcluirFilme()
		{
			System.Console.WriteLine("Digite o id da filme: ");
			string movieId = Console.ReadLine();
			serieRepo.Delete(movieId);
		}

		private static void AtualizarFilme()
		{
			System.Console.WriteLine("Digite o id da filme: ");
			string movieId = Console.ReadLine();

			System.Console.WriteLine("Digite o título da filme: ");
			string inputTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o título completo do filme: ");
			string inputFullTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o ano do filme");
			string inputYear = Console.ReadLine();

			System.Console.WriteLine("Digite a equipe do filme");
			string inputCrew = Console.ReadLine();

			Serie updatedMovie = new(id: movieId, title: inputTitle, fullTitle: inputFullTitle, year: inputYear, crew: inputCrew);

			serieRepo.Update(movieId, updatedMovie);
		}

		private static void ListarFilmes()
		{
			System.Console.WriteLine("Listar Filmes");
			var lista = serieRepo.ListMovies();

			if (lista.Count == 0)
			{
				System.Console.WriteLine("Nenhum filme cadastrado");
				return;
			}

			foreach (var movie in lista)
			{
				bool excluded = movie.Deleted;
				System.Console.WriteLine("#ID: {0} - {1} {2}", movie.Id, movie.Title, (excluded ? " - Excluido" : ""));
			}
		}

		private static void InserirFilme()
		{
			System.Console.WriteLine("Digite o id da serie: ");
			string serieId = Console.ReadLine();

			System.Console.WriteLine("Digite o nome da serie: ");
			string serieTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o titulo completo da série: ");
			string serieFullTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o ano da série: ");
			string serieYear = Console.ReadLine();

			System.Console.WriteLine("Digite o elenco da serie: ");
			string serieCrew = Console.ReadLine();

			Serie newSerie = new(id: serieId, title: serieTitle, fullTitle: serieFullTitle, year: serieYear, crew: serieCrew);

			serieRepo.Insert(newSerie);

			Console.WriteLine("Serie inserida com sucesso");
		}

		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("MovieFLIX a seu dispor!!!");
			System.Console.WriteLine("Informe a opção desejada");
			System.Console.WriteLine("1 - Listar filmes");
			System.Console.WriteLine("2 - Inserir novo filme");
			System.Console.WriteLine("4 - Excluir filme");
			System.Console.WriteLine("5 - Visualizar filme");
			System.Console.WriteLine("C - Limpar Tela");
			System.Console.WriteLine("X - Sair");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			System.Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
