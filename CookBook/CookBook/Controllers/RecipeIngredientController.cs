using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CookBook.Models;

namespace CookBook.Controllers
{
    public class RecipeIngredientController : Controller
    {
        private RecipeEntities db = new RecipeEntities();

        // GET: RecipeIngredient
        public ActionResult Index()
        {
            var recipeIngredients = db.RecipeIngredients.Include(r => r.Ingredient).Include(r => r.Recipe);
            return View(recipeIngredients.ToList());
        }

        // GET: RecipeIngredient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredient);
        }

        // GET: RecipeIngredient/Create
        public ActionResult Create()
        {
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "IngredientName");
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name");
            return View();
        }

        // POST: RecipeIngredient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipeId,IngredientId,Amount,AmountSize")] RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                db.RecipeIngredients.Add(recipeIngredient);
                db.SaveChanges();
                return RedirectToAction("Index","Recipe");
            }

            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "IngredientName", recipeIngredient.IngredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "IngredientName", recipeIngredient.IngredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            return View(recipeIngredient);
        }

        // POST: RecipeIngredient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecipeId,IngredientId,Amount,AmountSize")] RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "IngredientName", recipeIngredient.IngredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredient);
        }

        // POST: RecipeIngredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            db.RecipeIngredients.Remove(recipeIngredient);
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
