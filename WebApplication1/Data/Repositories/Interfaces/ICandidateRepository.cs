using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelProject.Models;

namespace WebApplication1.Data.Repositories.Interfaces
{
    internal interface ICandidateRepository
    {
        Candidate Add(Candidate candidate);
        List<Examination> GetCerts(int? id, bool isAdmin);


    }
}