using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Implementations;
using ModelProject.Models;
using IronPdf;
using System.IO;
using System.Net.Mime;

namespace WebApplication1.Controllers
{
    public class CandidateController : Controller
    {
        private AppContextDikoMou db = new AppContextDikoMou();
        private IGenericRepository<Candidate> candidateRepository;
        private IGenericRepository<Examination> examRepository;
        public CandidateController()
        {
            candidateRepository = new CandidateRepository(db);
            examRepository = new ExaminationRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([Bind(Include = "Id")] Candidate candidate, bool isAdmin)
        {
            var certs = (candidateRepository as CandidateRepository).GetCerts(candidate.Id, isAdmin);
            return View(certs);
        }
        public ActionResult Print(int? id)
        {
            var filename = "MyExportedpdf.pdf";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var exam = examRepository.Get(id);
            
            var renderer = new HtmlToPdf();
            string  Html = $"<h1>Congratulations {exam.Candidate_Id.FirstName} {exam.Candidate_Id.LastName} for getting the Certificate with title :{exam.Certificate_Id.Name}</h1>";
                    Html += $"You score was {exam.PercentageScore}% !";
            var pdf = renderer.RenderHtmlAsPdf(Html);

            pdf.SaveAs(baseDir + filename);
            var fileContents = System.IO.File.ReadAllBytes(baseDir + filename);

            var result = File(fileContents, "application/pdf", filename);
            return result;
        }


    }
}