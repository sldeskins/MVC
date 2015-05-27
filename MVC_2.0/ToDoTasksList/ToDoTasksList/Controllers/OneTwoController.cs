using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoTasksList.Controllers
{
    public class OneTwoController : Controller
    {
        ToDoTasksList.Models.Repository.ToDoTaskEntities _ent = new Models.Repository.ToDoTaskEntities();
        //
        // GET: /OneTwo/

        public ActionResult Index()
        {
            return View(_ent.OneTwoes.ToList());
        }

        //
        // GET: /OneTwo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OneTwo/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /OneTwo/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = ("OneTwoID"))]ToDoTasksList.Models.Repository.OneTwo createOneTwo)
        {
            try
            {
                _ent.AddToOneTwoes(createOneTwo);
                _ent.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OneTwo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OneTwo/Edit/5

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

        //
        // GET: /OneTwo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OneTwo/Delete/5

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
