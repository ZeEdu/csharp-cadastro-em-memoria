using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
	interface IMoviesRepo<T>
	{
		List<T> ListMovies();
		T ReturnById(string id);
		void Insert(T entity);
		void BulkInsert(List<T> entityList);
		void Delete(string id);
		void Update(string id, T entity);

	}
}
