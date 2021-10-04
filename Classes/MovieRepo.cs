using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
	public class MovieRepo : IMoviesRepo<Movie>
	{
		private List<Movie> movieList = new List<Movie>();
		public void Delete(string id)
		{
			bool queryMovie = movieList.Exists(m => m.Id == id);
			if (queryMovie == false)
			{
				System.Console.WriteLine("Movie not found");
				return;
			}
			int moviePosition = movieList.FindIndex(m => m.Id == id);
			this.movieList[moviePosition].DeleteItem();
		}

		public void Insert(Movie entity)
		{
			this.movieList.Add(entity);
		}

		public void BulkInsert(List<Movie> entityList)
		{
			this.movieList.AddRange(entityList);
		}

		public List<Movie> ListMovies()
		{
			return this.movieList;
		}

		public Movie ReturnById(string id)
		{
			Movie movie = this.movieList.Find(m => m.Id == id);
			return movie;
		}

		public void Update(string id, Movie entity)
		{
			bool queryMovie = movieList.Exists(m => m.Id == id);
			if (queryMovie == false)
			{
				System.Console.WriteLine("Movie not found");
				return;
			}
			int moviePosition = movieList.FindIndex(m => m.Id == id);
			movieList[moviePosition] = entity;
		}

	}
}