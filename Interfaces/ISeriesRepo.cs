using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
	interface ISeriesRepo<T>
	{
		List<T> ListMovies();
		T ReturnById(string id);
		void Insert(T entity);
		void Delete(string id);
		void Update(string id, T entity);

	}
}
