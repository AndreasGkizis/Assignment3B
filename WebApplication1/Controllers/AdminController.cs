using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Data.Repositories.Implementations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private AppContextDikoMou db = new AppContextDikoMou();
        private IGenericRepository<Candidate> candidateRepository;

        public AdminController()
        {
            candidateRepository = new CandidateRepository(db);
        }

        // GET: Admin
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(candidateRepository.GetAll());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,CandidateNumber,FirstName,MiddleName,LastName,Gender," +
            "NativeLanguage,DateOfBirth,Email,LandlineNumber,MobileNumber,Address1,Address2," +
            "CountryOfResidence,StateOfResidence,TerritoryOfResidence,ProvinceOfResidence,TownOfResidence," +
            "CityOfResidence,PostalCode,PhotoIdType,PhotoNumber,PhotoIdIssueDate")]
        Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                candidateRepository.Add(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = candidateRepository.Get(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CandidateNumber,FirstName,MiddleName,LastName,Gender,NativeLanguage,DateOfBirth,Email,LandlineNumber,MobileNumber,Address1,Address2,CountryOfResidence,StateOfResidence,TerritoryOfResidence,ProvinceOfResidence,TownOfResidence,CityOfResidence,PostalCode,PhotoIdType,PhotoNumber,PhotoIdIssueDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        public ActionResult Certificates(int? id)
        {
            
            var exams = db.Examinations.Where(x => x.Candidate_Id.Id == id).Include(x => x.Candidate_Id).Include(y => y.Certificate_Id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (exams == null)
            {
                return HttpNotFound();
            }
            return View(exams);
        }

     

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
