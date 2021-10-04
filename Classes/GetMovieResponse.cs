using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
	public class GetMovieResponse
	{

		public string Id { get; set; }
		public long Rank { get; set; }
		public string RankUpDown { get; set; }
		public string Title { get; set; }
		public string FullTitle { get; set; }
		public long Year { get; set; }
		public Uri Image { get; set; }
		public string Crew { get; set; }
		public string ImDbRating { get; set; }
		public long ImDbRatingCount { get; set; }

		public GetMovieResponse(string id, long rank, string rankUpDown, string title, string fullTitle, long year, Uri image, string crew, string imDbRating, long imDbRatingCount)
		{
			Id = id;
			Rank = rank;
			RankUpDown = rankUpDown;
			Title = title;
			FullTitle = fullTitle;
			Year = year;
			Image = image;
			Crew = crew;
			ImDbRating = imDbRating;
			ImDbRatingCount = imDbRatingCount;
		}


	}
}