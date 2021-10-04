using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dio.Series.Classes;
using DIO.Series.Classes;


namespace DIO.Series
{
	class Program
	{
		static readonly MovieRepo movieRepo = new();
		static readonly HttpClient httpClient = new();

		// static SerieRepositorio repositorio = new SerieRepositorio();
		static async Task Main(string[] args)
        {
            await LoadMovies();

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

        private static async Task LoadMovies()
        {
            try
            {
                var responseStream = httpClient.GetStreamAsync("https://imdb-api.com/en/API/MostPopularMovies/k_f1wugarq");
                var movies = await JsonSerializer.DeserializeAsync<GetMovies>(await responseStream);

                foreach (var movie in movies.Items)
                {
					Movie newMovie = new(id: movie.Id, title: movie.Title, fullTitle: movie.FullTitle, year: movie.Year, crew: movie.Crew);
					movieRepo.Insert(newMovie);
                }

			}
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message: {0}", e.Message);
            }
        }

        private static void VisualizarFilme()
		{
			System.Console.WriteLine("Digite o id do filme: ");
			string indiceSerie = Console.ReadLine().ToLower();
			Movie movie = movieRepo.ReturnById(indiceSerie);
			System.Console.WriteLine(movie);
		}

		private static void ExcluirFilme()
		{
			System.Console.WriteLine("Digite o id da filme: ");
			string movieId = Console.ReadLine();
			movieRepo.Delete(movieId);
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

			Movie updatedMovie = new(id: movieId, 
				title: inputTitle, 
				fullTitle: inputFullTitle, 
				year: inputYear, 
				crew: inputCrew);
			movieRepo.Update(movieId, updatedMovie);
		}

		private static void ListarFilmes()
		{
			System.Console.WriteLine("Listar Filmes");
			var lista = movieRepo.ListMovies();

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
			System.Console.WriteLine("Inserir nova série");

			System.Console.WriteLine("Digite o título da série: ");
			string inputTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o título completo da série: ");
			string inputFullTitle = Console.ReadLine();

			System.Console.WriteLine("Digite o ano do filme");
			string inputYear = Console.ReadLine();

			System.Console.WriteLine("Digite a equipe do filme");
			string inputCrew = Console.ReadLine();


			Movie newMovie = new(id: Helper.RandomString(8), title: inputTitle, fullTitle: inputFullTitle, year: inputYear,crew: inputCrew);
			movieRepo.Insert(newMovie);
		}

		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("MovieFLIX a seu dispor!!!");
			System.Console.WriteLine("Informe a opção desejada");
			System.Console.WriteLine("1 - Listar filmes");
			System.Console.WriteLine("2 - Inserir novo filme");
			System.Console.WriteLine("3 - Atualizar filme");
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
