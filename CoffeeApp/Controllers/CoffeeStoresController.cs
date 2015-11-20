using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeApp.Models;
using CoffeeApp.ViewModels;

namespace CoffeeApp.Controllers
{
    public class CoffeeStoresController : Controller
    {
        private DrinkContext db = new DrinkContext();

        // GET: CoffeeStores
        public ActionResult Index()
        {
            var coffeestores = db.CoffeeStores.Include(c => c.Reviews);

            return View(coffeestores.ToList());
        }
        public ActionResult Index(String eircode)
        {
            var viewModel = new CoffeeIndexData();
            viewModel.CoffeeStores = db.CoffeeStores

                .OrderBy(i => i.StoreName);

            if (eircode.Count() > 0)
            {
                ViewBag.Eircode = eircode.ToUpper();
                viewModel.Reviews = viewModel.CoffeeStores.Where(
                    i => i.Eircode.ToUpper() == eircode.ToUpper()).Single().Reviews;
            }



            return View(viewModel);
        }
        // GET: CoffeeStores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeStore coffeeStore = db.CoffeeStores.Find(id);
            if (coffeeStore == null)
            {
                return HttpNotFound();
            }
            return View(coffeeStore);
        }

        // GET: CoffeeStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Eircode,StoreName,Location,OpeningTime,ClosingTime")] CoffeeStore coffeeStore)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeStores.Add(coffeeStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeStore);
        }

        // GET: CoffeeStores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeStore coffeeStore = db.CoffeeStores.Find(id);
            if (coffeeStore == null)
            {
                return HttpNotFound();
            }
            return View(coffeeStore);
        }

        // POST: CoffeeStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Eircode,StoreName,Location,OpeningTime,ClosingTime")] CoffeeStore coffeeStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeStore);
        }

        // GET: CoffeeStores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeStore coffeeStore = db.CoffeeStores.Find(id);
            if (coffeeStore == null)
            {
                return HttpNotFound();
            }
            return View(coffeeStore);
        }

        // POST: CoffeeStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CoffeeStore coffeeStore = db.CoffeeStores.Find(id);
            db.CoffeeStores.Remove(coffeeStore);
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
