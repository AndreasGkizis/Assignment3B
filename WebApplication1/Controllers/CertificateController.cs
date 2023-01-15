using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using ModelProject.Models;

namespace WebApplication1.Controllers
{
    public class CertificateController : Controller
    {
        AppContextDikoMou db = new AppContextDikoMou();

        // GET: Certificate
        public ActionResult Index(string kati)
        {
            ViewBag.mess = kati;
            return View(db.Certificates);
        }

        // GET: Certificate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Certificate/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Certificate cert)
        {
            string mess = "";
            if (cert.Id == 0)
            {
                mess = "added";
            }
            else
            {
                mess = "updated";
            }

            db.Certificates.AddOrUpdate(cert);
            db.SaveChanges();

            return RedirectToAction("Index", new { kati=$"A cert had been {mess} !Bravo"});
        }

        // POST: Certificate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Certificate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Certificate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Certificate/Delete/5
        public ActionResult Delete(int id)
        {
            string mess = "";
            try
            {
                mess = "bravo";
                var obj = db.Certificates.Find(id);
                db.Certificates.Remove(obj);
            }
            catch (Exception e)
            {
                mess = $"Deleting {id} failed";
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { kati = $"A cert had been {mess} !Bravo" });
        }

        // POST: Certificate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
