using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        //public ActionResult Index()
        //{
        //    return View();
        //}
        AppContextDikoMou db = new AppContextDikoMou();

        public ActionResult List()
        {
            ViewBag.cand = db.Candidates.ToList();
            var stuff = db.Candidates.ToList();
            ViewBag.Cert = db.Certificates.ToList();
            //foreach(var cert in ViewBag.Cert ) 
            //{
            //    Console.WriteLine(cert); 
            //}
            return View(db.Candidates.AsEnumerable<Candidate>());
        }


    }
}