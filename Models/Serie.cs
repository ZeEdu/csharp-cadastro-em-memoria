using System;

namespace DIO.Series.Models
{
	public class Serie
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string FullTitle { get; set; }
		public string Year { get; set; }
		public string Crew { get; set; }
		public bool Deleted { get; set; }

		public Serie(string id, string title, string fullTitle, string year, string crew)
		{
			Id = id;
			Title = title;
			FullTitle = fullTitle;
			Year = year;
			Crew = crew;
			Deleted = false;
		}
		public void DeleteItem()
		{
			this.Deleted = true;
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "Gênero: " + Id + Environment.NewLine;
			retorno += "Título: " + Title + Environment.NewLine;
			retorno += "Título Completo : " + FullTitle + Environment.NewLine;
			retorno += "Ano: " + Year;
			retorno += "Equipe: " + Crew;
			retorno += "Excluído: " + Deleted;
			return retorno;
		}
	}
}