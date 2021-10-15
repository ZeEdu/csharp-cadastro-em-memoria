using System.Collections.Generic;
using DIO.Series.Interfaces;
using DIO.Series.Models;

namespace DIO.Series.Classes
{
	public class SerieRepo : ISeriesRepo<Serie>
	{
		private List<Serie> serieList = new List<Serie>();
		public void Delete(string id)
		{
			bool querySerie = serieList.Exists(m => m.Id == id);
			if (querySerie == false)
			{
				System.Console.WriteLine("Serie not found");
				return;
			}
			int seriePosition = serieList.FindIndex(m => m.Id == id);
			this.serieList[seriePosition].DeleteItem();
		}
		public void Insert(Serie entity)
		{
			this.serieList.Add(entity);
		}
		public List<Serie> ListMovies()
		{
			return this.serieList;
		}
		public Serie ReturnById(string id)
		{
			Serie movie = this.serieList.Find(m => m.Id == id);
			return movie;
		}
		public void Update(string id, Serie entity)
		{
			bool querySerie = serieList.Exists(m => m.Id == id);
			if (querySerie == false)
			{
				System.Console.WriteLine("Serie not found");
				return;
			}
			int moviePosition = serieList.FindIndex(m => m.Id == id);
			serieList[moviePosition] = entity;
		}
	}
}