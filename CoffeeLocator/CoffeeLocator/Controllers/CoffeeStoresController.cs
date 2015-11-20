//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using CoffeeApp.Models;

//namespace CoffeeLocator.Controllers
//{
//    public class CoffeeStoresController : Controller
//    {
//        private DrinkContext db = new DrinkContext();

//        // GET: CoffeeStores
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.CoffeeStores.ToListAsync());
//        }

//        // GET: CoffeeStores/Details/5
//        public async Task<ActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CoffeeStore coffeeStore = await db.CoffeeStores.FindAsync(id);
//            if (coffeeStore == null)
//            {
//                return HttpNotFound();
//            }
//            return View(coffeeStore);
//        }

//        // GET: CoffeeStores/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: CoffeeStores/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Eircode,StoreName,Location,IsOpen,StoreRating")] CoffeeStore coffeeStore)
//        {
//            if (ModelState.IsValid)
//            {
//                db.CoffeeStores.Add(coffeeStore);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(coffeeStore);
//        }

//        //// GET: CoffeeStores/Edit/5
//        //public async Task<ActionResult> Edit(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    CoffeeStore coffeeStore = await db.CoffeeStores.FindAsync(id);
//        //    if (coffeeStore == null)
//        //    {
//        //        return HttpNotFound();
//        //    }
//        //    return View(coffeeStore);
//        //}

//        // POST: CoffeeStores/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Eircode,StoreName,Location,IsOpen,StoreRating")] CoffeeStore coffeeStore)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(coffeeStore).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(coffeeStore);
//        }

//        // GET: CoffeeStores/Delete/5
//        public async Task<ActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CoffeeStore coffeeStore = await db.CoffeeStores.FindAsync(id);
//            if (coffeeStore == null)
//            {
//                return HttpNotFound();
//            }
//            return View(coffeeStore);
//        }

//        // POST: CoffeeStores/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(string id)
//        {
//            CoffeeStore coffeeStore = await db.CoffeeStores.FindAsync(id);
//            db.CoffeeStores.Remove(coffeeStore);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
