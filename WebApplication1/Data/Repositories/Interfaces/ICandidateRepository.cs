﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories.Interfaces
{
    internal interface ICandidateRepository
    {
        Candidate Add(Candidate candidate);
    }
}