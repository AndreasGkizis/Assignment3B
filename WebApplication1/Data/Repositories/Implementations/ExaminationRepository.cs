using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Data.Repositories.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories.Implementations
{
    public class ExaminationRepository : IGenericRepository<Examination>
    {
        private DbContext _dbContext;
        public ExaminationRepository(AppContextDikoMou context)
        {
            _dbContext = context;
        }
        public Examination Add(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination Get(int? id)
        {
            var db = _dbContext as AppContextDikoMou;
            var results = db.Examinations.Where(x => x.Id == id && x.Passed == true).Include(x => x.Candidate_Id).Include(y => y.Certificate_Id).FirstOrDefault();
            return results;

        }

        public IEnumerable<Examination> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Examination Update(int id, Examination entity)
        {
            throw new NotImplementedException();
        }
    }
}