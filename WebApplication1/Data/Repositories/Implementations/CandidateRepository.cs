using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication1.Data.Repositories.Interfaces;
using ModelProject.Models;

namespace WebApplication1.Data.Repositories.Implementations
{
    public class CandidateRepository : IGenericRepository<Candidate>, ICandidateRepository
    {
        private DbContext _dbContext;

        public CandidateRepository(AppContextDikoMou context)
        {
            _dbContext = context;
        }
        public Candidate Add(Candidate candidate)
        {
            var db = _dbContext as AppContextDikoMou;
            if (candidate.Id == 0)
            {
                db.Candidates.Add(candidate);
            }
            else
            {
                db.Candidates.AddOrUpdate(candidate);
            }
            db.SaveChanges();
            return candidate;
        }
        //
        // Summary:
        //    Returns a single candidate by ID
        //

        public Candidate Get(int? id)
        {
            var db = _dbContext as AppContextDikoMou;
            var candidate = db.Candidates.Find(id);
            return candidate;
        }

        //
        // Summary:
        //    Returns all candidates by ID
        //

        public IEnumerable<Candidate> GetAll()
        {
            var db = _dbContext as AppContextDikoMou;
            return db.Candidates.ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate Update(int id, Candidate entity)
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetCerts(int? id, bool isAdmin)
        {
            var db = _dbContext as AppContextDikoMou;
            if (isAdmin == true)
            {
                var results = db.Examinations.Where(x => x.Candidate_Id.Id == id).Include(x => x.Candidate_Id).Include(y => y.Certificate_Id).ToList();
                return results;
            }
            else
            {
                var results = db.Examinations.Where(x => x.Candidate_Id.Id == id && x.Passed == true).Include(x => x.Candidate_Id).Include(y => y.Certificate_Id).ToList();
                return results;
            }
        }
    }
}