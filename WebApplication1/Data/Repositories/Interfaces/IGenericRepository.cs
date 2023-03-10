using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data.Repositories
{
        public interface IGenericRepository<T> where T : class
        {
            T Get(int? id);
            IEnumerable<T> GetAll();
            T Add(T entity);
            bool Remove(int id);
            T Update(int id, T entity);
        }
    }

