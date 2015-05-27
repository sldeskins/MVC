using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoTasksList.Models.Repository;

namespace ToDoTasksList.Controllers
{
    public class HomeController : Controller
    {
        private ToDoTasksList.Models.Repository.ITaskRepository _rep;
        
        private ToDoTasksList.SQL.Models.TaskSQLDataContext _linqRep = new ToDoTasksList.SQL.Models.TaskSQLDataContext();
        private ToDoTasksList.Models.Repository.ToDoTaskEntities _ent = new Models.Repository.ToDoTaskEntities();

        public HomeController()
        {
             _rep = ( ITaskRepository)new TaskRepository();
        }
        public HomeController(ITaskRepository respository)
        {
            _rep = respository;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
           // return View(_ent.Tasks.ToList());
            //return View(_linqRep.Task1s.ToList());
            return View(_rep.ListAllTasks());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "TaskID,DateAdded,IsCompleted,DateCompleted")]ToDoTasksList.SQL.Models.Task1 taskToCreate)
        {
            try
            {
                _linqRep.GetChangeSet();
                _linqRep.SubmitChanges(); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
