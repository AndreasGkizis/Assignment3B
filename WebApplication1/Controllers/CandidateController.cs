using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Implementations;
using WebApplication1.Models;
using IronPdf;
using System.IO;

namespace WebApplication1.Controllers
{
    public class CandidateController : Controller
    {
        private AppContextDikoMou db = new AppContextDikoMou();
        private IGenericRepository<Candidate> candidateRepository;
        public CandidateController()
        {
            candidateRepository = new CandidateRepository(db);
        }
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([Bind(Include = "Id")] Candidate candidate,bool isAdmin)
        {
            var certs = (candidateRepository as CandidateRepository).GetCerts(candidate.Id, isAdmin);
            return View(certs);
        }

        public ActionResult Print (int? id)
        {
            var filename = "MyExportedpdf";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var folderPath = Path.Combine(baseDir, "StaticFiles");
            Environment.SetEnvironmentVariable("TEMP", baseDir);
            Installation.TempFolderPath= folderPath;
            // create a new PDF renderer
            var renderer = new HtmlToPdf();

            // render the HTML to a PDF document
            var pdf = renderer.RenderHtmlAsPdf("<h1>Hello World!</h1>");
 
                pdf.SaveAs(filename);
            var fileContents = System.IO.File.ReadAllBytes(folderPath + filename);

            // save the PDF to a memory stream

            // return the PDF as a file
            return File(fileContents, "application/pdf", filename);
        }


    }
}